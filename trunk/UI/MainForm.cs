using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        #region "MainForm : Members & Consts"

            #region "MainForm : Members"

                private string currentFileName = "";
                
                private bool IsFileChanged = false;
                
                private int paragraphID = 1;
                
                private int totalControlsHeight = 5;
                
                private GUIDocument savedDocument = null;
        
            #endregion

            #region "MainForm : Consts"
                
                private const int WIDTH_DIFFERENCE = 70;
                
                private const int HEIGHT_DIFFERENCE = 30;
            
            #endregion

        #endregion

        #region "MainForm : Initialization"

                public MainForm()
            {
                InitializeComponent();
            }

        #endregion

        #region "MainForm : Enums"

            public enum MainFormActions
            {
                Open_Document = 0,
                Save_Document = 1,
                Insert_File_To_Database = 2
            };

        #endregion

        #region "MainForm : Properties"

        #endregion

        #region "MainForm : Delegates"

            public delegate Object[] MainFormEventHandler(MainFormActions action, Object[] parameter);

        #endregion

        #region "MainForm : Events"

            public event MainFormEventHandler MainFormEvent;

        #endregion

        #region "MainForm : EventHandlers"

            private void newToolStripButton_Click(object sender, EventArgs e)
            {
                if (IsFileChanged)
                {
                    DialogResult res =
                        MessageBox.Show("Do you wish to save the changes","Text Comparer",MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                        SaveFile(currentFileName);
                    if (res == DialogResult.No)
                        OpenNewDocument();
                    if (res == DialogResult.Cancel)
                        return;
                    return;
                }
                OpenNewDocument();
            }

            private void openToolStripButton_Click(object sender, EventArgs e)
            {
                OpenFile();
            }

            private void saveToolStripButton_Click(object sender, EventArgs e)
            {
                SaveFile("");
            }

            private void tlstpContainer_ContentPanel_Resize(object sender, EventArgs e)
            {
                //pnlMain.Size = new Size(pnlBackground.Width - 2 * WIDTH_DIFFERENCE,
                //                        pnlMain.Height);
                //pnlMain.Location = new Point(this.Left + WIDTH_DIFFERENCE,
                //                             this.Top + HEIGHT_DIFFERENCE + 5);

            }


            private void tlsbtnAddParagraph_Click(object sender, EventArgs e)
            {
                AddParagraph(0, 0, null);
            }

            private void tlstpbtnRemove_Click(object sender, EventArgs e)
            {
                try
                {
                    for (int i = 0; i < pnlMain.Controls.Count; i++)
                    {
                        Control cnt = pnlMain.Controls[i];
                        if (cnt is cntHeader)
                        {
                            if (((cntHeader)cnt).RemoveMe)
                            {
                                pnlMain.Controls.Remove(cnt);
                                totalControlsHeight -= (cnt.Height + 10);
                                cnt.Dispose();
                                i --;
                                SetComponentsHeight(i, cnt.Height);
                            }
                        }
                        if (cnt is cntParagraph)
                        {
                            cntParagraph par = ((cntParagraph)cnt);
                            if (par.RemoveMe)
                            {
                                pnlMain.Controls.Remove(cnt);
                                totalControlsHeight -= (par.Height + 10);
                                i--;
                                SetComponentsHeight(i, par.Height);
                                RemoveChildrenCotrols(par.ControlParagraph.GUIParagraphID, ref i);
                                cnt.Dispose();
                            }
                        }
                    }
                }
                catch 
                {
                }
            }

            private void tlstpbtnInsertFile_Click(object sender, EventArgs e)
            {
                try
                {

                    if (IsFileChanged)
                    {
                        DialogResult res =
                            MessageBox.Show("Do you wish to save the changes before inserting it to the database", "Text Comparer", MessageBoxButtons.YesNoCancel);
                        if (res == DialogResult.Yes)
                            SaveFile(currentFileName);
                        if (res == DialogResult.Cancel)
                            return;
                        OnRequestForInformation(MainFormActions.Insert_File_To_Database, new Object[] { currentFileName, savedDocument });
                        MessageBox.Show("The file was inserted into the database. "
                                        + "From now on in order to insert the fileToolStripMenuItem once again you must save it on "
                                        + "a different name", "Text Comparer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("An error occoured during the file insertion","Text Comparer",MessageBoxButtons.OK,MessageBoxIcon.Error); 
                }
            }

            private Object[] ParagraphHandler(cntParagraph.CntParagraphActions action, Object[] parameter)
            {
                switch (action)
                {
                    case cntParagraph.CntParagraphActions.Add_Header:
                        AddHeader((int)parameter[0], (int)parameter[1], null);
                        break;
                    case cntParagraph.CntParagraphActions.Add_Paragraph:
                        AddParagraph((int)parameter[0], (int)parameter[1], null);
                        break;
                    case cntParagraph.CntParagraphActions.Remove_Header:
                        break;
                    case cntParagraph.CntParagraphActions.Remove_Paragraph:
                        break;
                    default :
                        return null;
                }
                return null;
            }

            protected virtual Object[] OnRequestForInformation(MainFormActions action, Object[] parameter)
            {
                if (MainFormEvent != null)
                    return MainFormEvent(action, parameter);
                return null;
            }

        #endregion

        #region "MainForm : Methods"

            private void OpenNewDocument()
            {
                pnlMain.Controls.Clear();
                pnlMain.Size = new Size(pnlBackground.Width - 2 * WIDTH_DIFFERENCE,
                                        pnlBackground.Height - 2 * HEIGHT_DIFFERENCE);
                pnlMain.Location = new Point(this.Left + WIDTH_DIFFERENCE,
                                             this.Top + HEIGHT_DIFFERENCE + 5);
                pnlMain.Visible = true;
                documentToolStripMenuItem.Enabled = true;
                addDocumentParagraphToolStripMenuItem.Enabled = true;
                tlsbtnAddParagraph.Enabled = true;
                totalControlsHeight = 5;
                IsFileChanged = false;
            }

            private void SaveFile(string fileName)
            {
                if (fileName == "")
                {
                    DialogResult res = saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        currentFileName = saveFileDialog1.FileName;
                        savedDocument = GenerateDocument();
                        OnRequestForInformation
                            (MainFormActions.Save_Document, new Object[] { currentFileName, savedDocument});
                    }
                }
            }

            private void OpenFile()
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    currentFileName = openFileDialog1.FileName;
                    Object[] objects =
                        OnRequestForInformation(MainFormActions.Open_Document, new Object[] { currentFileName });
                    savedDocument = (GUIDocument)objects[0];
                    totalControlsHeight = 10;
                    InitializeDocumentComponents(savedDocument);
                }
            }

            private void AddParagraph(int left, int parentId, GUIParagraph par)
            {
                cntParagraph paragraph = null;
                if (par == null)
                    paragraph = new cntParagraph(paragraphID, parentId);
                else
                    paragraph = new cntParagraph(par,parentId);
                paragraph.CntParagraphEvent += new cntParagraph.CntParagraphEventHandler(ParagraphHandler);
                paragraph.Width = pnlMain.Width - left - 40 ;
                paragraph.Location = new Point(left + 20, totalControlsHeight);
                pnlMain.Controls.Add(paragraph);
                if (pnlMain.Height <totalControlsHeight + 2 * paragraph.Height)
                    pnlMain.Height += paragraph.Height;
                totalControlsHeight += paragraph.Height + 10;
                tlstpbtnRemove.Enabled = true;
                removeDocumentItemsToolStripMenuItem.Enabled = true;
                paragraphID++;
                IsFileChanged = true;
            }

            private void AddHeader(int left, int parentID, GUIHeader head)
            {
                cntHeader header = null;
                if (head == null)
                    header = new cntHeader(parentID);
                else
                    header = new cntHeader(head, parentID);
                header.Width = pnlMain.Width - left - 40;
                header.Location = new Point(left + 20, totalControlsHeight);
                pnlMain.Controls.Add(header);
                if (pnlMain.Height < totalControlsHeight + 2 * header.Height)
                    pnlMain.Height += header.Height;
                totalControlsHeight += header.Height + 10;
                IsFileChanged = true;
            }


            private void RemoveChildrenCotrols(int id, ref int i)
            {
                try
                {
                    for (int x = i ; x < pnlMain.Controls.Count; x++) 
                    {
                        Control cnt = pnlMain.Controls[i];
                        if (cnt is cntHeader)
                        {
                            cntHeader header = (cntHeader)cnt;
                            if (header.ParentID == id)
                            {
                                pnlMain.Controls.Remove(cnt);
                                totalControlsHeight -= (header.Height + 10);
                                cnt.Dispose();
                                x--;
                                SetComponentsHeight(x, header.Height);
                            }
                        }
                        if (cnt is cntParagraph)
                        {
                            cntParagraph par = ((cntParagraph)cnt);
                            if (par.ParentID == id)
                            {
                                pnlMain.Controls.Remove(cnt);
                                totalControlsHeight -= (par.Height + 10);
                                x--;
                                SetComponentsHeight(i,cnt.Height);
                                RemoveChildrenCotrols(par.ControlParagraph.GUIParagraphID,ref x);
                                cnt.Dispose();
                            }
                        }
                    }
                }
                catch
                {
                }
            }

            private void SetComponentsHeight(int i, int height)
            {
                for (int x = i + 1; x < pnlMain.Controls.Count; x++)
                {
                    pnlMain.Controls[x].Top -= (height + 10);
                    if (pnlMain.Height - height > this.Height)
                        pnlMain.Height -= (height + 10);
                }
            }

            private GUIDocument GenerateDocument()
            {
                GUIDocument doc = new GUIDocument();
                for (int i = 0 ; i < pnlMain.Controls.Count; i++)
                {
                    Control cnt = pnlMain.Controls[i];
                    if (cnt is cntParagraph)
                    {
                        cntParagraph cntPar = (cntParagraph) cnt;
                        if (cntPar.ParentID == 0)
                        {
                            GUIParagraph par = cntPar.ControlParagraph;
                            AddParagraphItems(ref par, ++i);
                            doc.AddParagraph(par);
                        }
                    }
                }
                return doc;
            }

            private void AddParagraphItems(ref GUIParagraph par, int index)
            {
                for (int i = index; i < pnlMain.Controls.Count; i++)
                {
                    Control cnt = pnlMain.Controls[i];
                    if (cnt is cntParagraph)
                    {
                        cntParagraph cntPar = (cntParagraph)cnt;
                        if (cntPar.ParentID != par.GUIParagraphID)
                            return;
                        GUIParagraph paragraph = cntPar.ControlParagraph;
                        AddParagraphItems(ref paragraph, ++i);
                        par.AddNewElementToParagraph(paragraph);
                    }
                    if (cnt is cntHeader)
                    {
                        cntHeader cntHead = (cntHeader)cnt;
                        if (cntHead.ParentID != par.GUIParagraphID)
                            return;
                        GUIHeader header = cntHead.ControlHeader;
                        par.AddNewElementToParagraph(header);
                    }
                }
            }

            private void InitializeDocumentComponents(GUIDocument doc)
            {
                pnlMain.Controls.Clear();
                totalControlsHeight = 5;
                foreach (GUIParagraph par in doc.DocumentParagraphs)
                {
                    AddParagraph(0, 0, par);
                    AddParagraphToScreenFromDocument(0, 0, par);
                }
            }

            private void AddParagraphToScreenFromDocument(int left, int parentId, GUIParagraph par)
            {
                foreach (GUIDocumentItem item in par.GUIParagraphItems)
                {
                    if (item is GUIParagraph)
                    {
                        AddParagraph(left + 20, par.GUIParagraphID, (GUIParagraph)item);
                        AddParagraphToScreenFromDocument(left + 20, par.GUIParagraphID, (GUIParagraph)item);
                    }
                    if (item is GUIHeader)
                    {
                        AddHeader(left + 20, par.GUIParagraphID, (GUIHeader)item);
                    }
                }
            }

        #endregion
    }
}
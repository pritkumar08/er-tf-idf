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

            #region "MainForm : Members & Consts"
                private string currentFileName = "";
                private bool IsFileChanged = false;
                private int paragraphID = 1;
                private int totalControlsHeight = 5;
            #endregion

            #region 
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
                Save_Document = 1
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

            private void MainForm_Load(object sender, EventArgs e)
            {

            }

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

            private void cutToolStripButton_Click(object sender, EventArgs e)
            {

            }

            private void copyToolStripButton_Click(object sender, EventArgs e)
            {

            }

            private void pasteToolStripButton_Click(object sender, EventArgs e)
            {

            }

            private void tlstpContainer_ContentPanel_Resize(object sender, EventArgs e)
            {
                pnlMain.Size = new Size(pnlBackground.Width - 2 * WIDTH_DIFFERENCE,
                                        pnlMain.Height);
                pnlMain.Location = new Point(this.Left + WIDTH_DIFFERENCE,
                                             this.Top + HEIGHT_DIFFERENCE + 5);

            }

            private void addDocumentParagraphToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AddParagraph(0,0);
            }

            private void removeDocumentParagraphsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    int j = 0;
                    for (int i = 0; i<pnlMain.Controls.Count-j; i++)
                    {
                        Control cnt = pnlMain.Controls[i];
                        if (cnt is cntHeader)
                        {
                            if (((cntHeader)cnt).RemoveMe)
                            {
                                pnlMain.Controls.Remove(cnt);
                                cnt.Dispose();
                                j++;
                            }
                        }
                        if (cnt is cntParagraph)
                        {
                            cntParagraph par = ((cntParagraph)cnt);
                            if (par.RemoveMe)
                            {
                                pnlMain.Controls.Remove(cnt);
                                RemoveChildrenCotrols(par.ControlParagraph.GUIParagraphID,ref j);
                                cnt.Dispose();
                                j++;
                            }
                        }
                    }
                }
                catch(Exception exp)
                {
                    if (exp.ToString().Length > 0)
                        return;
                }
            }

            private void addHeaderToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private void removeHeaderToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private void addParagraphToolStripMenuItem1_Click(object sender, EventArgs e)
            {

            }

            private void removeParagraphToolStripMenuItem_Click(object sender, EventArgs e)
            {

            }

            private Object[] ParagraphHandler(cntParagraph.CntParagraphActions action, Object[] parameter)
            {
                switch (action)
                {
                    case cntParagraph.CntParagraphActions.Add_Header:
                        AddHeader((int)parameter[0], (int)parameter[1]);
                        break;
                    case cntParagraph.CntParagraphActions.Add_Paragraph:
                        AddParagraph((int)parameter[0], (int)parameter[1]);
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
                    }
                }
            }

            private void OpenFile()
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    currentFileName = openFileDialog1.FileName;
                    OnRequestForInformation(MainFormActions.Open_Document, new Object[] { currentFileName });
                }
            }

            private void AddParagraph(int left,int id)
            {
                cntParagraph paragraph = new cntParagraph(paragraphID,id);
                paragraph.CntParagraphEvent += new cntParagraph.CntParagraphEventHandler(ParagraphHandler);
                paragraph.Width = pnlMain.Width - left - 40 ;
                paragraph.Location = new Point(left + 20, totalControlsHeight);
                //paragraph.Anchor = AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
                pnlMain.Controls.Add(paragraph);
                if (pnlMain.Height <totalControlsHeight + 2 * paragraph.Height)
                    pnlMain.Height += paragraph.Height;
                totalControlsHeight += paragraph.Height + 10;
                tlstpbtnRemove.Enabled = true;
                removeDocumentItemsToolStripMenuItem.Enabled = true;
                paragraphID++;
                IsFileChanged = true;
            }

            private void AddHeader(int left,int id)
            {
                cntHeader header = new cntHeader(id);
                header.Width = pnlMain.Width - left - 40;
                header.Location = new Point(left + 20, totalControlsHeight);
                pnlMain.Controls.Add(header);
                if (pnlMain.Height < totalControlsHeight + 2 * header.Height)
                    pnlMain.Height += header.Height;
                totalControlsHeight += header.Height + 10;
                IsFileChanged = true;
            }


            private void RemoveChildrenCotrols(int id, ref int j)
            {
                try
                {
                    for (int i = 0; i < pnlMain.Controls.Count - j; i++) 
                    {
                        Control cnt = pnlMain.Controls[i];
                        if (cnt is cntHeader)
                        {
                            cntHeader header = (cntHeader)cnt;
                            if (header.ParentID == id)
                            {
                                pnlMain.Controls.Remove(cnt);
                                cnt.Dispose();
                                j++;
                            }
                        }
                        if (cnt is cntParagraph)
                        {
                            cntParagraph par = ((cntParagraph)cnt);
                            if (par.ParentID == id)
                            {
                                pnlMain.Controls.Remove(cnt);
                                RemoveChildrenCotrols(par.ControlParagraph.GUIParagraphID,ref j);
                                cnt.Dispose();
                                j++;
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    if (exp.ToString().Length > 0)
                        return;
                }
            }


        #endregion
    }
}
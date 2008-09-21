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

                private LinkedList<DocumentForm> documents;
                
                private int documentKeyCounter = 0;
                private int currentDocument = -1;        

            #endregion

            #region "MainForm : Consts"
            
            #endregion

        #endregion

        #region "MainForm : Initialization"

            public MainForm()
            {
                InitializeComponent();
                documents = new LinkedList<DocumentForm>();
            }

        #endregion

        #region "MainForm : Enums"

            public enum MainFormActions
            {
                Open_Document = 0,
                Save_Document = 1,
                Insert_File_To_Database = 2,
                Import_Document = 3,
                Import_Cache_Data = 4,
                Search_Web = 5,
                Exit_Application = 6
            };

        #endregion

        #region "MainForm : Properties"

        #endregion

        #region "MainForm : Delegates"

            public delegate Object[] MainFormEventHandler(MainFormActions action, Object[] parameters);

        #endregion

        #region "MainForm : Events"

            public event MainFormEventHandler MainFormEvent;

        #endregion

        #region "MainForm : EventHandlers"

            private void newToolStripButton_Click(object sender, EventArgs e)
            {
                CreateNewDocumentForm(null, "");
            }

            private void openToolStripButton_Click(object sender, EventArgs e)
            {
                OpenFile();
            }

            private void saveToolStripButton_Click(object sender, EventArgs e)
            {
                SaveFile("");
            }


            private void importToolStripMenuItem_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < 5; i++)
                {
                    int num = 1213644 + i;
                    string file = "C:\\Documents and Settings\\Elad\\Desktop\\tt" + num.ToString() + ".erp";
                    Object[] objects =
                        OnRequestForInformation(MainFormActions.Import_Document, new Object[] { "http://www.imdb.com/title/tt" + num.ToString() + "/" });
                    OnRequestForInformation
                                (MainFormActions.Save_Document, new Object[] { file, (GUIDocument)objects[0] });
                }
                //CreateNewDocumentForm((GUIDocument)objects[0], "imdb"); 
            }
            
            private void tlsbtnAddParagraph_Click(object sender, EventArgs e)
            {
                GetDocumentForm(currentDocument).AddParagraph(0, 0, null);
            }

            private void tlstpbtnRemove_Click(object sender, EventArgs e)
            {
                GetDocumentForm(currentDocument).RemoveDocumentItems();
            }

            private void tlstpbtnInsertFile_Click(object sender, EventArgs e)
            {
                
            }

            protected virtual Object[] OnRequestForInformation(MainFormActions action, Object[] parameter)
            {
                if (MainFormEvent != null)
                    return MainFormEvent(action, parameter);
                return null;
            }


            private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AboutForm about = new AboutForm();
                about.ShowDialog();
            }

            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                foreach (DocumentForm docForm in documents)
                {
                    docForm.ExitFromFile();
                }
                OnRequestForInformation(MainFormActions.Exit_Application, null);
            }

            private Object[] DocumentFormHandler(DocumentForm.DocumentFormActions action, Object[] parameters)
            {
                switch (action)
                {
                    case DocumentForm.DocumentFormActions.Document_Focus:
                        SetCurrentDocument((int)parameters[0]);
                        return null;
                    case DocumentForm.DocumentFormActions.Save_File:
                        SaveFile((string)parameters[0]);
                        return null;
                    case DocumentForm.DocumentFormActions.Document_Close:
                        RemoveFile((int)parameters[0]);
                        return null;
                    default :
                        return null;
                }
            }

            private void tlstpbtnSearchGoogle_Click(object sender, EventArgs e)
            {
                Object[] objects =
                        OnRequestForInformation(MainFormActions.Search_Web, new Object[] { tlstptxtSearch.Text });
                ShowSearchResults((LinkedList<GUIGoogleSearchResult>)objects[0]);
            }

            private void tlstpbtnCacheImporter_Click(object sender, EventArgs e)
            {
                Object[] objects =
                        OnRequestForInformation(MainFormActions.Import_Cache_Data, null);
                CacheDataForm dataForm = new CacheDataForm((Dictionary<string, string>)objects[0]);
                dataForm.MdiParent = this;
                dataForm.Show();
            }


        #endregion

        #region "MainForm : Methods"

            private void CreateNewDocumentForm(GUIDocument document, string fileName)
            {
                DocumentForm docForm = new DocumentForm(document);
                docForm.DocumentFormEvent += new DocumentForm.DocumentFormEventHandler(DocumentFormHandler);
                docForm.Tag = ++documentKeyCounter;
                docForm.MdiParent = this;
                docForm.Text = "";
                if (fileName != "")
                {
                    int name = fileName.LastIndexOf("\\");
                    docForm.Text = fileName.Substring(name + 1, fileName.Length - name - 1);
                }
                docForm.WindowState = FormWindowState.Maximized;
                documents.AddFirst(docForm);
                docForm.Show();
            }

            private void OpenFile()
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    Object[] objects =
                        OnRequestForInformation(MainFormActions.Open_Document, new Object[] { fileName });
                    CreateNewDocumentForm((GUIDocument)objects[0],fileName); 
                }
            }

            private void SaveFile(string fileName)
            {
                if (fileName == "")
                {
                    DialogResult res = saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                        OnRequestForInformation
                            (MainFormActions.Save_Document,
                                new Object[] { fileName, GetDocumentForm(currentDocument).GenerateDocument()});
                    }
                }
            }

            private void RemoveFile(int tag)
            {
                foreach (DocumentForm doc in documents)
                {
                    if (tag == (int)doc.Tag)
                    {
                        documents.Remove(doc);
                        return;
                    }
                }
            }

            private void SetCurrentDocument(int documentTag)
            {
                currentDocument = documentTag;
                tlsbtnAddParagraph.Enabled = true;
                addDocumentParagraphToolStripMenuItem.Enabled = true;
                tlstpbtnRemove.Enabled = true;
                removeDocumentItemsToolStripMenuItem.Enabled = true;
                documentToolStripMenuItem.Enabled = true;
            }
        
            private DocumentForm GetDocumentForm(int tag)
            {
                foreach (DocumentForm doc in documents)
                {
                    if (tag == (int)doc.Tag)
                        return doc;
                }
                return null;
            }

            private void ShowSearchResults(LinkedList<GUIGoogleSearchResult> searchList)
            {
                SearchForm search = new SearchForm(searchList);
                search.MdiParent = this;
                search.Show();
            }

        #endregion

           
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace UI
{
    public partial class MainForm : Form
    {
        #region "MainForm : Members & Consts"

            #region "MainForm : Members"

                /// <summary>
                /// List of document currently open.
                /// </summary>
                private LinkedList<DocumentForm> documents;
                
                private int documentKeyCounter = 0;
                private int currentDocument = -1;

                private WaitForm waitForm = null;

            #endregion

            #region "MainForm : Consts"
            
            #endregion

        #endregion

        #region "MainForm : Initialization"

            /// <summary>
            /// The main form constructor.
            /// </summary>
            /// <param name="is_db_empty">was the database already initialize</param>
            public MainForm(bool is_db_empty)
            {
                InitializeComponent();
                SetDBEmpty(is_db_empty);
                documents = new LinkedList<DocumentForm>();
                EnableSave(false);
            }

        #endregion

        #region "MainForm : Enums"

            /// <summary>
            /// This enum is in charge over the functionality of the main form
            /// </summary>
            public enum MainFormActions
            {
                Open_Document = 0,
                Save_Document = 1,
                Insert_File_To_Database = 2,
                Import_Document = 3,
                Import_Cache_Data = 4,
                Search_Web = 5,
                Create_Cache_Database = 6,
                Check_Similarity = 7,
                Clear_Information = 8,
                Exit_Application = 9
            };

        #endregion

        #region "MainForm : Properties"

        #endregion

        #region "MainForm : Delegates"

            /// <summary>
            /// The delegate for the events of the main form.
            /// </summary>
            /// <param name="action">What action is taken</param>
            /// <param name="parameters">What are the parameter to send with the event</param>
            /// <returns></returns>
            public delegate Object[] MainFormEventHandler(MainFormActions action, Object[] parameters);

        #endregion

        #region "MainForm : Events"

            public event MainFormEventHandler MainFormEvent;

        #endregion

        #region "MainForm : EventHandlers"

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void newToolStripButton_Click(object sender, EventArgs e)
            {
                CreateNewDocumentForm(null, "");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void openToolStripButton_Click(object sender, EventArgs e)
            {
                OpenFile();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void saveToolStripButton_Click(object sender, EventArgs e)
            {
                SaveFile("");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void importToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ImportWebDocumentForm importForm = new ImportWebDocumentForm();
                importForm.ImportWebDocumentFormEvent += 
                    new ImportWebDocumentForm.ImportWebDocumentFormEventHandler(ImportWebDocumentHandler);
                importForm.ShowDialog();
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlsbtnAddParagraph_Click(object sender, EventArgs e)
            {
                GetDocumentForm(currentDocument).AddParagraph(0, 0, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnRemove_Click(object sender, EventArgs e)
            {
                GetDocumentForm(currentDocument).RemoveDocumentItems();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnInsertFile_Click(object sender, EventArgs e)
            {
                GetDocumentForm(currentDocument).InsertDocumentInDatabase();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameter"></param>
            /// <returns></returns>
            protected virtual Object[] OnRequestForInformation(MainFormActions action, Object[] parameter)
            {
                if (MainFormEvent != null)
                    return MainFormEvent(action, parameter);
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
            {
                AboutForm about = new AboutForm();
                about.ShowDialog();
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                foreach (DocumentForm docForm in documents)
                {
                    docForm.ExitFromFile();
                }
                OnRequestForInformation(MainFormActions.Exit_Application, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
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
                    case DocumentForm.DocumentFormActions.Insert_File_To_Database:
                        InsertToDatabase((string)parameters[0], (GUIDocument)parameters[1]);
                        return null;
                    default :
                        return null;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            private Object[] ImportWebDocumentHandler(ImportWebDocumentForm.ImportWebDocumentFormActions action, Object[] parameters)
            {
                switch (action)
                {
                    case ImportWebDocumentForm.ImportWebDocumentFormActions.Import_Web_Document:
                        ImportWebDocument((string)parameters[0]);
                        return null;
                    default:
                        return null;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            private Object[] SimilarityFormHandler(SimilarityForm.SimilarityFormActions action, Object[] parameters)
            {
                switch (action)
                {
                    case SimilarityForm.SimilarityFormActions.Reorder:
                        FindSimilarity(parameters);
                        return null;
                    default:
                        return null;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_DoSearchGoogle(object sender, DoWorkEventArgs e)
            {
                if (e.Argument == null)
                {
                    e.Result = OnRequestForInformation(MainFormActions.Search_Web, 
                        new Object[] { tlstptxtSearch.Text });
                }
                else
                {
                    e.Result = OnRequestForInformation(MainFormActions.Search_Web, 
                        new Object[] { ((Object[])e.Argument)[0] });
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_SearchGoogleCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                waitForm.Close();
                waitForm = null;
                Object[] objects = (Object[]) e.Result;
                ShowSearchResults(SimilarityForm.SimilarityType.None, (LinkedList<GUIGoogleSearchResult>)objects[0]);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_DoCreateCacheDB(object sender, DoWorkEventArgs e)
            {
                OnRequestForInformation(MainFormActions.Create_Cache_Database, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_CreateCacheDBCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                waitForm.Close();
                waitForm = null;
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_DoFindSimilarity(object sender, DoWorkEventArgs e)
            {
                e.Result = OnRequestForInformation(MainFormActions.Check_Similarity, (Object[]) e.Argument);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void BW_FindSimilarityCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                waitForm.Close();
                waitForm = null;
                Object[] objects = (Object[]) e.Result;
                LinkedList<GUIGoogleSearchResult> orderedResults =
                    (LinkedList<GUIGoogleSearchResult>)objects[0];
                ShowSearchResults((SimilarityForm.SimilarityType)objects[1], orderedResults);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnSearchGoogle_Click(object sender, EventArgs e)
            {
                AsyncWorkerOperation(BW_DoSearchGoogle,BW_SearchGoogleCompleted,"Searching Google...",
                    "Please wait while generating google results",null);
                //BackgroundWorker bw = new BackgroundWorker();
                //bw.DoWork += new DoWorkEventHandler(BW_DoSearchGoogle);
                //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_SearchGoogleCompleted);
                //bw.RunWorkerAsync();
                //waitForm = new WaitForm("Searching Google...", "Please wait while generating google results");
                //if (waitForm.ShowDialog() == DialogResult.Cancel)
                //{
                //    bw.CancelAsync();
                //}
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnCacheImporter_Click(object sender, EventArgs e)
            {
                Object[] objects =
                        OnRequestForInformation(MainFormActions.Import_Cache_Data, null);
                CacheDataForm dataForm = new CacheDataForm((Dictionary<string, string>)objects[0]);
                dataForm.MdiParent = this;
                dataForm.Show();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnCacheDatabase_Click(object sender, EventArgs e)
            {
                CreateCacheDatabase();
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnSimilarity_Click(object sender, EventArgs e)
            {
                SimilarityForm similar = new SimilarityForm();
                similar.SimilarityFormEvent += new SimilarityForm.SimilarityFormEventHandler(SimilarityFormHandler);
                similar.MdiParent = this;
                similar.Show();
            }
                
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnClearDB_Click(object sender, EventArgs e)
            {
                ClearCacheDatabase();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstptxtSearch_Click(object sender, EventArgs e)
            {
                if (tlstptxtSearch.Text == "Search Google...")
                    tlstptxtSearch.Text = "";
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void tlstpbtnOrganizeForms_Click(object sender, EventArgs e)
            {
                ReorderWindows();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                SaveFile("");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Process p = new Process();
                p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\Documentation.chm";
                p.Start();
            }
        #endregion

        #region "MainForm : Methods"
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="document"></param>
            /// <param name="fileName"></param>
            private void CreateNewDocumentForm(GUIDocument document, string fileName)
            {
                DocumentForm docForm = new DocumentForm(document, fileName);
                docForm.DocumentFormEvent += new DocumentForm.DocumentFormEventHandler(DocumentFormHandler);
                docForm.Tag = ++documentKeyCounter;
                docForm.MdiParent = this;
                docForm.WindowState = FormWindowState.Maximized;
                documents.AddFirst(docForm);
                docForm.Show();
                EnableSave(true);
            }

            /// <summary>
            /// 
            /// </summary>
            private void OpenFile()
            {
                DialogResult res = openFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    Object[] objects =
                        OnRequestForInformation(MainFormActions.Open_Document, new Object[] { fileName });
                    CreateNewDocumentForm((GUIDocument)objects[0],fileName);
                    EnableSave(true);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileName"></param>
            private void SaveFile(string fileName)
            {
                if (fileName == "")
                {
                    DialogResult res = saveFileDialog1.ShowDialog();
                    if (res == DialogResult.OK)
                        fileName = saveFileDialog1.FileName;
                    if (res == DialogResult.Cancel)
                        return;

                }  
                OnRequestForInformation
                        (MainFormActions.Save_Document,
                            new Object[] { fileName, GetDocumentForm(currentDocument).GenerateDocument() });
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="tag"></param>
            private void RemoveFile(int tag)
            {
                foreach (DocumentForm doc in documents)
                {
                    if (tag == (int)doc.Tag)
                    {
                        documents.Remove(doc);
                        if (documents.Count == 0)
                        {
                            documentToolStripMenuItem.Enabled = false;
                            tlsbtnAddParagraph.Enabled = false;
                            tlstpbtnRemove.Enabled = false;
                            EnableSave(false);
                        }
                        return;
                    }
                }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="documentTag"></param>
            private void SetCurrentDocument(int documentTag)
            {
                currentDocument = documentTag;
                tlsbtnAddParagraph.Enabled = true;
                addDocumentParagraphToolStripMenuItem.Enabled = true;
                tlstpbtnRemove.Enabled = true;
                removeDocumentItemsToolStripMenuItem.Enabled = true;
                documentToolStripMenuItem.Enabled = true;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileName"></param>
            /// <param name="doc"></param>
            private void InsertToDatabase(string fileName, GUIDocument doc)
            {
                OnRequestForInformation(MainFormActions.Insert_File_To_Database, new Object[] { fileName, doc });
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="tag"></param>
            /// <returns></returns>
            private DocumentForm GetDocumentForm(int tag)
            {
                foreach (DocumentForm doc in documents)
                {
                    if (tag == (int)doc.Tag)
                        return doc;
                }
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="type"></param>
            /// <param name="searchList"></param>
            private void ShowSearchResults(SimilarityForm.SimilarityType type, LinkedList<GUIGoogleSearchResult> searchList)
            {
                string caption = "Google Search Results ";
                switch (type)
                {
                    case SimilarityForm.SimilarityType.L2_Norm:
                        caption += "According to L2 Norm Algorithm";
                        break;
                    case SimilarityForm.SimilarityType.Min_Val:
                        caption += "According to Minimum Value Algorithm";
                        break;
                }
                SearchForm search = new SearchForm(searchList, caption);
                search.MdiParent = this;
                search.Show();
            }

            /// <summary>
            /// 
            /// </summary>
            private void CreateCacheDatabase()
            {
                AsyncWorkerOperation(BW_DoCreateCacheDB,BW_CreateCacheDBCompleted,"Creating database",
                    "Please wait while creating database...",null);
                SetDBEmpty(false);
                //BackgroundWorker bw = new BackgroundWorker();
                //bw.DoWork += new DoWorkEventHandler(BW_DoCreateCacheDB);
                //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_CreateCacheDBCompleted);
                //bw.RunWorkerAsync();
                //waitForm = new WaitForm("Creating database", "Please wait while creating database...");
                //if (waitForm.ShowDialog() == DialogResult.Cancel)
                //{
                //    bw.CancelAsync();
                //}
            }


            /// <summary>
            /// 
            /// </summary>
            /// <param name="parameters"></param>
            private void FindSimilarity(object[] parameters)
            {
                AsyncWorkerOperation(BW_DoFindSimilarity,BW_FindSimilarityCompleted,"Finding Similarity",
                    "Please wait while generating similarity...",parameters);
                if ((bool)parameters[4])
                {
                    AsyncWorkerOperation(BW_DoSearchGoogle,BW_SearchGoogleCompleted,"Searching Google...",
                    "Please wait while generating google results",parameters);
                }
                //BackgroundWorker bw = new BackgroundWorker();
                //bw.DoWork += new DoWorkEventHandler(BW_DoFindSimilarity);
                //bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BW_FindSimilarityCompleted);
                //bw.RunWorkerAsync(parameters);
                //waitForm = new WaitForm("Finding Similarity", "Please wait while generating similarity...");
                //if (waitForm.ShowDialog() == DialogResult.Cancel)
                //{
                //    bw.CancelAsync();
                //}
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="doWork"></param>
            /// <param name="workCompleted"></param>
            /// <param name="caption"></param>
            /// <param name="text"></param>
            /// <param name="parameters"></param>
            private void AsyncWorkerOperation(DoWorkEventHandler doWork, RunWorkerCompletedEventHandler workCompleted, 
                         string caption, string text, Object[] parameters)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.WorkerSupportsCancellation = true;
                bw.DoWork += new DoWorkEventHandler(doWork);
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workCompleted);
                bw.RunWorkerAsync(parameters);
                waitForm = new WaitForm(caption, text);
                if (waitForm.ShowDialog() == DialogResult.Cancel)
                {
                    bw.CancelAsync();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            private void ClearCacheDatabase()
            {
                DialogResult res = MessageBox.Show(this, "You are about to clear the cache database. \nIt is an irreversible operation, would you like to continue with the operation?", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    OnRequestForInformation(MainFormActions.Clear_Information, null);
                    SetDBEmpty(true);
                }
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="address"></param>
            private void ImportWebDocument(string address)
            {
                Object[] objects =
                    OnRequestForInformation(MainFormActions.Import_Document, new Object[] { address });  
                CreateNewDocumentForm((GUIDocument)objects[0], address); 
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="is_db_empty"></param>
            private void SetDBEmpty(bool is_db_empty)
            {
                tlstpbtnCacheDatabase.Enabled = is_db_empty;
                createCacheDatabaseToolStripMenuItem.Enabled = is_db_empty;

                tlstpbtnSimilarity.Enabled =  !is_db_empty;
                reorganizeSearchResultsToolStripMenuItem.Enabled = !is_db_empty;

                tlstpbtnClearDB.Enabled = !is_db_empty;
                clearCacheDatabaseToolStripMenuItem.Enabled = !is_db_empty;
            }

            /// <summary>
            /// 
            /// </summary>
            private void ReorderWindows()
            {
                int location = 0;
                foreach(Form frm in this.MdiChildren)
                {
                    frm.Width = this.Width/this.MdiChildren.Length;
                    frm.Location = new Point(location, 0);
                    location += frm.Width;
                }
            }
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="enable"></param>
            private void EnableSave(bool enable)
            {
                saveToolStripMenuItem.Enabled = enable;
                saveAsToolStripMenuItem.Enabled = enable;
                saveToolStripButton.Enabled = enable;
            }

        #endregion

    }
}
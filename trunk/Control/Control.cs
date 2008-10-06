using System;
using System.Collections.Generic;
using System.Text;
using Model;
using UI;

namespace Control
{
    class Control
    {

        #region Control : Members & Consts
            
            private ModelManager model;
            private UIManager ui;

        #endregion

        #region Control : Initialization
            
            public Control()
            {
                model = new ModelManager();
                bool is_empty = model.IsDBEmpty();
                //model.CleanDB();
                //model.ModelEvent += new ModelManager.ModelEventHandler(ModelEventHandler);

                ui = new UIManager();
                ui.GUIEvent += new UIManager.GUIEventHandler(GUIEventHandler);
                ui.LoadGUIApplication(is_empty);
            }

        #endregion

        #region Control : Properties

        #endregion

        #region Control : Events

        #endregion

        #region Control : EventHandlers

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public Object[] GUIEventHandler(UIManager.GUIAction action, Object[] parameters)
            {
                Model.ModelDocument document = null;
                switch (action)
                {
                    case UIManager.GUIAction.Open_Text_File:
                         document = model.OpenDocument((string)parameters[0]);
                        return new Object[] { ObjectTranslator.TranslateModelToGUI(document) };
                    case UIManager.GUIAction.Save_Text_File:
                        model.SaveDocument((string)parameters[0], (Model.ModelDocument)ObjectTranslator.TranslateGUIToModel((UI.GUIDocument)parameters[1]));
                        break;
                    case UIManager.GUIAction.Import_Text_File:
                        document = model.ImportDocument((string)parameters[0]);
                        return new Object[] { ObjectTranslator.TranslateModelToGUI(document) };
                    case UIManager.GUIAction.Import_Cache_Data:
                        Dictionary<string, string> addDic = model.ImportCacheData();
                        return new Object[] { addDic };
                    case UIManager.GUIAction.Search_Web:
                        LinkedList<ModelGoogleSearchResult> list = model.SearchWeb((string)parameters[0]);
                        return new Object[] {TranslateList(list)};
                    case UIManager.GUIAction.Create_Cache_Database:
                        model.CreateCacheDatabase();
                        break;
                    case UIManager.GUIAction.Check_Similarity:
                        return new Object[] {FindSimilarity(parameters),parameters[2]};
                    case UIManager.GUIAction.Clear_Cache_Database:
                        model.CleanDB();
                        break;
                    //case UIManager.GUIAction.Insert_Text_File_To_Database:
                    //    model.InsertNewDocumentToDatabase((string)parameters[0], (Model.ModelDocument)ObjectTranslator.TranslateGUIToModel((UI.GUIDocument)parameters[0]));
                    //    break;
                    default:
                        return null;
                }
                return null;
            }           
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            //public Object[] ModelEventHandler(ModelManager.ModelActions action, Object[] parameters)
            //{
            //    switch (action)
            //    {
            //        default :
            //            return null;
            //    }
            //}

        #endregion

        #region Control : Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="m_list"></param>
            /// <returns></returns>
            private LinkedList<GUIGoogleSearchResult> TranslateList(LinkedList<ModelGoogleSearchResult> m_list)
            {
                LinkedList<GUIGoogleSearchResult> g_list = new LinkedList<GUIGoogleSearchResult>();
                foreach (ModelGoogleSearchResult res in m_list)
                {
                    g_list.AddLast((GUIGoogleSearchResult)ObjectTranslator.TranslateModelToGUI(res));
                }
                return g_list;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="parameters"></param>
            /// <returns></returns>
            private LinkedList<GUIGoogleSearchResult> FindSimilarity(object[] parameters)
            {
                string searchLabel = (string)parameters[0];
                UI.SimilarityForm.SearchEngine u_engine = (UI.SimilarityForm.SearchEngine)parameters[1];
                Model.ModelManager.SearchEngine m_engine = ObjectTranslator.TranslateGUIEngine(u_engine);
                UI.SimilarityForm.SimilarityType u_type = (UI.SimilarityForm.SimilarityType)parameters[2];
                Model.ModelManager.SimilarityType m_type = ObjectTranslator.TranslateGUISimilarity(u_type);
                int pagesNumber = (int)parameters[3];
                LinkedList<ModelGoogleSearchResult> ls =
                           model.CheckSimilarity(searchLabel, m_type, m_engine, pagesNumber);
                return TranslateList(ls);
            }

        #endregion

    }
}

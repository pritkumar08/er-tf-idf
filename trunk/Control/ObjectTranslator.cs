using System;
using System.Collections.Generic;
using System.Text;

namespace Control
{
    static class ObjectTranslator
    {

        #region ObjectTranslator : Members & Consts

        #endregion

        #region ObjectTranslator : Initialization

        #endregion

        #region ObjectTranslator : Properties

        #endregion

        #region ObjectTranslator : Events

        #endregion

        #region ObjectTranslator : EventHandlers

        #endregion

        #region ObjectTranslator : Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            static internal UI.GUIItem TranslateModelToGUI(Model.ModelItem item)
            {
                if (item is Model.ModelDocument)
                {
                    UI.GUIDocument document = new UI.GUIDocument();
                    foreach (Model.ModelParagraph par in ((Model.ModelDocument)item).Paragraphs)
                    {
                        document.AddParagraph((UI.GUIParagraph)TranslateModelToGUI(par));
                    }
                    return document;
                }
                if (item is Model.ModelParagraph)
                {
                    Model.ModelParagraph m_par = (Model.ModelParagraph)item;
                    UI.GUIParagraph g_par = new UI.GUIParagraph
                        (m_par.Text, m_par.Pid, m_par.Weight);
                    foreach(Model.ModelDocumentItem d_item in m_par.Items)
                    {
                        g_par.AddNewElementToParagraph
                            ((UI.GUIDocumentItem)TranslateModelToGUI((Model.ModelDocumentItem)d_item));
                    }
                    return g_par;
                }
                if (item is Model.ModelHeader)
                {
                    Model.ModelHeader m_head = (Model.ModelHeader)item;
                    UI.GUIHeader g_head = new UI.GUIHeader(m_head.Text, m_head.Weight);
                    return g_head;
                }
                if (item is Model.ModelGoogleSearchResult)
                {
                    Model.ModelGoogleSearchResult m_search = (Model.ModelGoogleSearchResult)item;
                    UI.GUIGoogleSearchResult g_search =
                        new UI.GUIGoogleSearchResult(m_search.URL, m_search.Title, m_search.Content);
                    return g_search;
                }
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            /// <returns></returns>
            static internal Model.ModelItem TranslateGUIToModel(UI.GUIItem item)
            {
                if (item is UI.GUIDocument)
                {
                    Model.ModelDocument document = new Model.ModelDocument();
                    foreach (UI.GUIParagraph par in ((UI.GUIDocument)item).DocumentParagraphs)
                    {
                        document.AddParagraph((Model.ModelParagraph)TranslateGUIToModel(par));
                    }
                    return document;
                }
                if (item is UI.GUIParagraph)
                {
                    UI.GUIParagraph g_par = (UI.GUIParagraph)item;
                    Model.ModelParagraph m_par = new Model.ModelParagraph
                        (g_par.GUIDocumentItemText, g_par.GUIParagraphID, g_par.GUIDocumentItemWeight);
                    foreach (UI.GUIDocumentItem d_item in g_par.GUIParagraphItems)
                    {
                        m_par.AddNewElementToParagraph
                            ((Model.ModelDocumentItem)TranslateGUIToModel((UI.GUIDocumentItem)d_item));
                    }
                    return m_par;
                }
                if (item is UI.GUIHeader)
                {
                    UI.GUIHeader g_head = (UI.GUIHeader)item;
                    Model.ModelHeader m_head = new Model.ModelHeader(g_head.GUIDocumentItemText, g_head.GUIDocumentItemWeight);
                    return m_head;
                }
                if (item is UI.GUIGoogleSearchResult)
                {
                    UI.GUIGoogleSearchResult g_search = (UI.GUIGoogleSearchResult)item;
                    Model.ModelGoogleSearchResult m_search =
                        new Model.ModelGoogleSearchResult(g_search.URL, g_search.Title, g_search.Content);
                    return m_search;
                }
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="type"></param>
            /// <returns></returns>
            static internal Model.ModelManager.SimilarityType TranslateGUISimilarity(UI.SimilarityForm.SimilarityType type)
            {
                switch (type)
                {
                    case UI.SimilarityForm.SimilarityType.None:
                        return Model.ModelManager.SimilarityType.None;
                    case UI.SimilarityForm.SimilarityType.L2_Norm:
                        return Model.ModelManager.SimilarityType.L2_Norm;
                    case UI.SimilarityForm.SimilarityType.Min_Val:
                        return Model.ModelManager.SimilarityType.Min_Value;
                    default:
                        return Model.ModelManager.SimilarityType.None;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="engine"></param>
            /// <returns></returns>
            static internal Model.ModelManager.SearchEngine TranslateGUIEngine(UI.SimilarityForm.SearchEngine engine)
            {
                switch (engine)
                {
                    case UI.SimilarityForm.SearchEngine.Google:
                        return Model.ModelManager.SearchEngine.Google;
                    default:
                        return Model.ModelManager.SearchEngine.None;
                }
            }

        #endregion


    }
}

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

            static internal UI.GUIItem TranslateModelToGUI(Model.ModelItem item)
            {
                if (item is Model.ModelDocument)
                {
                    UI.GUIDocument document = new UI.GUIDocument();
                    foreach (Model.ModelParagraph par in ((Model.ModelDocument)item).DocumentParagraphs)
                    {
                        document.AddParagraph(new UI.GUIParagraph
                            (par.ParagraphBody,par.ParagraphID,par.DocumentItemWeight));
                    }
                    return document;
                }
                if (item is Model.ModelParagraph)
                {

                }
                if (item is Model.ModelHeader)
                {

                }
                return null;
            }

            static internal Model.ModelItem TranslateGUIToModel(UI.GUIItem item)
            {
                if (item is UI.GUIDocument)
                {

                }
                if (item is UI.GUIParagraph)
                {

                }
                if (item is UI.GUIHeader)
                {

                }
                return null;
            }

        #endregion


    }
}

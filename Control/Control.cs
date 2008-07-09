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
                //model.ModelEvent += new ModelManager.ModelEventHandler(ModelEventHandler);

                ui = new UIManager();
                ui.GUIEvent += new UIManager.GUIEventHandler(GUIEventHandler);
                ui.LoadGUIApplication();
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
                switch (action)
                {
                    case UIManager.GUIAction.Open_Text_File:
                        Model.ModelDocument document = model.OpenDocument((string)parameters[0]);
                        return new Object[] { ObjectTranslator.TranslateModelToGUI(document) };
                    case UIManager.GUIAction.Save_Text_File:
                        model.SaveDocument((string)parameters[0], (Model.ModelDocument)ObjectTranslator.TranslateGUIToModel((UI.GUIDocument)parameters[1]));
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

        #endregion

    }
}

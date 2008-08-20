using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class UIManager
    {
        #region UIManager : Members & Consts

            private MainForm frmMain = null;

        #endregion

        #region UIManager : Initialization

            public UIManager()
            {
                InitializeComponents();
            }

            private void InitializeComponents()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

        #endregion

        #region UIManager : Enums

            public enum GUIAction
            {
                Open_Text_File = 0,
                Save_Text_File = 1,
                Insert_Text_File_To_Database = 2,
                Import_Text_File = 3
            };
       
        #endregion

        #region UIManager : Delegates

            public delegate Object[] GUIEventHandler(GUIAction action, Object[] parameters);
        
        #endregion

        #region UIManager : Events

            public event GUIEventHandler GUIEvent;  
        
        #endregion

        #region UIManager : EventHandlers
            protected virtual Object[] OnGetInformation(GUIAction action, Object[] parameters)
            {
                if (GUIEvent != null)
                    return GUIEvent(action, parameters);
                return null;
            }

            private Object[] MainFormEventHandler(MainForm.MainFormActions action, Object[] parameters)
            {
                switch (action)
                {
                    case MainForm.MainFormActions.Open_Document:
                        return OnGetInformation(GUIAction.Open_Text_File, parameters);
                    case MainForm.MainFormActions.Save_Document:
                        return OnGetInformation(GUIAction.Save_Text_File, parameters);
                    case MainForm.MainFormActions.Insert_File_To_Database:
                        return OnGetInformation(GUIAction.Insert_Text_File_To_Database, parameters);
                    case MainForm.MainFormActions.Import_Document :
                        return OnGetInformation(GUIAction.Import_Text_File, parameters);
                    case MainForm.MainFormActions.Exit_Application:
                        Application.Exit();
                        return null;
                    default :
                        return null;
                }
            }
        #endregion

        #region UIManager : Methods
            
            public void LoadGUIApplication()
            {
                frmMain = new MainForm();
                frmMain.MainFormEvent += new MainForm.MainFormEventHandler(MainFormEventHandler);
                Application.Run(frmMain);
            }

        #endregion
    }
}

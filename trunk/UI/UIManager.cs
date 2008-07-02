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
                frmMain = new MainForm();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(frmMain);
            }

        #endregion

        #region UIManager : Events

        #endregion

        #region UIManager : EventHandlers

        #endregion

        #region UIManager : Methods
        
        #endregion
    }
}

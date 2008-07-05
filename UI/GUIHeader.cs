using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIHeader :GUIDocumentItem
    {
         
        #region GUIHeader : Members & Consts

            private String title;

        #endregion

        #region GUIHeader : Initialization

            public GUIHeader(String title, double weight)
                : base(weight)
            {
                this.title = title;
            }

        #endregion

        #region GUIHeader : Properties

            public String GUIHeaderTitle
            {
                get
                {
                    return this.title;
                }
                set
                {
                    this.title = value;
                }
            }

        #endregion

        #region GUIHeader : Events

        #endregion

        #region GUIHeader : EventHandlers

        #endregion

        #region GUIHeader : Methods

        #endregion

    }
}

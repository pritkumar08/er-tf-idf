using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIDocumentItem : GUIItem
    {

        #region GUIDocumentItem : Members & Consts

            protected double weight; 

        #endregion

        #region GUIDocumentItem : Initialization

            public GUIDocumentItem(double weight)
            {
                this.weight = weight;
            }

        #endregion

        #region GUIDocumentItem : Properties

            public double GUIDocumentItemWeight
            {
                get
                {
                    return this.weight;
                }
                set
                {
                    this.weight = value;
                }
            }

        #endregion

        #region GUIDocumentItem : Events

        #endregion

        #region GUIDocumentItem : EventHandlers

        #endregion

        #region GUIDocumentItem : Methods

        #endregion

    }
}

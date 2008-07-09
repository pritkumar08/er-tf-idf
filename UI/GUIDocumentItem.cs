using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIDocumentItem : GUIItem
    {

        #region GUIDocumentItem : Members & Consts

            protected string text = "";

            protected double weight = 0.0; 

        #endregion

        #region GUIDocumentItem : Initialization

            public GUIDocumentItem(string text, double weight)
            {
                this.text = text;
                this.weight = weight;
            }

        #endregion

        #region GUIDocumentItem : Properties

            public string GUIDocumentItemText
            {
                get
                {
                    return this.text;
                }
                set
                {
                    this.text = value;
                }
            }

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

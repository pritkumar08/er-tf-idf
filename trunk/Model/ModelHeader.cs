using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelHeader : ModelDocumentItem
    {
        
        #region Header : Members & Consts

            private String title;

        #endregion

        #region Header : Initialization

            public ModelHeader(String title,double weight):base(weight)
            {
                this.title = title;
            }

        #endregion

        #region Header : Properties

            public String HeaderTitle
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

        #region Header : Events

        #endregion

        #region Header : EventHandlers

        #endregion

        #region Header : Methods

        #endregion

    }
}

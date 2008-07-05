using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelDocumentItem : ModelItem
    {
          
        #region DocumentItem : Members & Consts

            protected double weight; 

        #endregion

        #region DocumentItem : Initialization

            public ModelDocumentItem(double weight)
            {
                this.weight = weight;
            }

        #endregion

        #region DocumentItem : Properties

            public double DocumentItemWeight
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

        #region DocumentItem : Events

        #endregion

        #region DocumentItem : EventHandlers

        #endregion

        #region DocumentItem : Methods

        #endregion

    }
}

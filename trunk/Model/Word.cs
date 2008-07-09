using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Word
    {

        #region Word : Members & Consts"

            public string text = "";
            public int locationID = 0;
            public double weight = 0.0;

        #endregion

        #region Word : Initialization"

            public Word(string text, int loc, double w)
            {
                this.text = text;
                this.locationID = loc;
                this.weight = w;
            }

        #endregion

        #region Word : Enums"

        #endregion

        #region Word : Properties"
            public string Text 
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

            public int LocationID
            {
                get
                {
                    return this.locationID;
                }
                set
                {
                    this.locationID = value;
                }
            }

            public double Weight
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

        #region Word : Events"

        #endregion

        #region Word : EventHandlers"

        #endregion

        #region Word : Methods"

        #endregion
    }
}

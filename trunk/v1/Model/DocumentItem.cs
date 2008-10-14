using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public abstract class DocumentItem
    {
          
        #region DocumentItem : Members & Consts

        #endregion

        #region DocumentItem : Initialization

            public DocumentItem()
            {
                
            }

        #endregion

        #region DocumentItem : Properties

            public string Text { get; set; }
            public int Location { get; set; }
            public double Weight { get; set; }

        #endregion

        #region DocumentItem : Events

        #endregion

        #region DocumentItem : EventHandlers

        #endregion

        #region DocumentItem : Methods

            public abstract bool Contains(string word);
            public abstract List<Word> getWords();

        #endregion

        }
}

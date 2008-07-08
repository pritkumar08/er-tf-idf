using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    abstract public class ModelDocumentItem : ModelItem
    {
          
        #region DocumentItem : Members & Consts

        #endregion

        #region DocumentItem : Initialization

            public ModelDocumentItem(string title,double weight)
            {
                this.Text = title;
                this.Weight = weight;
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

            public virtual bool Contains(string word)
            {
                return this.Text.Contains(word);
            }

            public virtual List<Word> getWords()
            {
                List<Word> words = new List<Word>();

                foreach (string s in this.Text.Split(new char[] { ' ' }))
                {
                    words.Add(new Word(s, this.Location, this.Weight));
                }
                return words;
            }

        #endregion

    }
}

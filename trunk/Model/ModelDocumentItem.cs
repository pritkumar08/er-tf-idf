using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Model
{
    abstract public class ModelDocumentItem : ModelItem
    {
          
        #region DocumentItem : Members & Consts

            private string text = "";
            private int location = 0;
            private double weight = 0.0;

        #endregion

        #region DocumentItem : Initialization

            public ModelDocumentItem(string title,double weight)
            {
                this.text = title;
                this.weight = weight;
            }

        #endregion

        #region DocumentItem : Properties

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
        
        public int Location 
        { 
            get 
            { 
                return this.location; 
            } 
            set 
            {
                this.Location = value;
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
                this.Weight = value;
            } 
        }

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

            public virtual List<RawWord> getWords()
            {
                List<RawWord> words = new List<RawWord>();

                foreach (string s in this.Text.Split(RawWord.DELIMS))
                {
                    if(!s.Equals(String.Empty))
                        words.Add(new RawWord(s, this.Location, this.Weight));
                }
                return words;
            }

        #endregion

    }
}

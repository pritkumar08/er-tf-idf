using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Model
{
    abstract public class ModelDocumentItem : ModelItem
    {
          
        #region DocumentItem : Members & Consts

            /// <summary>
            /// 
            /// </summary>
            private string text = "";
            /// <summary>
            /// 
            /// </summary>
            private int location = 0;
            /// <summary>
            /// 
            /// </summary>
            private double weight = 0.0;

        #endregion

        #region DocumentItem : Initialization
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="title"></param>
            /// <param name="weight"></param>
            public ModelDocumentItem(string title,double weight)
            {
                this.text = title;
                this.weight = weight;
            }

        #endregion

        #region DocumentItem : Properties

        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
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
        
        /// <summary>
        /// 
        /// </summary>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public virtual bool Contains(string word)
            {
                return this.Text.Contains(word);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Header : DocumentItem
    {
        
        #region Header : Members & Consts

        #endregion

        #region Header : Initialization

            public Header(string title)
            {
                this.Text = title;
            }

        #endregion

        #region Header : Properties

        #endregion

        #region Header : Events

        #endregion

        #region Header : EventHandlers

        #endregion

        #region Header : Methods

        public override bool Contains(string word)
        {
            return this.Text.Contains(word);
        }

        public override List<Word> getWords()
        {
            List<Word> words = new List<Word>();
            foreach (string s in this.Text.Split(new char[]{' '}))
            {
                words.Add(new Word(s,this.Location,this.Weight));
            }
            return words;
        }

        #endregion

        }
}

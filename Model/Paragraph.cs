using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Paragraph : DocumentItem
    {

        #region Paragraph : Members & Consts

        private List<DocumentItem> items;

        #endregion

        #region Paragraph : Initialization

        public Paragraph(String body)
        {
            this.Text = body;
            this.items = new List<DocumentItem>();
        }

        #endregion

        #region Paragraph : Properties

        internal List<DocumentItem> Items{ get; set; }

        #endregion

        #region Paragraph : Events

        #endregion

        #region Paragraph : EventHandlers

        #endregion

        #region Paragraph : Methods

        public override bool Contains(string word)
        {
            if (this.Text.Contains(word)) return true;
            foreach (DocumentItem item in this.items)
            {
                if (item.Contains(word)) return true;
            }
            return false;
        }

        public override List<Word> getWords()
        {
            List<Word> words = new List<Word>();

            foreach (string s in this.Text.Split(new char[] { ' ' }))
            {
                words.Add(new Word(s,this.Location,this.Weight));
            }

            foreach(DocumentItem item in items)
            {
                words.AddRange(getWords());
            }
            return words;
        }

        #endregion

    }
}

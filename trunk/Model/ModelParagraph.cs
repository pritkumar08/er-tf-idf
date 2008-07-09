using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelParagraph : ModelDocumentItem
    {
        
        #region Paragraph : Members & Consts
        
            private LinkedList<ModelDocumentItem> items = null;

            private int pid = 0;  

        #endregion

        #region Paragraph : Initialization

            public ModelParagraph(String body,int id,double weight):base(body,weight)
            {
                pid = id;
                items = new LinkedList<ModelDocumentItem>();
            }

        #endregion

        #region Paragraph : Properties

            public LinkedList<ModelDocumentItem> Items
            {
                get
                {
                    return this.items;
                }
            }

            public int Pid
            {
                get
                {
                    return this.pid;
                }
            }

        #endregion

        #region Paragraph : Events

        #endregion

        #region Paragraph : EventHandlers

        #endregion

        #region Paragraph : Methods

            public void AddNewElementToParagraph(ModelDocumentItem item)
            {
                if (!(Items.Contains(item)))
                {
                    Items.AddLast(item);
                }
            }

            public void RemoveElementFromParagraph(ModelDocumentItem item)
            {
                if (Items.Contains(item))
                {
                    Items.Remove(item);
                }
            }

            public override bool Contains(string word)
            {
                if (this.Text.Contains(word)) return true;
                foreach (ModelDocumentItem item in this.Items)
                {
                    if (item.Contains(word)) return true;
                }
                return false;
            }

            public override List<Word> getWords()
            {
                List<Word> words = base.getWords();
                foreach (ModelDocumentItem item in Items)
                {
                    words.AddRange(getWords());
                }
                return words;
            }



        #endregion


    }
}

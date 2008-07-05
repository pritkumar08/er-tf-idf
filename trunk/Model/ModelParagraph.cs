using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelParagraph : ModelDocumentItem
    {
        
        #region Paragraph : Members & Consts
            
            private string body;
            private int id;
            private LinkedList<ModelDocumentItem> items;

        #endregion

        #region Paragraph : Initialization

            public ModelParagraph(String body,int id,double weight):base(weight)
            {
                this.body = body;
                this.id = id;
                this.items = new LinkedList<ModelDocumentItem>();
            }

        #endregion

        #region Paragraph : Properties

            public string ParagraphBody
            {
                get
                {
                    return this.body;
                }
                set
                {
                    this.body = value;
                }
            }

            public int ParagraphID
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }

            public LinkedList<ModelDocumentItem> ParagraphItems
            {
                get
                {
                    return this.items;
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
                if (!(items.Contains(item)))
                {
                    items.AddLast(item);
                }
            }

            public void RemoveElementFromParagraph(ModelDocumentItem item)
            {
                if (items.Contains(item))
                {
                    items.Remove(item);
                }
            }

        #endregion

    }
}

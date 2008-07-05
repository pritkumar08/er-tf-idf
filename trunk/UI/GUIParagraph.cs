using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIParagraph : GUIDocumentItem
    {
 
        #region GUIParagraph : Members & Consts
            
            private string body;
            private int id;
            private LinkedList<GUIDocumentItem> items;

        #endregion

        #region GUIParagraph : Initialization

            public GUIParagraph(String body, int id, double weight)
                : base(weight)
            {
                this.body = body;
                this.id = id;
                this.items = new LinkedList<GUIDocumentItem>();
            }

        #endregion

        #region GUIParagraph : Properties

            public string GUIParagraphBody
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

            public int GUIParagraphID
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

            public LinkedList<GUIDocumentItem> GUIParagraphItems
            {
                get
                {
                    return this.items;
                }
            }
        
        #endregion

        #region GUIParagraph : Events

        #endregion

        #region GUIParagraph : EventHandlers

        #endregion

        #region GUIParagraph : Methods

            public void AddNewElementToParagraph(GUIDocumentItem item)
            {
                if (!(items.Contains(item)))
                {
                    items.AddLast(item);
                }
            }

            public void RemoveElementFromParagraph(GUIDocumentItem item)
            {
                if (items.Contains(item))
                {
                    items.Remove(item);
                }
            }

        #endregion

    }
}

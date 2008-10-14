using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIParagraph : GUIDocumentItem
    {
 
        #region GUIParagraph : Members & Consts
            
            /// <summary>
            /// 
            /// </summary>
            private int id;
            /// <summary>
            /// 
            /// </summary>
            private LinkedList<GUIDocumentItem> items;

        #endregion

        #region GUIParagraph : Initialization

            /// <summary>
            /// 
            /// </summary>
            /// <param name="body"></param>
            /// <param name="id"></param>
            /// <param name="weight"></param>
            public GUIParagraph(String body, int id, double weight)
                : base(body, weight)
            {
                this.id = id;
                this.items = new LinkedList<GUIDocumentItem>();
            }

        #endregion

        #region GUIParagraph : Properties

            /// <summary>
            /// 
            /// </summary>
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

            /// <summary>
            /// 
            /// </summary>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
            public void AddNewElementToParagraph(GUIDocumentItem item)
            {
                if (!(items.Contains(item)))
                {
                    items.AddLast(item);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="item"></param>
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

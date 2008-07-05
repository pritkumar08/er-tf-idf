﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIDocument : GUIItem
    {
        
        #region GUIDocument : Members & Consts

            private LinkedList<GUIParagraph> paragraphs;

        #endregion

        #region GUIDocument : Initialization

            public GUIDocument()
            {
                paragraphs = new LinkedList<GUIParagraph>();
            }

        #endregion

        #region GUIDocument : Properties

            public LinkedList<GUIDocumentItem> DocumentParagraphs
            {
                get
                {
                    LinkedList<GUIDocumentItem> items = new LinkedList<GUIDocumentItem>();
                    foreach (GUIParagraph par in paragraphs)
                    {
                        items.AddLast(par);
                    }
                    return items;
                }
            }

        #endregion

        #region GUIDocument : Events

        #endregion

        #region GUIDocument : EventHandlers

        #endregion

        #region GUIDocument : Methods

            public void AddParagraph(GUIParagraph par)
            {
                if (!(paragraphs.Contains(par)))
                {
                    paragraphs.AddLast(par);
                }
            }

            public void RemoveParagraph(GUIParagraph par)
            {
                if (paragraphs.Contains(par))
                {
                    paragraphs.Remove(par);
                }
            }

        #endregion


    }
}

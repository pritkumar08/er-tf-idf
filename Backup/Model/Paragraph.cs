using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class Paragraph : DocumentItem
    {
        
        #region Paragraph : Members & Consts
            
            private String body;
            private List<DocumentItem> items;

        #endregion

        #region Paragraph : Initialization

            public Paragraph(String body)
            {
                this.body = body;
                this.items = new List<DocumentItem>();
            }

        #endregion

        #region Paragraph : Properties
                
        #endregion

        #region Paragraph : Events

        #endregion

        #region Paragraph : EventHandlers

        #endregion

        #region Paragraph : Methods

            #endregion

        }
}

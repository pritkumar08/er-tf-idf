using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Document
    {

        #region Document : Members & Consts

        private Dictionary<int, Paragraph> paragraphs;

        #endregion

        #region Document : Initialization

            public Document()
            {
                paragraphs = new Dictionary<int, Paragraph>();
            }

        #endregion

        #region Document : Properties
            
        internal Dictionary<int, Paragraph> Paragraphs{ get; set; }

        #endregion

        #region Document : Events

        #endregion

        #region Document : EventHandlers

        #endregion

        #region Document : Methods

        #endregion

        }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelDocument : ModelItem
    {

        #region Document : Members & Consts

            private LinkedList<ModelDocumentItem> paragraphs = null;

        #endregion

        #region Document : Initialization

            public ModelDocument()
            {
                paragraphs = new LinkedList<ModelDocumentItem>();
            }

        #endregion

        #region Document : Properties
        
            public LinkedList<ModelDocumentItem> Paragraphs
            {
                get
                {
                    return this.paragraphs;
                }
            }

        #endregion

        #region Document : Events

        #endregion

        #region Document : EventHandlers

        #endregion

        #region Document : Methods

            public void AddParagraph(ModelParagraph par)
            {
                if (!(paragraphs.Contains(par)))
                {
                    paragraphs.AddLast(par);
                }
            }

            public void RemoveParagraph(ModelParagraph par)
            {
                if (paragraphs.Contains(par))
                {
                    paragraphs.Remove(par);
                }
            }

        #endregion

    }
}

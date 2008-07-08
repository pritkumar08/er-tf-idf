using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelDocument : ModelItem
    {

        #region Document : Members & Consts

        #endregion

        #region Document : Initialization

            public ModelDocument()
            {
                Paragraphs = new LinkedList<ModelDocumentItem>();
            }

        #endregion

        #region Document : Properties

            public LinkedList<ModelDocumentItem> Paragraphs{get; set; }

        #endregion

        #region Document : Events

        #endregion

        #region Document : EventHandlers

        #endregion

        #region Document : Methods

            public void AddParagraph(ModelParagraph par)
            {
                if (!(Paragraphs.Contains(par)))
                {
                    Paragraphs.AddLast(par);
                }
            }

            public void RemoveParagraph(ModelParagraph par)
            {
                if (Paragraphs.Contains(par))
                {
                    Paragraphs.Remove(par);
                }
            }

        #endregion

    }
}

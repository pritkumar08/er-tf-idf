using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelDocument : ModelItem
    {

        #region Document : Members & Consts

            private LinkedList<ModelDocumentItem> paragraphs = null;
            private string title;

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

            public string Title
            {
                get
                {
                    return this.title;
                }
                set
                {
                    this.title = value;
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

            public List<RawWord> getWords()
            {
                List<RawWord> words = new List<RawWord>();
                foreach (ModelParagraph p in Paragraphs)
                    words.AddRange(p.getWords());
                return words;
            }

        #endregion

    }
}

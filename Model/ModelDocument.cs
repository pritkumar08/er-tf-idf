using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelDocument : ModelItem
    {

        #region Document : Members & Consts

            /// <summary>
            /// 
            /// </summary>
            private LinkedList<ModelDocumentItem> paragraphs = null;

            /// <summary>
            /// 
            /// </summary>
            private string title;

        #endregion

        #region Document : Initialization

            /// <summary>
            /// 
            /// </summary>
            public ModelDocument()
            {
                paragraphs = new LinkedList<ModelDocumentItem>();
            }

        #endregion

        #region Document : Properties
        
            /// <summary>
            /// 
            /// </summary>
            public LinkedList<ModelDocumentItem> Paragraphs
            {
                get
                {
                    return this.paragraphs;
                }
            }

            /// <summary>
            /// 
            /// </summary>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="par"></param>
            public void AddParagraph(ModelParagraph par)
            {
                if (!(paragraphs.Contains(par)))
                {
                    paragraphs.AddLast(par);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="par"></param>
            public void RemoveParagraph(ModelParagraph par)
            {
                if (paragraphs.Contains(par))
                {
                    paragraphs.Remove(par);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
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

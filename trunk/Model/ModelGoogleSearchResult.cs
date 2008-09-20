using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ModelGoogleSearchResult : ModelItem
    {
        #region ModelGoogleSearchResult : Members & Consts
            
            private string url;
            private string title;
            private string content;

        #endregion

        #region ModelGoogleSearchResult : Initialization
            
            public ModelGoogleSearchResult(string url, string title, string content)
            {
                this.url = url;
                this.title = title;
                this.content = content;
            }

        #endregion

        #region ModelGoogleSearchResult : Properties

            public string URL
            {
                get
                {
                    return this.url;
                }
            }

            public string Title
            {
                get
                {
                    return this.title;
                }
            }

            public string Content
            {
                get
                {
                    return this.content;
                }
            }

        #endregion

        #region ModelGoogleSearchResult : Events

        #endregion

        #region ModelGoogleSearchResult : Event Handlers

        #endregion

        #region ModelGoogleSearchResult : Methods

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIGoogleSearchResult : GUIItem
    {
        #region GUIGoogleSearchResult : Members & Consts
            
            private string url;
            private string title;
            private string content;

        #endregion

        #region GUIGoogleSearchResult : Initialization

            public GUIGoogleSearchResult(string url, string title, string content)
            {
                this.url = url;
                this.title = title;
                this.content = content;
            }

        #endregion

            #region GUIGoogleSearchResult : Properties

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

        #region GUIGoogleSearchResult : Events

        #endregion

        #region GUIGoogleSearchResult : Event Handlers

        #endregion

        #region GUIGoogleSearchResult : Methods

        #endregion
    }
}

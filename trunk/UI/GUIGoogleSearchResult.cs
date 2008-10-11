using System;
using System.Collections.Generic;
using System.Text;

namespace UI
{
    public class GUIGoogleSearchResult : GUIItem
    {
        #region GUIGoogleSearchResult : Members & Consts
            
            /// <summary>
            /// 
            /// </summary>
            private string url;
            /// <summary>
            /// 
            /// </summary>
            private string title;
            /// <summary>
            /// 
            /// </summary>
            private string content;

        #endregion

        #region GUIGoogleSearchResult : Initialization

            /// <summary>
            /// 
            /// </summary>
            /// <param name="url"></param>
            /// <param name="title"></param>
            /// <param name="content"></param>
            public GUIGoogleSearchResult(string url, string title, string content)
            {
                this.url = url;
                this.title = title;
                this.content = content;
            }

        #endregion

        #region GUIGoogleSearchResult : Properties

            /// <summary>
            /// 
            /// </summary>
            public string URL
            {
                get
                {
                    return this.url;
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
            }
            
            /// <summary>
            /// 
            /// </summary>
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

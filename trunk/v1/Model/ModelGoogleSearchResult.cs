using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ModelGoogleSearchResult : ModelItem
    {
        #region ModelGoogleSearchResult : Members & Consts

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

        #region ModelGoogleSearchResult : Initialization
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="url"></param>
            /// <param name="title"></param>
            /// <param name="content"></param>
            public ModelGoogleSearchResult(string url, string title, string content)
            {
                this.url = url;
                this.title = title;
                this.content = content;
            }

        #endregion

        #region ModelGoogleSearchResult : Properties

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

        #region ModelGoogleSearchResult : Events

        #endregion

        #region ModelGoogleSearchResult : Event Handlers

        #endregion

        #region ModelGoogleSearchResult : Methods

        #endregion
    }
}

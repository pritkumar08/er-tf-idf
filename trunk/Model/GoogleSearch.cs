using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gapi.Search;

namespace Model
{
    class GoogleSearch
    {
        #region GoogleSearch : Members & Consts

            private const int TOTAL_RESULT_NUMBER = 200;

        #endregion

        #region GoogleSearch : Properties

        #endregion

        #region GoogleSearch : Events

        #endregion

        #region GoogleSearch : Event Handlers

        #endregion

        #region GoogleSearch : Methods

            internal static LinkedList<ModelGoogleSearchResult> PerformGoogleSearch(string label)
            {
                LinkedList<ModelGoogleSearchResult> resultList = new LinkedList<ModelGoogleSearchResult>();
                SearchResults results = Searcher.Search(SearchType.Web, label);
                try
                {
                    for (int i = 8; i < TOTAL_RESULT_NUMBER; i += 8)
                    {
                        foreach (SearchResult res in results.Items)
                        {
                            ModelGoogleSearchResult googleRes = new ModelGoogleSearchResult(res.Url, res.Title, res.Content);
                            resultList.AddLast(googleRes);
                        }
                        results = Searcher.Search(SearchType.Web, label, i);
                    }
                    return resultList;
                }
                catch
                {
                    return resultList;
                }
            }

        #endregion
    }
}

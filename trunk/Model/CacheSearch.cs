using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using UrlHistoryLibrary;

namespace Model
{
    public class CacheSearch
    {
        #region CacheSearch : Members & Consts

            private const int ERROR_FILE_NOT_FOUND = 2;

        #endregion

        #region CacheSearch : Properties

        #endregion

        #region CacheSearch : Events

        #endregion

        #region CacheSearch : Event Handlers

        #endregion

        #region CacheSearch : Methods

            [DllImport("Wininet.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern Boolean GetUrlCacheEntryInfo(String lpxaUrlName, IntPtr lpCacheEntryInfo, ref int lpdwCacheEntryInfoBufferSize);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="fileUrl"></param>
            /// <returns></returns>
            //private static string GetPathForCachedFile(string fileUrl)
            //{
            //    int cacheEntryInfoBufferSize = 0;
            //    IntPtr cacheEntryInfoBuffer = IntPtr.Zero;
            //    int lastError; Boolean result;
            //    try
            //    {
            //        // call to see how big the buffer needs to be
            //        result = GetUrlCacheEntryInfo(fileUrl, IntPtr.Zero, ref cacheEntryInfoBufferSize);
            //        lastError = Marshal.GetLastWin32Error();
            //        if (result == false)
            //        {
            //            if (lastError == ERROR_FILE_NOT_FOUND) return null;
            //        }
            //        // allocate the necessary amount of memory
            //        cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);

            //        // make call again with properly sized buffer
            //        result = GetUrlCacheEntryInfo(fileUrl, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSize);
            //        lastError = Marshal.GetLastWin32Error();
            //        if (result == true)
            //        {
            //            Object strObj = Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(CacheEntryInfo));
            //            CacheEntryInfo internetCacheEntry = (CacheEntryInfo)strObj;
            //            String localFileName = Marshal.PtrToStringAuto(internetCacheEntry.lpszLocalFileName); return localFileName;
            //        }
            //        else return null;// file not found
            //    }
            //    finally
            //    {
            //        if (!cacheEntryInfoBuffer.Equals(IntPtr.Zero)) Marshal.FreeHGlobal(cacheEntryInfoBuffer);
            //    }
            //}

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static Dictionary<string, string> CacheWebAddresses()
            {
                Dictionary<string, string> addDic = new Dictionary<string, string>();
                UrlHistoryWrapperClass urlHistory = new UrlHistoryWrapperClass();
                UrlHistoryWrapperClass.STATURLEnumerator enumerator = urlHistory.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if ((!addDic.Keys.Contains(enumerator.Current.URL)) && 
                        (enumerator.Current.URL.StartsWith("http")) && 
                        (!(enumerator.Current.URL.EndsWith(".exe"))))
                    {
                        addDic.Add(enumerator.Current.URL, enumerator.Current.Title);
                    }                        
                }
                return addDic;
            }

        #endregion
       
    }
}

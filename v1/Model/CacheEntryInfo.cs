using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices.ComTypes;

namespace Model
{
    class CacheEntryInfo
    {
        #region CacheEntryInfo : Members & Consts

            public int dwStructSize;
            public IntPtr lpszLocalFileName;

            private int CacheEntryType;
            private int dwUseCount;
            private int dwHitRate;
            private int dwSizeLow;
            private int dwSizeHigh;
            private int dwheaderInfoSize;
            private int dwEemptDelta;
            private FILETIME LastModifiedTime;
            private FILETIME Expiretime;
            private FILETIME LastAccessTime;
            private FILETIME LastSyncTime;
            private IntPtr lpHeaderInfo;
            private IntPtr lpszSourceUrlName;
            private IntPtr lpszFileExtension;
            
        #endregion

        #region CacheEntryInfo : Properties

        #endregion

        #region CacheEntryInfo : Events

        #endregion

        #region CacheEntryInfo : Event Handlers

        #endregion

        #region CacheEntryInfo : Methods

        #endregion
    }
}

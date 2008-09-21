using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class CacheDataForm : Form
    {
        #region CacheDataForm : Members & Consts

            Dictionary<string, string> cacheAddress;
            
        #endregion

        #region CacheDataForm : Initialization

            public CacheDataForm(Dictionary<string,string> cacheAddress)
            {
                InitializeComponent();
                this.cacheAddress = cacheAddress;
                FillList();
            }

        #endregion

        #region CacheDataForm : Properties

        #endregion

        #region CacheDataForm : Events

        #endregion

        #region CacheDataForm : Events Handlers

            private void CacheDataForm_Resize(object sender, EventArgs e)
            {
                lstvwCache.Columns[0].Width = (int) this.Width / 3;
                lstvwCache.Columns[1].Width = (int) 2 * this.Width / 3 - 10;
            }

        #endregion

        #region CacheDataForm : Methods

            private void FillList()
            {
                foreach (string link in cacheAddress.Keys)
                {
                    string title = "";
                    cacheAddress.TryGetValue(link, out title);
                    ListViewItem item = new ListViewItem(title);
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(link,Color.Blue,Color.WhiteSmoke,new Font(item.Font.FontFamily,(float)8.0, FontStyle.Underline));
                    lstvwCache.Items.Add(item);
                }
            }

        #endregion

    }
}

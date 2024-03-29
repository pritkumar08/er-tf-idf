﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class SearchForm : Form
    {
       
        #region GUIParagraph : Members & Consts

            /// <summary>
            /// 
            /// </summary>
            private LinkedList<GUIGoogleSearchResult> googleResults;
            /// <summary>
            /// 
            /// </summary>
            private int currentIndex = 0;
            /// <summary>
            /// 
            /// </summary>
            private const int LEFT_POSITION = 10;
            /// <summary>
            /// 
            /// </summary>
            private const int RESULTS_PER_PAGE = 10;
            
        #endregion

        #region GUIParagraph : Initialization

            /// <summary>
            /// 
            /// </summary>
            /// <param name="googleResults"></param>
            /// <param name="formCaption"></param>
            public SearchForm(LinkedList<GUIGoogleSearchResult> googleResults, string formCaption)
            {
                InitializeComponent();
                this.googleResults = googleResults;
                this.Text = formCaption;
                if (this.googleResults.Count < RESULTS_PER_PAGE)
                    btnNext.Enabled = false;
                PrintResult(0);
            }

        #endregion

        #region GUIParagraph : Properties

        #endregion

        #region GUIParagraph : Events

        #endregion

        #region GUIParagraph : Event Handlers
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnNext_Click(object sender, EventArgs e)
            {
                PrintResult(currentIndex + RESULTS_PER_PAGE);
                currentIndex += RESULTS_PER_PAGE;
                btnPrev.Enabled = true;
                if (currentIndex + RESULTS_PER_PAGE > googleResults.Count)
                    btnNext.Enabled = false;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnPrev_Click(object sender, EventArgs e)
            {
                PrintResult(currentIndex - RESULTS_PER_PAGE);
                currentIndex -= RESULTS_PER_PAGE;
                if (currentIndex == 0)
                    btnPrev.Enabled = false;
                if (currentIndex < googleResults.Count)
                    btnNext.Enabled = true;
            }

        #endregion

        #region GUIParagraph : Methods

            /// <summary>
            /// 
            /// </summary>
            /// <param name="index"></param>
            private void PrintResult(int index)
            {
                int i = 0, height = 10;
                pnlResults.Controls.Clear();
                foreach (GUIGoogleSearchResult res in googleResults)
                {
                    if (i < index)
                    {
                        i++;
                        continue;
                    }

                    if (i >= index + RESULTS_PER_PAGE)
                    {
                        return;
                    }
                     
                    LinkLabel title = new LinkLabel();
                    title.Text = RemoveTags(res.Title);
                    title.AutoSize = true;
                    title.Font = new Font(title.Font.FontFamily, 12);
                    title.Location = new Point(LEFT_POSITION, height);
                    height += title.Height;
                    pnlResults.Controls.Add(title);

                    Label content = new Label();
                    content.Text = RemoveTags(res.Content);
                    content.AutoSize = true;
                    content.Font = new Font(title.Font.FontFamily, 10);
                    content.Location = new Point(LEFT_POSITION, height);
                    height += content.Height;
                    pnlResults.Controls.Add(content);

                    Label url = new Label();
                    url.Text = res.URL;
                    url.AutoSize = true;
                    url.ForeColor = Color.Green;
                    url.Font = new Font(title.Font.FontFamily, 10);
                    url.Location = new Point(LEFT_POSITION, height);
                    height += url.Height + 10;
                    pnlResults.Controls.Add(url);
                    i++;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="text"></param>
            /// <returns></returns>
            private string RemoveTags(string text)
            {
                string s = text.Replace("<b>", "");
                s = s.Replace("</b>","");
                return s;
            }

        #endregion

            
           
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class cntHeader : UserControl
    {
        #region cntHeader : Members & Consts

            /// <summary>
            /// 
            /// </summary>
            private GUIHeader header = null;
            /// <summary>
            /// 
            /// </summary>
            private int parentParagraphID;

        #endregion

        #region cntHeader : Initialization

            /// <summary>
            /// 
            /// </summary>
            /// <param name="parentID"></param>
            public cntHeader(int parentID)
            {
                InitializeComponent();
                header = new GUIHeader("",0.00000);
                this.parentParagraphID = parentID;
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="header"></param>
            /// <param name="parentID"></param>
            internal cntHeader(GUIHeader header, int parentID)
            {
                InitializeComponent();
                this.header = header;
                this.parentParagraphID = parentID;
            }

        #endregion

        #region cntHeader : Enums

        #endregion

        #region cntHeader : Properties

            /// <summary>
            /// 
            /// </summary>
            internal GUIHeader ControlHeader
            {
                get
                {
                    if (this.header != null)
                    {
                        this.header.GUIDocumentItemText = richTextBody.Text;
                        this.header.GUIDocumentItemWeight = Double.Parse(numudWeight.Value.ToString());
                        return this.header;
                    }
                    return null;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            internal bool RemoveMe
            {
                get
                {
                    return chkbxHeaderRemove.Checked;
                }
            }
            
            /// <summary>
            /// 
            /// </summary>
            internal int ParentID
            {
                get
                {
                    return this.parentParagraphID;
                }
            }

        #endregion

        #region cntHeader : Events

        #endregion

        #region cntHeader : EventHandlers

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void cntHeader_Load(object sender, EventArgs e)
            {
                if (header != null)
                {
                    richTextBody.Text = header.GUIDocumentItemText;
                    numudWeight.Value = decimal.Parse(header.GUIDocumentItemWeight.ToString());
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void cntHeader_Resize(object sender, EventArgs e)
            {
                richTextBody.Width = this.Width - 15;
                numudWeight.Left = this.Width - numudWeight.Width - 15;
                lblHeaderWeight.Left = numudWeight.Left - lblHeaderWeight.Width - 15;
            }

        #endregion

        #region cntHeader : Methods

        #endregion
    }
}

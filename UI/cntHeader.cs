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

            private GUIHeader header = null;
            private int parentParagraphID;

        #endregion

        #region cntHeader : Initialization

            public cntHeader(int parentID)
            {
                InitializeComponent();
                header = new GUIHeader("",0.00000);
                this.parentParagraphID = parentID;
            }

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

            internal bool RemoveMe
            {
                get
                {
                    return chkbxHeaderRemove.Checked;
                }
            }

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

            private void cntHeader_Load(object sender, EventArgs e)
            {
                if (header != null)
                {
                    richTextBody.Text = header.GUIDocumentItemText;
                    numudWeight.Value = decimal.Parse(header.GUIDocumentItemWeight.ToString());
                }
            }

        #endregion

        #region cntHeader : Methods

        #endregion
    }
}

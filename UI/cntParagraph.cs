using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class cntParagraph : UserControl
    {
        #region cntParagraph : Members & Consts

            private GUIParagraph paragraph = null;
            private int parentParagraphID;

        #endregion

        #region cntParagraph : Initialization

            public cntParagraph(int id, int parentID)
            {
                InitializeComponent();
                paragraph = new GUIParagraph("", id, 0.00000);
                this.parentParagraphID = parentID;
            }

            internal cntParagraph(GUIParagraph paragraph, int parentID)
            {
                InitializeComponent();
                this.paragraph = paragraph;
                this.parentParagraphID = parentID;
            }

        #endregion

        #region cntParagraph : Enums
            
            public enum CntParagraphActions
            {
                Add_Paragraph = 0,
                Add_Header = 1,
                Remove_Paragraph = 2,
                Remove_Header = 3
            };
            
        #endregion

        #region cntParagraph : Properties

            internal GUIParagraph ControlParagraph
            {
                get
                {
                    if (this.paragraph != null)
                        return this.paragraph;
                    return null;
                }
            }

            internal bool RemoveMe
            {
                get
                {
                    return chckRemove.Checked;
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

        #region cntParagraph : Delegates

            public delegate Object[] CntParagraphEventHandler(CntParagraphActions action, Object[] parameters);

        #endregion

        #region cntParagraph : Events

            public event CntParagraphEventHandler CntParagraphEvent;

        #endregion

        #region cntParagraph : EventHandlers

            protected virtual Object[] OnMakingAction(CntParagraphActions action, Object[] parameters)
            {
                if (CntParagraphEvent != null)
                    return CntParagraphEvent(action, parameters);
                return null;
            }

            private void cntParagraph_Load(object sender, EventArgs e)
            {
                if (paragraph != null)
                {
                    lblID.Text = paragraph.GUIParagraphID.ToString();
                    richTextBody.Text = paragraph.GUIParagraphBody;
                    numudWeight.Value = decimal.Parse(paragraph.GUIDocumentItemWeight.ToString());
                }
            }

            private void btnAddHeader_Click(object sender, EventArgs e)
            {
                OnMakingAction(CntParagraphActions.Add_Header, new Object[] {this.Left,this.paragraph.GUIParagraphID });
            }

            private void btnAddParagraph_Click(object sender, EventArgs e)
            {
                OnMakingAction(CntParagraphActions.Add_Paragraph, new Object[] {this.Left, this.paragraph.GUIParagraphID});
            }


        #endregion

        #region cntParagraph : Methods

        #endregion
    }
}

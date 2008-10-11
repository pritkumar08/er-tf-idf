using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class SimilarityForm : Form
    {
        #region SimilarityForm : Members & Consts

            private SearchEngine engine = SearchEngine.Google;

            private SimilarityType sType = SimilarityType.None;

            private SortingMethod sMethod = SortingMethod.None;

        #endregion

        #region SimilarityForm : Initialization

            public SimilarityForm()
            {
                InitializeComponent();
            }

        #endregion

        #region SimilarityForm : Enums

            public enum SimilarityFormActions
            {
                Reorder = 0
            }

            public enum SearchEngine
            {
                Google = 0
            }

            public enum SimilarityType
            {
                None = 0,
                L2_Norm = 1,
                Min_Val = 2
            };

            public enum SortingMethod
            {
                None = 0,
                Maximum = 1,
                Summary = 2
            };

        #endregion

        #region SimilarityForm : Properties

        #endregion

        #region SimilarityForm : Events

            public event SimilarityFormEventHandler SimilarityFormEvent;

        #endregion

        #region SimilarityForm : Delegates

            public delegate Object[] SimilarityFormEventHandler(SimilarityFormActions action, Object[] parameters);

        #endregion

        #region SimilarityForm : EventHandler

            protected virtual Object[] OnRequestForInformation(SimilarityFormActions action, Object[] parameter)
            {
                if (SimilarityFormEvent != null)
                    return SimilarityFormEvent(action, parameter);
                return null;
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnCheck_Click(object sender, EventArgs e)
            {
                this.Visible = false;
                OnRequestForInformation(SimilarityFormActions.Reorder, 
                    new Object[] {txtSearch.Text ,engine, sType, 
                        (int)nmudPages.Value ,chckViewGoogleSearch.Checked, sMethod});
                this.Close();
            }

            private void cmbxEngine_SelectedIndexChanged(object sender, EventArgs e)
            {
                cmbxSimilarity.Enabled = true;
            }

            private void cmbxSimilarity_SelectedIndexChanged(object sender, EventArgs e)
            {
                cmbxSortingMethod.Enabled = true;
                switch (cmbxSimilarity.SelectedItem.ToString())
                {
                    case "L2 Norm":
                        sType = SimilarityType.L2_Norm;
                        break;
                    case "Minimum Value":
                        sType = SimilarityType.Min_Val;
                        break;
                }
            }

            private void cmbxSortingMethod_SelectedIndexChanged(object sender, EventArgs e)
            {
                nmudPages.Enabled = true;
                switch (cmbxSortingMethod.SelectedItem.ToString())
                {
                    case "By Maximum":
                        sMethod = SortingMethod.Maximum;
                        break;
                    case "By Summary":
                        sMethod = SortingMethod.Summary;
                        break;
                }
            }

            private void nmudPages_ValueChanged(object sender, EventArgs e)
            {
                if (nmudPages.Value > 0)
                    btnReorder.Enabled = true;
            }

            private void nmudPages_KeyDown(object sender, KeyEventArgs e)
            {
                if (nmudPages.Value > 0)
                    btnReorder.Enabled = true;
            }

        #endregion

        #region SimilarityForm : Methods

        #endregion

    }
}

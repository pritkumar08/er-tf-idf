using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class ImportWebDocumentForm : Form
    {

        #region ImportWebDocumentForm : Members & Consts

        #endregion

        #region ImportWebDocumentForm : Initialization

            public ImportWebDocumentForm()
            {
                InitializeComponent();
            }

        #endregion

        #region ImportWebDocumentForm : Enums

            public enum ImportWebDocumentFormActions
            {
                Import_Web_Document = 0
            }

        #endregion

        #region ImportWebDocumentForm : Delegates
            public delegate Object[] 
                ImportWebDocumentFormEventHandler(ImportWebDocumentFormActions action, Object[] parameters);
        #endregion

        #region ImportWebDocumentForm : Events
            public event ImportWebDocumentFormEventHandler ImportWebDocumentFormEvent;
        #endregion

        #region ImportWebDocumentForm : Event Handlars

            protected virtual Object[] OnRequestForInformation(ImportWebDocumentFormActions action, Object[] parameter)
            {
                if (ImportWebDocumentFormEvent != null)
                    return ImportWebDocumentFormEvent(action, parameter);
                return null;
            }

            private void btnOk_Click(object sender, EventArgs e)
            {
                OpenWebDocument();
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void txtAddress_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    OpenWebDocument();
                }
            }

        #endregion

        #region ImportWebDocumentForm : Methods

            private void OpenWebDocument()
            {
                string address = TranslateAddress(txtAddress.Text);
                if (address != null)
                {
                    this.Visible = false;
                    OnRequestForInformation(ImportWebDocumentFormActions.Import_Web_Document, new Object[] { address });
                    this.Close();
                }
                else
                    MessageBox.Show(this, "The web address is not in the correct format, \nPlease change it and try once again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            private string TranslateAddress(string address)
            {
                if (address.StartsWith("www."))
                {
                    return "http://" + address;
                }
                if (address.StartsWith("http://www."))
                    return address;
                else
                    return null;
            }

        #endregion

    }
}

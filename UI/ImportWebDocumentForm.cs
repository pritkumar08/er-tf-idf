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

            /// <summary>
            /// 
            /// </summary>
            public ImportWebDocumentForm()
            {
                InitializeComponent();
            }

        #endregion

        #region ImportWebDocumentForm : Enums
            
            /// <summary>
            /// 
            /// </summary>
            public enum ImportWebDocumentFormActions
            {
                Import_Web_Document = 0
            }

        #endregion

        #region ImportWebDocumentForm : Delegates
            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            public delegate Object[] 
                ImportWebDocumentFormEventHandler(ImportWebDocumentFormActions action, Object[] parameters);
        #endregion

        #region ImportWebDocumentForm : Events
        
            /// <summary>
            /// 
            /// </summary>
            public event ImportWebDocumentFormEventHandler ImportWebDocumentFormEvent;

        #endregion

        #region ImportWebDocumentForm : Event Handlars

            /// <summary>
            /// 
            /// </summary>
            /// <param name="action"></param>
            /// <param name="parameter"></param>
            /// <returns></returns>
            protected virtual Object[] OnRequestForInformation(ImportWebDocumentFormActions action, Object[] parameter)
            {
                if (ImportWebDocumentFormEvent != null)
                    return ImportWebDocumentFormEvent(action, parameter);
                return null;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnOk_Click(object sender, EventArgs e)
            {
                OpenWebDocument();
            }
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void txtAddress_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    OpenWebDocument();
                }
            }

        #endregion

        #region ImportWebDocumentForm : Methods
    
            /// <summary>
            /// 
            /// </summary>
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
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

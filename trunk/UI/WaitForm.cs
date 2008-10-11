using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class WaitForm : Form
    {

        #region WaitForm : Members & Consts
        #endregion

        #region WaitForm : Initialization

            /// <summary>
            /// The wait form constructor
            /// </summary>
            /// <param name="caption">The caption of the form.</param>
            /// <param name="description">The description written under the image.</param>
            public WaitForm(string caption, string description)
            {
                InitializeComponent();
                this.Text = caption;
                lblWait.Text = description;
            }

        #endregion

        #region WaitForm : Properties

        #endregion

        #region WaitForm : Events

            /// <summary>
            /// The form closing event.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        #endregion
    }
}

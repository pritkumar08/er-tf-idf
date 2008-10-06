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

            private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }

        #endregion
    }
}

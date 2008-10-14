namespace UI
{
    partial class ImportWebDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportWebDocumentForm));
            this.picOpenDoc = new System.Windows.Forms.PictureBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblOpen = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picOpenDoc)).BeginInit();
            this.SuspendLayout();
            // 
            // picOpenDoc
            // 
            this.picOpenDoc.Image = ((System.Drawing.Image)(resources.GetObject("picOpenDoc.Image")));
            this.picOpenDoc.Location = new System.Drawing.Point(2, 8);
            this.picOpenDoc.Name = "picOpenDoc";
            this.picOpenDoc.Size = new System.Drawing.Size(78, 65);
            this.picOpenDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOpenDoc.TabIndex = 0;
            this.picOpenDoc.TabStop = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(88, 12);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(366, 31);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Type the Internet address of the document, and the Text Comparer will open it for" +
                " you.";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(298, 87);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(379, 87);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblOpen
            // 
            this.lblOpen.AutoSize = true;
            this.lblOpen.Location = new System.Drawing.Point(88, 56);
            this.lblOpen.Name = "lblOpen";
            this.lblOpen.Size = new System.Drawing.Size(36, 13);
            this.lblOpen.TabIndex = 4;
            this.lblOpen.Text = "Open:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(130, 53);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(324, 20);
            this.txtAddress.TabIndex = 5;
            this.txtAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddress_KeyDown);
            // 
            // ImportWebDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(459, 115);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblOpen);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.picOpenDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportWebDocumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Web Document";
            ((System.ComponentModel.ISupportInitialize)(this.picOpenDoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picOpenDoc;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblOpen;
        private System.Windows.Forms.TextBox txtAddress;
    }
}
namespace UI
{
    partial class cntHeader
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numudWeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeaderWeight = new System.Windows.Forms.Label();
            this.richTextBody = new System.Windows.Forms.RichTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.chkbxHeaderRemove = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // numudWeight
            // 
            this.numudWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numudWeight.DecimalPlaces = 5;
            this.numudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numudWeight.Location = new System.Drawing.Point(571, 13);
            this.numudWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numudWeight.Name = "numudWeight";
            this.numudWeight.Size = new System.Drawing.Size(88, 20);
            this.numudWeight.TabIndex = 11;
            // 
            // lblHeaderWeight
            // 
            this.lblHeaderWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeaderWeight.AutoSize = true;
            this.lblHeaderWeight.Location = new System.Drawing.Point(466, 15);
            this.lblHeaderWeight.Name = "lblHeaderWeight";
            this.lblHeaderWeight.Size = new System.Drawing.Size(85, 13);
            this.lblHeaderWeight.TabIndex = 10;
            this.lblHeaderWeight.Text = "Header Weight :";
            // 
            // richTextBody
            // 
            this.richTextBody.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.richTextBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBody.Location = new System.Drawing.Point(16, 41);
            this.richTextBody.Name = "richTextBody";
            this.richTextBody.Size = new System.Drawing.Size(643, 44);
            this.richTextBody.TabIndex = 8;
            this.richTextBody.Text = "";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblHeader.Location = new System.Drawing.Point(13, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(48, 13);
            this.lblHeader.TabIndex = 9;
            this.lblHeader.Text = "Header";
            // 
            // chkbxHeaderRemove
            // 
            this.chkbxHeaderRemove.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkbxHeaderRemove.AutoSize = true;
            this.chkbxHeaderRemove.Location = new System.Drawing.Point(16, 101);
            this.chkbxHeaderRemove.Name = "chkbxHeaderRemove";
            this.chkbxHeaderRemove.Size = new System.Drawing.Size(104, 17);
            this.chkbxHeaderRemove.TabIndex = 12;
            this.chkbxHeaderRemove.Text = "Remove Header";
            this.chkbxHeaderRemove.UseVisualStyleBackColor = true;
            // 
            // cntHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chkbxHeaderRemove);
            this.Controls.Add(this.numudWeight);
            this.Controls.Add(this.lblHeaderWeight);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.richTextBody);
            this.Name = "cntHeader";
            this.Size = new System.Drawing.Size(678, 131);
            this.Load += new System.EventHandler(this.cntHeader_Load);
            this.Resize += new System.EventHandler(this.cntHeader_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numudWeight;
        private System.Windows.Forms.Label lblHeaderWeight;
        private System.Windows.Forms.RichTextBox richTextBody;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox chkbxHeaderRemove;
    }
}

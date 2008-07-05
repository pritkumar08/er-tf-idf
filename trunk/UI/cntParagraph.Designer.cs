namespace UI
{
    partial class cntParagraph
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
            this.richTextBody = new System.Windows.Forms.RichTextBox();
            this.lblParagraphID = new System.Windows.Forms.Label();
            this.btnAddHeader = new System.Windows.Forms.Button();
            this.btnAddParagraph = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.lblParagraphWeight = new System.Windows.Forms.Label();
            this.numudWeight = new System.Windows.Forms.NumericUpDown();
            this.chckRemove = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBody
            // 
            this.richTextBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBody.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.richTextBody.Location = new System.Drawing.Point(19, 38);
            this.richTextBody.Name = "richTextBody";
            this.richTextBody.Size = new System.Drawing.Size(607, 115);
            this.richTextBody.TabIndex = 0;
            this.richTextBody.Text = "";
            // 
            // lblParagraphID
            // 
            this.lblParagraphID.AutoSize = true;
            this.lblParagraphID.Location = new System.Drawing.Point(16, 9);
            this.lblParagraphID.Name = "lblParagraphID";
            this.lblParagraphID.Size = new System.Drawing.Size(73, 13);
            this.lblParagraphID.TabIndex = 1;
            this.lblParagraphID.Text = "Paragraph ID:";
            // 
            // btnAddHeader
            // 
            this.btnAddHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddHeader.Location = new System.Drawing.Point(436, 158);
            this.btnAddHeader.Name = "btnAddHeader";
            this.btnAddHeader.Size = new System.Drawing.Size(96, 23);
            this.btnAddHeader.TabIndex = 2;
            this.btnAddHeader.Text = "Add Header";
            this.btnAddHeader.UseVisualStyleBackColor = true;
            this.btnAddHeader.Click += new System.EventHandler(this.btnAddHeader_Click);
            // 
            // btnAddParagraph
            // 
            this.btnAddParagraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddParagraph.Location = new System.Drawing.Point(538, 158);
            this.btnAddParagraph.Name = "btnAddParagraph";
            this.btnAddParagraph.Size = new System.Drawing.Size(88, 23);
            this.btnAddParagraph.TabIndex = 3;
            this.btnAddParagraph.Text = "Add Paragraph";
            this.btnAddParagraph.UseVisualStyleBackColor = true;
            this.btnAddParagraph.Click += new System.EventHandler(this.btnAddParagraph_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblID.Location = new System.Drawing.Point(95, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(14, 13);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "0";
            // 
            // lblParagraphWeight
            // 
            this.lblParagraphWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParagraphWeight.AutoSize = true;
            this.lblParagraphWeight.Location = new System.Drawing.Point(433, 9);
            this.lblParagraphWeight.Name = "lblParagraphWeight";
            this.lblParagraphWeight.Size = new System.Drawing.Size(99, 13);
            this.lblParagraphWeight.TabIndex = 5;
            this.lblParagraphWeight.Text = "Paragraph Weight :";
            // 
            // numudWeight
            // 
            this.numudWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numudWeight.DecimalPlaces = 5;
            this.numudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numudWeight.Location = new System.Drawing.Point(538, 7);
            this.numudWeight.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numudWeight.Name = "numudWeight";
            this.numudWeight.Size = new System.Drawing.Size(88, 20);
            this.numudWeight.TabIndex = 6;
            // 
            // chckRemove
            // 
            this.chckRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chckRemove.AutoSize = true;
            this.chckRemove.Location = new System.Drawing.Point(19, 164);
            this.chckRemove.Name = "chckRemove";
            this.chckRemove.Size = new System.Drawing.Size(118, 17);
            this.chckRemove.TabIndex = 7;
            this.chckRemove.Text = "Remove Paragraph";
            this.chckRemove.UseVisualStyleBackColor = true;
            // 
            // cntParagraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chckRemove);
            this.Controls.Add(this.numudWeight);
            this.Controls.Add(this.lblParagraphWeight);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAddParagraph);
            this.Controls.Add(this.btnAddHeader);
            this.Controls.Add(this.lblParagraphID);
            this.Controls.Add(this.richTextBody);
            this.Name = "cntParagraph";
            this.Size = new System.Drawing.Size(640, 188);
            this.Load += new System.EventHandler(this.cntParagraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBody;
        private System.Windows.Forms.Label lblParagraphID;
        private System.Windows.Forms.Button btnAddHeader;
        private System.Windows.Forms.Button btnAddParagraph;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblParagraphWeight;
        private System.Windows.Forms.NumericUpDown numudWeight;
        private System.Windows.Forms.CheckBox chckRemove;
    }
}

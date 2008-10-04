namespace UI
{
    partial class SimilarityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimilarityForm));
            this.btnReorder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.nmudPages = new System.Windows.Forms.NumericUpDown();
            this.lblResultsNumber = new System.Windows.Forms.Label();
            this.cmbxSimilarity = new System.Windows.Forms.ComboBox();
            this.lblSimAlgo = new System.Windows.Forms.Label();
            this.cmbxEngine = new System.Windows.Forms.ComboBox();
            this.lblSearchEngine = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.grpSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudPages)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReorder
            // 
            this.btnReorder.Enabled = false;
            this.btnReorder.Location = new System.Drawing.Point(246, 182);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(75, 23);
            this.btnReorder.TabIndex = 0;
            this.btnReorder.Text = "Reorder";
            this.btnReorder.UseVisualStyleBackColor = true;
            this.btnReorder.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(331, 182);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.nmudPages);
            this.grpSettings.Controls.Add(this.lblResultsNumber);
            this.grpSettings.Controls.Add(this.cmbxSimilarity);
            this.grpSettings.Controls.Add(this.lblSimAlgo);
            this.grpSettings.Controls.Add(this.cmbxEngine);
            this.grpSettings.Controls.Add(this.lblSearchEngine);
            this.grpSettings.Controls.Add(this.txtSearch);
            this.grpSettings.Controls.Add(this.lblSearchTitle);
            this.grpSettings.Location = new System.Drawing.Point(12, 13);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(394, 161);
            this.grpSettings.TabIndex = 2;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Configure Similarity Check";
            // 
            // nmudPages
            // 
            this.nmudPages.Enabled = false;
            this.nmudPages.Location = new System.Drawing.Point(128, 120);
            this.nmudPages.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmudPages.Name = "nmudPages";
            this.nmudPages.Size = new System.Drawing.Size(50, 20);
            this.nmudPages.TabIndex = 7;
            this.nmudPages.ValueChanged += new System.EventHandler(this.nmudPages_ValueChanged);
            this.nmudPages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nmudPages_KeyDown);
            // 
            // lblResultsNumber
            // 
            this.lblResultsNumber.AutoSize = true;
            this.lblResultsNumber.Location = new System.Drawing.Point(12, 122);
            this.lblResultsNumber.Name = "lblResultsNumber";
            this.lblResultsNumber.Size = new System.Drawing.Size(92, 13);
            this.lblResultsNumber.TabIndex = 6;
            this.lblResultsNumber.Text = "Number of Pages:";
            // 
            // cmbxSimilarity
            // 
            this.cmbxSimilarity.Enabled = false;
            this.cmbxSimilarity.FormattingEnabled = true;
            this.cmbxSimilarity.Items.AddRange(new object[] {
            "L2 Norm",
            "Minimum Value"});
            this.cmbxSimilarity.Location = new System.Drawing.Point(128, 88);
            this.cmbxSimilarity.Name = "cmbxSimilarity";
            this.cmbxSimilarity.Size = new System.Drawing.Size(133, 21);
            this.cmbxSimilarity.TabIndex = 5;
            this.cmbxSimilarity.Text = "Choose Algorithm...";
            this.cmbxSimilarity.SelectedIndexChanged += new System.EventHandler(this.cmbxSimilarity_SelectedIndexChanged);
            // 
            // lblSimAlgo
            // 
            this.lblSimAlgo.AutoSize = true;
            this.lblSimAlgo.Location = new System.Drawing.Point(12, 91);
            this.lblSimAlgo.Name = "lblSimAlgo";
            this.lblSimAlgo.Size = new System.Drawing.Size(96, 13);
            this.lblSimAlgo.TabIndex = 4;
            this.lblSimAlgo.Text = "Similarity Algorithm:";
            // 
            // cmbxEngine
            // 
            this.cmbxEngine.FormattingEnabled = true;
            this.cmbxEngine.Items.AddRange(new object[] {
            "Google Search..."});
            this.cmbxEngine.Location = new System.Drawing.Point(128, 57);
            this.cmbxEngine.Name = "cmbxEngine";
            this.cmbxEngine.Size = new System.Drawing.Size(133, 21);
            this.cmbxEngine.TabIndex = 3;
            this.cmbxEngine.Text = "Choose engine...";
            this.cmbxEngine.SelectedIndexChanged += new System.EventHandler(this.cmbxEngine_SelectedIndexChanged);
            // 
            // lblSearchEngine
            // 
            this.lblSearchEngine.AutoSize = true;
            this.lblSearchEngine.Location = new System.Drawing.Point(12, 60);
            this.lblSearchEngine.Name = "lblSearchEngine";
            this.lblSearchEngine.Size = new System.Drawing.Size(80, 13);
            this.lblSearchEngine.TabIndex = 2;
            this.lblSearchEngine.Text = "Search Engine:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(128, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(253, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Location = new System.Drawing.Point(12, 31);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(44, 13);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "Search:";
            // 
            // SimilarityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(416, 217);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReorder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SimilarityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Similarity Check Reorganization";
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmudPages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.ComboBox cmbxSimilarity;
        private System.Windows.Forms.Label lblSimAlgo;
        private System.Windows.Forms.ComboBox cmbxEngine;
        private System.Windows.Forms.Label lblSearchEngine;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.NumericUpDown nmudPages;
        private System.Windows.Forms.Label lblResultsNumber;
    }
}
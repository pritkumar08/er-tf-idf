namespace UI
{
    partial class CacheDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheDataForm));
            this.lstvwCache = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstvwCache
            // 
            this.lstvwCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvwCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstvwCache.Location = new System.Drawing.Point(0, 0);
            this.lstvwCache.Name = "lstvwCache";
            this.lstvwCache.Size = new System.Drawing.Size(728, 443);
            this.lstvwCache.TabIndex = 0;
            this.lstvwCache.UseCompatibleStateImageBehavior = false;
            this.lstvwCache.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Page Title";
            this.columnHeader1.Width = 285;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Page URL";
            this.columnHeader2.Width = 367;
            // 
            // CacheDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(728, 443);
            this.Controls.Add(this.lstvwCache);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CacheDataForm";
            this.Text = "IE Browser Cache Information";
            this.Resize += new System.EventHandler(this.CacheDataForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstvwCache;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}
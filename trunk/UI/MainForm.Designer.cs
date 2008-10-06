namespace UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.stsstpMain = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDocumentParagraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeDocumentItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importCacheDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCacheDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCacheDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evaluateSimilarityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reorganizeSearchResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlstpMain = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tlsbtnAddParagraph = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnInsertFile = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnSearchGoogle = new System.Windows.Forms.ToolStripButton();
            this.tlstptxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstpbtnCacheImporter = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnImportWebDocument = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnClearDB = new System.Windows.Forms.ToolStripButton();
            this.tlstpbtnCacheDatabase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlstpbtnSimilarity = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tlstpbtnOrganizeForms = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.tlstpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // stsstpMain
            // 
            this.stsstpMain.Location = new System.Drawing.Point(0, 365);
            this.stsstpMain.Name = "stsstpMain";
            this.stsstpMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.stsstpMain.Size = new System.Drawing.Size(535, 22);
            this.stsstpMain.TabIndex = 0;
            this.stsstpMain.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.documentToolStripMenuItem,
            this.dataToolStripMenuItem,
            this.evaluateSimilarityToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(535, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "munMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator2,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(137, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDocumentParagraphToolStripMenuItem,
            this.toolStripMenuItem1,
            this.removeDocumentItemsToolStripMenuItem});
            this.documentToolStripMenuItem.Enabled = false;
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.documentToolStripMenuItem.Text = "&Document";
            // 
            // addDocumentParagraphToolStripMenuItem
            // 
            this.addDocumentParagraphToolStripMenuItem.Enabled = false;
            this.addDocumentParagraphToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addDocumentParagraphToolStripMenuItem.Image")));
            this.addDocumentParagraphToolStripMenuItem.Name = "addDocumentParagraphToolStripMenuItem";
            this.addDocumentParagraphToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addDocumentParagraphToolStripMenuItem.Text = "Add Document Paragraph";
            this.addDocumentParagraphToolStripMenuItem.Click += new System.EventHandler(this.tlsbtnAddParagraph_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 6);
            // 
            // removeDocumentItemsToolStripMenuItem
            // 
            this.removeDocumentItemsToolStripMenuItem.Enabled = false;
            this.removeDocumentItemsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeDocumentItemsToolStripMenuItem.Image")));
            this.removeDocumentItemsToolStripMenuItem.Name = "removeDocumentItemsToolStripMenuItem";
            this.removeDocumentItemsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.removeDocumentItemsToolStripMenuItem.Text = "Remove Document Items...";
            this.removeDocumentItemsToolStripMenuItem.Click += new System.EventHandler(this.tlstpbtnRemove_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchGoogleToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importCacheDataToolStripMenuItem,
            this.importFromFileToolStripMenuItem,
            this.toolStripMenuItem3,
            this.clearCacheDatabaseToolStripMenuItem,
            this.createCacheDatabaseToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // searchGoogleToolStripMenuItem
            // 
            this.searchGoogleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchGoogleToolStripMenuItem.Image")));
            this.searchGoogleToolStripMenuItem.Name = "searchGoogleToolStripMenuItem";
            this.searchGoogleToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.searchGoogleToolStripMenuItem.Text = "Search Google";
            this.searchGoogleToolStripMenuItem.Click += new System.EventHandler(this.tlstpbtnSearchGoogle_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // importCacheDataToolStripMenuItem
            // 
            this.importCacheDataToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importCacheDataToolStripMenuItem.Image")));
            this.importCacheDataToolStripMenuItem.Name = "importCacheDataToolStripMenuItem";
            this.importCacheDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.importCacheDataToolStripMenuItem.Text = "View Cache Data...";
            this.importCacheDataToolStripMenuItem.Click += new System.EventHandler(this.tlstpbtnCacheImporter_Click);
            // 
            // importFromFileToolStripMenuItem
            // 
            this.importFromFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importFromFileToolStripMenuItem.Image")));
            this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
            this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.importFromFileToolStripMenuItem.Text = "Import From Web...";
            this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(186, 6);
            // 
            // clearCacheDatabaseToolStripMenuItem
            // 
            this.clearCacheDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearCacheDatabaseToolStripMenuItem.Image")));
            this.clearCacheDatabaseToolStripMenuItem.Name = "clearCacheDatabaseToolStripMenuItem";
            this.clearCacheDatabaseToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.clearCacheDatabaseToolStripMenuItem.Text = "Clear Cache Database";
            this.clearCacheDatabaseToolStripMenuItem.Click += new System.EventHandler(this.tlstpbtnClearDB_Click);
            // 
            // createCacheDatabaseToolStripMenuItem
            // 
            this.createCacheDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createCacheDatabaseToolStripMenuItem.Image")));
            this.createCacheDatabaseToolStripMenuItem.Name = "createCacheDatabaseToolStripMenuItem";
            this.createCacheDatabaseToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.createCacheDatabaseToolStripMenuItem.Text = "Create Cache Database";
            // 
            // evaluateSimilarityToolStripMenuItem
            // 
            this.evaluateSimilarityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reorganizeSearchResultsToolStripMenuItem});
            this.evaluateSimilarityToolStripMenuItem.Name = "evaluateSimilarityToolStripMenuItem";
            this.evaluateSimilarityToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.evaluateSimilarityToolStripMenuItem.Text = "Similarity";
            // 
            // reorganizeSearchResultsToolStripMenuItem
            // 
            this.reorganizeSearchResultsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reorganizeSearchResultsToolStripMenuItem.Image")));
            this.reorganizeSearchResultsToolStripMenuItem.Name = "reorganizeSearchResultsToolStripMenuItem";
            this.reorganizeSearchResultsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.reorganizeSearchResultsToolStripMenuItem.Text = "Reorganize Search Results...";
            this.reorganizeSearchResultsToolStripMenuItem.Click += new System.EventHandler(this.tlstpbtnSimilarity_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(175, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.aboutToolStripMenuItem.Text = "About Text Comparer";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tlstpMain
            // 
            this.tlstpMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.tlsbtnAddParagraph,
            this.tlstpbtnRemove,
            this.tlstpbtnInsertFile,
            this.tlstpbtnSearchGoogle,
            this.tlstptxtSearch,
            this.toolStripSeparator1,
            this.tlstpbtnCacheImporter,
            this.tlstpbtnImportWebDocument,
            this.tlstpbtnClearDB,
            this.tlstpbtnCacheDatabase,
            this.toolStripSeparator4,
            this.tlstpbtnSimilarity,
            this.tlstpbtnOrganizeForms});
            this.tlstpMain.Location = new System.Drawing.Point(0, 24);
            this.tlstpMain.Name = "tlstpMain";
            this.tlstpMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlstpMain.Size = new System.Drawing.Size(535, 25);
            this.tlstpMain.Stretch = true;
            this.tlstpMain.TabIndex = 0;
            this.tlstpMain.Text = "ToolStripMain";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // tlsbtnAddParagraph
            // 
            this.tlsbtnAddParagraph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlsbtnAddParagraph.Enabled = false;
            this.tlsbtnAddParagraph.Image = ((System.Drawing.Image)(resources.GetObject("tlsbtnAddParagraph.Image")));
            this.tlsbtnAddParagraph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnAddParagraph.Name = "tlsbtnAddParagraph";
            this.tlsbtnAddParagraph.Size = new System.Drawing.Size(23, 22);
            this.tlsbtnAddParagraph.ToolTipText = "Add Document Paragraph";
            this.tlsbtnAddParagraph.Click += new System.EventHandler(this.tlsbtnAddParagraph_Click);
            // 
            // tlstpbtnRemove
            // 
            this.tlstpbtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnRemove.Enabled = false;
            this.tlstpbtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnRemove.Image")));
            this.tlstpbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnRemove.Name = "tlstpbtnRemove";
            this.tlstpbtnRemove.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnRemove.ToolTipText = "Remove Documents Items";
            this.tlstpbtnRemove.Click += new System.EventHandler(this.tlstpbtnRemove_Click);
            // 
            // tlstpbtnInsertFile
            // 
            this.tlstpbtnInsertFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnInsertFile.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnInsertFile.Image")));
            this.tlstpbtnInsertFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnInsertFile.Name = "tlstpbtnInsertFile";
            this.tlstpbtnInsertFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tlstpbtnInsertFile.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnInsertFile.Text = "Insert File To Database";
            this.tlstpbtnInsertFile.Click += new System.EventHandler(this.tlstpbtnInsertFile_Click);
            // 
            // tlstpbtnSearchGoogle
            // 
            this.tlstpbtnSearchGoogle.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlstpbtnSearchGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnSearchGoogle.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnSearchGoogle.Image")));
            this.tlstpbtnSearchGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnSearchGoogle.Name = "tlstpbtnSearchGoogle";
            this.tlstpbtnSearchGoogle.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnSearchGoogle.Text = "Go >>";
            this.tlstpbtnSearchGoogle.Click += new System.EventHandler(this.tlstpbtnSearchGoogle_Click);
            // 
            // tlstptxtSearch
            // 
            this.tlstptxtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tlstptxtSearch.Name = "tlstptxtSearch";
            this.tlstptxtSearch.Size = new System.Drawing.Size(100, 25);
            this.tlstptxtSearch.Text = "Search Google...";
            this.tlstptxtSearch.Click += new System.EventHandler(this.tlstptxtSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstpbtnCacheImporter
            // 
            this.tlstpbtnCacheImporter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnCacheImporter.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnCacheImporter.Image")));
            this.tlstpbtnCacheImporter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnCacheImporter.Name = "tlstpbtnCacheImporter";
            this.tlstpbtnCacheImporter.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnCacheImporter.Text = "Import Cache";
            this.tlstpbtnCacheImporter.ToolTipText = "View IE Cache";
            this.tlstpbtnCacheImporter.Click += new System.EventHandler(this.tlstpbtnCacheImporter_Click);
            // 
            // tlstpbtnImportWebDocument
            // 
            this.tlstpbtnImportWebDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnImportWebDocument.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnImportWebDocument.Image")));
            this.tlstpbtnImportWebDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnImportWebDocument.Name = "tlstpbtnImportWebDocument";
            this.tlstpbtnImportWebDocument.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnImportWebDocument.Text = "toolStripButton1";
            this.tlstpbtnImportWebDocument.ToolTipText = "Import Web Document";
            this.tlstpbtnImportWebDocument.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // tlstpbtnClearDB
            // 
            this.tlstpbtnClearDB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnClearDB.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnClearDB.Image")));
            this.tlstpbtnClearDB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnClearDB.Name = "tlstpbtnClearDB";
            this.tlstpbtnClearDB.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnClearDB.Text = "toolStripButton1";
            this.tlstpbtnClearDB.ToolTipText = "Clear Cache Database";
            this.tlstpbtnClearDB.Click += new System.EventHandler(this.tlstpbtnClearDB_Click);
            // 
            // tlstpbtnCacheDatabase
            // 
            this.tlstpbtnCacheDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnCacheDatabase.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnCacheDatabase.Image")));
            this.tlstpbtnCacheDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnCacheDatabase.Name = "tlstpbtnCacheDatabase";
            this.tlstpbtnCacheDatabase.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnCacheDatabase.Text = "toolStripButton1";
            this.tlstpbtnCacheDatabase.ToolTipText = "Create Cache Database";
            this.tlstpbtnCacheDatabase.Click += new System.EventHandler(this.tlstpbtnCacheDatabase_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlstpbtnSimilarity
            // 
            this.tlstpbtnSimilarity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnSimilarity.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnSimilarity.Image")));
            this.tlstpbtnSimilarity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnSimilarity.Name = "tlstpbtnSimilarity";
            this.tlstpbtnSimilarity.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnSimilarity.Text = "toolStripButton1";
            this.tlstpbtnSimilarity.ToolTipText = "Reorganize Search Results";
            this.tlstpbtnSimilarity.Click += new System.EventHandler(this.tlstpbtnSimilarity_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "erp";
            this.saveFileDialog1.Filter = "Text Comparer Files(*.erp)|*.erp";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Where do you want to save the file?";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "erp";
            this.openFileDialog1.Filter = "Text Comparer Files(*.erp)|*.erp";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // tlstpbtnOrganizeForms
            // 
            this.tlstpbtnOrganizeForms.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tlstpbtnOrganizeForms.Image = ((System.Drawing.Image)(resources.GetObject("tlstpbtnOrganizeForms.Image")));
            this.tlstpbtnOrganizeForms.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlstpbtnOrganizeForms.Name = "tlstpbtnOrganizeForms";
            this.tlstpbtnOrganizeForms.Size = new System.Drawing.Size(23, 22);
            this.tlstpbtnOrganizeForms.ToolTipText = "Organize Windows";
            this.tlstpbtnOrganizeForms.Click += new System.EventHandler(this.tlstpbtnOrganizeForms_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 387);
            this.Controls.Add(this.stsstpMain);
            this.Controls.Add(this.tlstpMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Text Comparer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tlstpMain.ResumeLayout(false);
            this.tlstpMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlstpMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDocumentParagraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeDocumentItemsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stsstpMain;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripButton tlsbtnAddParagraph;
        private System.Windows.Forms.ToolStripButton tlstpbtnRemove;
        private System.Windows.Forms.ToolStripButton tlstpbtnInsertFile;
        private System.Windows.Forms.ToolStripTextBox tlstptxtSearch;
        private System.Windows.Forms.ToolStripButton tlstpbtnSearchGoogle;
        private System.Windows.Forms.ToolStripButton tlstpbtnCacheImporter;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchGoogleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem importCacheDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tlstpbtnCacheDatabase;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem createCacheDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem evaluateSimilarityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reorganizeSearchResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tlstpbtnSimilarity;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem clearCacheDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tlstpbtnClearDB;
        private System.Windows.Forms.ToolStripButton tlstpbtnImportWebDocument;
        private System.Windows.Forms.ToolStripButton tlstpbtnOrganizeForms;
    }
}
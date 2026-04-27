namespace Where_Is_My_Stuff
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.cb_categories = new System.Windows.Forms.ComboBox();
            this.cb_owners = new System.Windows.Forms.ComboBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_searchView = new System.Windows.Forms.Button();
            this.btn_archiveView = new System.Windows.Forms.Button();
            this.btn_logsView = new System.Windows.Forms.Button();
            this.btn_settingsView = new System.Windows.Forms.Button();
            this.tbc_mainWindow = new System.Windows.Forms.TabControl();
            this.tab_treeView = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree_left = new System.Windows.Forms.TreeView();
            this.treeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dodajPomieszczenieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajLokacjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajPrzedmiotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListForTreeView = new System.Windows.Forms.ImageList(this.components);
            this.tree_right = new System.Windows.Forms.TreeView();
            this.tab_filter = new System.Windows.Forms.TabPage();
            this.dg_itemsView = new System.Windows.Forms.DataGridView();
            this.tab_logs = new System.Windows.Forms.TabPage();
            this.tab_archive = new System.Windows.Forms.TabPage();
            this.btn_mainView = new System.Windows.Forms.Button();
            this.tbc_mainWindow.SuspendLayout();
            this.tab_treeView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.treeViewContextMenu.SuspendLayout();
            this.tab_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_itemsView)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_categories
            // 
            this.cb_categories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_categories.FormattingEnabled = true;
            this.cb_categories.Location = new System.Drawing.Point(67, 12);
            this.cb_categories.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_categories.Name = "cb_categories";
            this.cb_categories.Size = new System.Drawing.Size(121, 24);
            this.cb_categories.TabIndex = 0;
            // 
            // cb_owners
            // 
            this.cb_owners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_owners.FormattingEnabled = true;
            this.cb_owners.Location = new System.Drawing.Point(195, 12);
            this.cb_owners.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cb_owners.Name = "cb_owners";
            this.cb_owners.Size = new System.Drawing.Size(121, 24);
            this.cb_owners.TabIndex = 1;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(321, 12);
            this.tb_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(121, 22);
            this.tb_name.TabIndex = 2;
            // 
            // btn_searchView
            // 
            this.btn_searchView.Location = new System.Drawing.Point(448, 12);
            this.btn_searchView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_searchView.Name = "btn_searchView";
            this.btn_searchView.Size = new System.Drawing.Size(75, 23);
            this.btn_searchView.TabIndex = 3;
            this.btn_searchView.TabStop = false;
            this.btn_searchView.Text = "Filtruj";
            this.btn_searchView.UseVisualStyleBackColor = true;
            this.btn_searchView.Click += new System.EventHandler(this.btn_searchView_Click);
            // 
            // btn_archiveView
            // 
            this.btn_archiveView.Location = new System.Drawing.Point(533, 11);
            this.btn_archiveView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_archiveView.Name = "btn_archiveView";
            this.btn_archiveView.Size = new System.Drawing.Size(75, 23);
            this.btn_archiveView.TabIndex = 4;
            this.btn_archiveView.Text = "button2";
            this.btn_archiveView.UseVisualStyleBackColor = true;
            this.btn_archiveView.Click += new System.EventHandler(this.btn_archiveView_Click);
            // 
            // btn_logsView
            // 
            this.btn_logsView.Location = new System.Drawing.Point(613, 11);
            this.btn_logsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_logsView.Name = "btn_logsView";
            this.btn_logsView.Size = new System.Drawing.Size(75, 23);
            this.btn_logsView.TabIndex = 5;
            this.btn_logsView.Text = "button3";
            this.btn_logsView.UseVisualStyleBackColor = true;
            this.btn_logsView.Click += new System.EventHandler(this.btn_logsView_Click);
            // 
            // btn_settingsView
            // 
            this.btn_settingsView.Location = new System.Drawing.Point(695, 12);
            this.btn_settingsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_settingsView.Name = "btn_settingsView";
            this.btn_settingsView.Size = new System.Drawing.Size(75, 23);
            this.btn_settingsView.TabIndex = 6;
            this.btn_settingsView.Text = "button4";
            this.btn_settingsView.UseVisualStyleBackColor = true;
            // 
            // tbc_mainWindow
            // 
            this.tbc_mainWindow.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbc_mainWindow.Controls.Add(this.tab_treeView);
            this.tbc_mainWindow.Controls.Add(this.tab_filter);
            this.tbc_mainWindow.Controls.Add(this.tab_logs);
            this.tbc_mainWindow.Controls.Add(this.tab_archive);
            this.tbc_mainWindow.ItemSize = new System.Drawing.Size(100, 10);
            this.tbc_mainWindow.Location = new System.Drawing.Point(12, 127);
            this.tbc_mainWindow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbc_mainWindow.Name = "tbc_mainWindow";
            this.tbc_mainWindow.SelectedIndex = 0;
            this.tbc_mainWindow.Size = new System.Drawing.Size(757, 414);
            this.tbc_mainWindow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbc_mainWindow.TabIndex = 7;
            // 
            // tab_treeView
            // 
            this.tab_treeView.Controls.Add(this.splitContainer1);
            this.tab_treeView.Location = new System.Drawing.Point(4, 14);
            this.tab_treeView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_treeView.Name = "tab_treeView";
            this.tab_treeView.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_treeView.Size = new System.Drawing.Size(749, 396);
            this.tab_treeView.TabIndex = 0;
            this.tab_treeView.Text = "tab_treeView";
            this.tab_treeView.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree_left);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tree_right);
            this.splitContainer1.Size = new System.Drawing.Size(743, 392);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 0;
            // 
            // tree_left
            // 
            this.tree_left.AllowDrop = true;
            this.tree_left.ContextMenuStrip = this.treeViewContextMenu;
            this.tree_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_left.ImageIndex = 0;
            this.tree_left.ImageList = this.imageListForTreeView;
            this.tree_left.Location = new System.Drawing.Point(0, 0);
            this.tree_left.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tree_left.Name = "tree_left";
            this.tree_left.SelectedImageIndex = 0;
            this.tree_left.Size = new System.Drawing.Size(385, 390);
            this.tree_left.TabIndex = 0;
            this.tree_left.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_ItemDrag);
            this.tree_left.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseDoubleClick);
            this.tree_left.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tree_left.DragOver += new System.Windows.Forms.DragEventHandler(this.tree_DragOver);
            this.tree_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_MouseDown);
            // 
            // treeViewContextMenu
            // 
            this.treeViewContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.treeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajPomieszczenieToolStripMenuItem,
            this.dodajLokacjeToolStripMenuItem,
            this.dodajPrzedmiotToolStripMenuItem,
            this.edytujToolStripMenuItem,
            this.usuńToolStripMenuItem});
            this.treeViewContextMenu.Name = "treeViewContextMenu";
            this.treeViewContextMenu.Size = new System.Drawing.Size(222, 124);
            // 
            // dodajPomieszczenieToolStripMenuItem
            // 
            this.dodajPomieszczenieToolStripMenuItem.Name = "dodajPomieszczenieToolStripMenuItem";
            this.dodajPomieszczenieToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.dodajPomieszczenieToolStripMenuItem.Text = "Dodaj pomieszczenie";
            this.dodajPomieszczenieToolStripMenuItem.Click += new System.EventHandler(this.dodajPomieszczenieToolStripMenuItem_Click);
            // 
            // dodajLokacjeToolStripMenuItem
            // 
            this.dodajLokacjeToolStripMenuItem.Name = "dodajLokacjeToolStripMenuItem";
            this.dodajLokacjeToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.dodajLokacjeToolStripMenuItem.Text = "Dodaj lokacje";
            this.dodajLokacjeToolStripMenuItem.Click += new System.EventHandler(this.dodajLokacjeToolStripMenuItem_Click);
            // 
            // dodajPrzedmiotToolStripMenuItem
            // 
            this.dodajPrzedmiotToolStripMenuItem.Name = "dodajPrzedmiotToolStripMenuItem";
            this.dodajPrzedmiotToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.dodajPrzedmiotToolStripMenuItem.Text = "Dodaj przedmiot";
            this.dodajPrzedmiotToolStripMenuItem.Click += new System.EventHandler(this.dodajPrzedmiotToolStripMenuItem_Click);
            // 
            // edytujToolStripMenuItem
            // 
            this.edytujToolStripMenuItem.Name = "edytujToolStripMenuItem";
            this.edytujToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.edytujToolStripMenuItem.Text = "Edytuj";
            this.edytujToolStripMenuItem.Click += new System.EventHandler(this.edytujToolStripMenuItem_Click);
            // 
            // usuńToolStripMenuItem
            // 
            this.usuńToolStripMenuItem.Name = "usuńToolStripMenuItem";
            this.usuńToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.usuńToolStripMenuItem.Text = "Usuń";
            this.usuńToolStripMenuItem.Click += new System.EventHandler(this.usuńToolStripMenuItem_Click);
            // 
            // imageListForTreeView
            // 
            this.imageListForTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListForTreeView.ImageStream")));
            this.imageListForTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListForTreeView.Images.SetKeyName(0, "Home.png");
            this.imageListForTreeView.Images.SetKeyName(1, "ButtonGroup.png");
            this.imageListForTreeView.Images.SetKeyName(2, "Box.png");
            this.imageListForTreeView.Images.SetKeyName(3, "Calculator.png");
            // 
            // tree_right
            // 
            this.tree_right.AllowDrop = true;
            this.tree_right.ContextMenuStrip = this.treeViewContextMenu;
            this.tree_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_right.ImageIndex = 0;
            this.tree_right.ImageList = this.imageListForTreeView;
            this.tree_right.Location = new System.Drawing.Point(0, 0);
            this.tree_right.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tree_right.Name = "tree_right";
            this.tree_right.SelectedImageIndex = 0;
            this.tree_right.Size = new System.Drawing.Size(350, 390);
            this.tree_right.TabIndex = 0;
            this.tree_right.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tree_ItemDrag);
            this.tree_right.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tree_NodeMouseDoubleClick);
            this.tree_right.DragDrop += new System.Windows.Forms.DragEventHandler(this.tree_DragDrop);
            this.tree_right.DragOver += new System.Windows.Forms.DragEventHandler(this.tree_DragOver);
            this.tree_right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_MouseDown);
            // 
            // tab_filter
            // 
            this.tab_filter.Controls.Add(this.dg_itemsView);
            this.tab_filter.Location = new System.Drawing.Point(4, 14);
            this.tab_filter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_filter.Name = "tab_filter";
            this.tab_filter.Size = new System.Drawing.Size(749, 396);
            this.tab_filter.TabIndex = 3;
            this.tab_filter.Text = "tab_filter";
            this.tab_filter.UseVisualStyleBackColor = true;
            // 
            // dg_itemsView
            // 
            this.dg_itemsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_itemsView.Location = new System.Drawing.Point(36, 2);
            this.dg_itemsView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dg_itemsView.Name = "dg_itemsView";
            this.dg_itemsView.RowHeadersWidth = 51;
            this.dg_itemsView.RowTemplate.Height = 24;
            this.dg_itemsView.Size = new System.Drawing.Size(668, 319);
            this.dg_itemsView.TabIndex = 0;
            // 
            // tab_logs
            // 
            this.tab_logs.Location = new System.Drawing.Point(4, 14);
            this.tab_logs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_logs.Name = "tab_logs";
            this.tab_logs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_logs.Size = new System.Drawing.Size(749, 396);
            this.tab_logs.TabIndex = 1;
            this.tab_logs.Text = "tab_logs";
            this.tab_logs.UseVisualStyleBackColor = true;
            // 
            // tab_archive
            // 
            this.tab_archive.Location = new System.Drawing.Point(4, 14);
            this.tab_archive.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tab_archive.Name = "tab_archive";
            this.tab_archive.Size = new System.Drawing.Size(749, 396);
            this.tab_archive.TabIndex = 2;
            this.tab_archive.Text = "tab_archive";
            this.tab_archive.UseVisualStyleBackColor = true;
            // 
            // btn_mainView
            // 
            this.btn_mainView.Location = new System.Drawing.Point(12, 11);
            this.btn_mainView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_mainView.Name = "btn_mainView";
            this.btn_mainView.Size = new System.Drawing.Size(49, 25);
            this.btn_mainView.TabIndex = 8;
            this.btn_mainView.Text = "button5";
            this.btn_mainView.UseVisualStyleBackColor = true;
            this.btn_mainView.Click += new System.EventHandler(this.btn_mainView_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 551);
            this.Controls.Add(this.btn_mainView);
            this.Controls.Add(this.tbc_mainWindow);
            this.Controls.Add(this.btn_settingsView);
            this.Controls.Add(this.btn_logsView);
            this.Controls.Add(this.btn_archiveView);
            this.Controls.Add(this.btn_searchView);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.cb_owners);
            this.Controls.Add(this.cb_categories);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(799, 598);
            this.MinimumSize = new System.Drawing.Size(799, 598);
            this.Name = "MainWindow";
            this.Text = "Where Is My Stuff?";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tbc_mainWindow.ResumeLayout(false);
            this.tab_treeView.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.treeViewContextMenu.ResumeLayout(false);
            this.tab_filter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_itemsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_categories;
        private System.Windows.Forms.ComboBox cb_owners;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button btn_searchView;
        private System.Windows.Forms.Button btn_archiveView;
        private System.Windows.Forms.Button btn_logsView;
        private System.Windows.Forms.Button btn_settingsView;
        private System.Windows.Forms.TabPage tab_treeView;
        private System.Windows.Forms.TabPage tab_logs;
        private System.Windows.Forms.TabControl tbc_mainWindow;
        private System.Windows.Forms.TabPage tab_filter;
        private System.Windows.Forms.TabPage tab_archive;
        private System.Windows.Forms.Button btn_mainView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tree_left;
        private System.Windows.Forms.TreeView tree_right;
        private System.Windows.Forms.DataGridView dg_itemsView;
        private System.Windows.Forms.ContextMenuStrip treeViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem dodajLokacjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPrzedmiotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajPomieszczenieToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListForTreeView;
    }
}


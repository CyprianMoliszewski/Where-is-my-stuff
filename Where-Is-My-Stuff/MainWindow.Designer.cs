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
            this.cb_categories = new System.Windows.Forms.ComboBox();
            this.cb_owners = new System.Windows.Forms.ComboBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_searchView = new System.Windows.Forms.Button();
            this.btn_archiveView = new System.Windows.Forms.Button();
            this.btn_logsView = new System.Windows.Forms.Button();
            this.btn_settingsView = new System.Windows.Forms.Button();
            this.tbc_mainWindow = new System.Windows.Forms.TabControl();
            this.tab_treeView = new System.Windows.Forms.TabPage();
            this.tab_filter = new System.Windows.Forms.TabPage();
            this.tab_logs = new System.Windows.Forms.TabPage();
            this.tab_archive = new System.Windows.Forms.TabPage();
            this.btn_mainView = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbc_mainWindow.SuspendLayout();
            this.tab_treeView.SuspendLayout();
            this.tab_filter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_categories
            // 
            this.cb_categories.FormattingEnabled = true;
            this.cb_categories.Location = new System.Drawing.Point(67, 12);
            this.cb_categories.Name = "cb_categories";
            this.cb_categories.Size = new System.Drawing.Size(121, 24);
            this.cb_categories.TabIndex = 0;
            // 
            // cb_owners
            // 
            this.cb_owners.FormattingEnabled = true;
            this.cb_owners.Location = new System.Drawing.Point(194, 12);
            this.cb_owners.Name = "cb_owners";
            this.cb_owners.Size = new System.Drawing.Size(121, 24);
            this.cb_owners.TabIndex = 1;
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(321, 12);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(121, 22);
            this.tb_name.TabIndex = 2;
            // 
            // btn_searchView
            // 
            this.btn_searchView.Location = new System.Drawing.Point(448, 12);
            this.btn_searchView.Name = "btn_searchView";
            this.btn_searchView.Size = new System.Drawing.Size(75, 23);
            this.btn_searchView.TabIndex = 3;
            this.btn_searchView.TabStop = false;
            this.btn_searchView.Text = "button1";
            this.btn_searchView.UseVisualStyleBackColor = true;
            this.btn_searchView.Click += new System.EventHandler(this.btn_searchView_Click);
            // 
            // btn_archiveView
            // 
            this.btn_archiveView.Location = new System.Drawing.Point(533, 11);
            this.btn_archiveView.Name = "btn_archiveView";
            this.btn_archiveView.Size = new System.Drawing.Size(75, 23);
            this.btn_archiveView.TabIndex = 4;
            this.btn_archiveView.Text = "button2";
            this.btn_archiveView.UseVisualStyleBackColor = true;
            this.btn_archiveView.Click += new System.EventHandler(this.btn_archiveView_Click);
            // 
            // btn_logsView
            // 
            this.btn_logsView.Location = new System.Drawing.Point(614, 11);
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
            this.tbc_mainWindow.Name = "tbc_mainWindow";
            this.tbc_mainWindow.SelectedIndex = 0;
            this.tbc_mainWindow.Size = new System.Drawing.Size(758, 414);
            this.tbc_mainWindow.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbc_mainWindow.TabIndex = 7;
            // 
            // tab_treeView
            // 
            this.tab_treeView.Controls.Add(this.splitContainer1);
            this.tab_treeView.Location = new System.Drawing.Point(4, 14);
            this.tab_treeView.Name = "tab_treeView";
            this.tab_treeView.Padding = new System.Windows.Forms.Padding(3);
            this.tab_treeView.Size = new System.Drawing.Size(750, 396);
            this.tab_treeView.TabIndex = 0;
            this.tab_treeView.Text = "tab_treeView";
            this.tab_treeView.UseVisualStyleBackColor = true;
            // 
            // tab_filter
            // 
            this.tab_filter.Controls.Add(this.dataGridView1);
            this.tab_filter.Location = new System.Drawing.Point(4, 14);
            this.tab_filter.Name = "tab_filter";
            this.tab_filter.Size = new System.Drawing.Size(750, 396);
            this.tab_filter.TabIndex = 3;
            this.tab_filter.Text = "tab_filter";
            this.tab_filter.UseVisualStyleBackColor = true;
            // 
            // tab_logs
            // 
            this.tab_logs.Location = new System.Drawing.Point(4, 14);
            this.tab_logs.Name = "tab_logs";
            this.tab_logs.Padding = new System.Windows.Forms.Padding(3);
            this.tab_logs.Size = new System.Drawing.Size(750, 396);
            this.tab_logs.TabIndex = 1;
            this.tab_logs.Text = "tab_logs";
            this.tab_logs.UseVisualStyleBackColor = true;
            // 
            // tab_archive
            // 
            this.tab_archive.Location = new System.Drawing.Point(4, 14);
            this.tab_archive.Name = "tab_archive";
            this.tab_archive.Size = new System.Drawing.Size(750, 396);
            this.tab_archive.TabIndex = 2;
            this.tab_archive.Text = "tab_archive";
            this.tab_archive.UseVisualStyleBackColor = true;
            // 
            // btn_mainView
            // 
            this.btn_mainView.Location = new System.Drawing.Point(12, 11);
            this.btn_mainView.Name = "btn_mainView";
            this.btn_mainView.Size = new System.Drawing.Size(49, 25);
            this.btn_mainView.TabIndex = 8;
            this.btn_mainView.Text = "button5";
            this.btn_mainView.UseVisualStyleBackColor = true;
            this.btn_mainView.Click += new System.EventHandler(this.btn_mainView_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView2);
            this.splitContainer1.Size = new System.Drawing.Size(744, 390);
            this.splitContainer1.SplitterDistance = 371;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 69);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(97, 107);
            this.treeView2.Name = "treeView2";
            this.treeView2.Size = new System.Drawing.Size(121, 97);
            this.treeView2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(269, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.btn_mainView);
            this.Controls.Add(this.tbc_mainWindow);
            this.Controls.Add(this.btn_settingsView);
            this.Controls.Add(this.btn_logsView);
            this.Controls.Add(this.btn_archiveView);
            this.Controls.Add(this.btn_searchView);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.cb_owners);
            this.Controls.Add(this.cb_categories);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Text = "Where Is My Stuff?";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tbc_mainWindow.ResumeLayout(false);
            this.tab_treeView.ResumeLayout(false);
            this.tab_filter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


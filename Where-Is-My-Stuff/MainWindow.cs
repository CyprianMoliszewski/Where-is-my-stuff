using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Where_Is_My_Stuff.Database;
using Where_Is_My_Stuff.Services;

namespace Where_Is_My_Stuff
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            DatabaseHandler dh = DatabaseHandler.Instance;
            TreeViewService treeViewService = new TreeViewService();
            treeViewService.PopulateTree(tree_left);
            tree_left.ExpandAll();           
            cb_categories.Items.AddRange(dh.GetValueForCombobox("tbl_categories", "category_name").ToArray());
            cb_owners.Items.AddRange(dh.GetValueForCombobox("tbl_owners", "owner_name").ToArray());
        }


        private void btn_mainView_Click(object sender, EventArgs e)
        {
            tbc_mainWindow.SelectedIndex = 0;
        }
        private void btn_searchView_Click(object sender, EventArgs e)
        {
            tbc_mainWindow.SelectedIndex = 1;

            /// DATAGRID FILL
            /// SELECT * FROM ITEMS WHERE OWNER = OWNER, CATEGORY = CATEGORY, NAME LIKE/CONTAINS TXT, IS ACTIVE = 1 
        }

        private void btn_archiveView_Click(object sender, EventArgs e)
        {

            tbc_mainWindow.SelectedIndex = 2;
        }

        private void btn_logsView_Click(object sender, EventArgs e)
        {

            tbc_mainWindow.SelectedIndex = 3;
        }


    }
}

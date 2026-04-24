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
        BindingSource bs = new BindingSource();
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
            //Combobox
            cb_categories.Items.AddRange(dh.GetValueForCombobox("tbl_categories", "category_name").ToArray());
            cb_owners.Items.AddRange(dh.GetValueForCombobox("tbl_owners", "owner_name").ToArray());
            //DataGrid
            DataTable items = dh.GetItmes();
            bs.DataSource = items;
            dg_itemsView.DataSource = bs;
            dg_itemsView.Columns["item_id"].Visible = false;
        }


        private void btn_mainView_Click(object sender, EventArgs e)
        {
            tbc_mainWindow.SelectedIndex = 0;
        }
        private void btn_searchView_Click(object sender, EventArgs e)
        {
            tbc_mainWindow.SelectedIndex = 1;

            FilterService fs = new FilterService();
            string filter = fs.FilterItems(tb_name.Text, cb_categories.Text, cb_owners.Text);
            bs.Filter = filter;
            tb_name.Clear();
            cb_categories.SelectedIndex = -1;
            cb_categories.Text = "Kategorie";
            cb_owners.SelectedIndex = -1;
            cb_owners.Text = "Właściciel";

        }

        private void btn_archiveView_Click(object sender, EventArgs e)
        {

            tbc_mainWindow.SelectedIndex = 2;
        }

        private void btn_logsView_Click(object sender, EventArgs e)
        {

            tbc_mainWindow.SelectedIndex = 3;
        }

        private void tree_left_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var dh = DatabaseHandler.Instance;
            var clickedObject = e.Node.Tag as TreeNodeLocation;

            if (clickedObject != null && !clickedObject.IsLocation) {
                int item_id = clickedObject.Id;
                ItemsDetailsService service = new ItemsDetailsService(dh);
                service.OpenDetails(item_id);
            }
            else
            {
                return;
            }
        }
    }
}

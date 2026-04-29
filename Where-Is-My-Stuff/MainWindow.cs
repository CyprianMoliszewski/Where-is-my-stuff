using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Where_Is_My_Stuff.Database;
using Where_Is_My_Stuff.Forms;
using Where_Is_My_Stuff.Services;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            //Db handler
            DatabaseHandler dh = DatabaseHandler.Instance;

            //Tree view
            resfreshTrees();

            splitContainer1.SplitterDistance = splitContainer1.Width / 2;

            //Combobox
            cb_categories.Items.AddRange(dh.GetValueForCombobox("tbl_categories", "category_name").ToArray());
            cb_owners.Items.AddRange(dh.GetValueForCombobox("tbl_owners", "owner_name").ToArray());

            //Settings
            List<string> categories = dh.GetCategories();
            lbl_categories_list.Text = string.Join("\n", categories);

            List<string> owners = dh.GetOwners();
            lbl_owners_list.Text = string.Join("\n", owners);

        }


        /// <summary>
        /// NAV BAR
        /// </summary>
        private void btn_mainView_Click(object sender, EventArgs e)
        {
            tree_left.Nodes.Clear();
            TreeViewService treeViewService = new TreeViewService();
            treeViewService.PopulateTree(tree_left);
            tree_left.ExpandAll();
            tbc_mainWindow.SelectedIndex = 0;
        }
        private void btn_searchView_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;
            //DataGrid
            DataTable items = dh.GetItmes();
            bs.DataSource = items;
            dg_itemsView.DataSource = bs;
            dg_itemsView.Columns["item_id"].Visible = false;
            dg_itemsView.Columns["item_description"].Visible = false;
            tbc_mainWindow.SelectedIndex = 1;

            FilterService fs = new FilterService();
            string filter = fs.FilterItems(tb_name.Text, cb_categories.Text, cb_owners.Text);
            bs.Filter = filter;
            tb_name.Clear();
            cb_categories.SelectedIndex = -1;
            cb_owners.SelectedIndex = -1;

        }
        private void btn_settingsView_Click(object sender, EventArgs e)
        {
            tbc_mainWindow.SelectedIndex = 2;
        }
        private void btn_logsView_Click(object sender, EventArgs e)
        {

            tbc_mainWindow.SelectedIndex = 3;
        }

        /// <summary>
        /// TREE VIEW
        /// </summary>
        
        private void resfreshTrees()
        {
            TreeViewService treeViewService = new TreeViewService();
            
            tree_left.BeginUpdate();
            tree_right.BeginUpdate();

            tree_left.Nodes.Clear();
            tree_right.Nodes.Clear();

            treeViewService.PopulateTree(tree_left);
            treeViewService.PopulateTree(tree_right);

            tree_left.EndUpdate();
            tree_right.EndUpdate();

            tree_left.ExpandAll();
            tree_right.ExpandAll();
        }
        private void tree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var selectedNode = e.Node;
            var isLocation = selectedNode.Tag as TreeNodeLocation;
            if (isLocation.IsLocation)
            {
                return;
            }
            
            using (var frm = new ItemAddOrEdit('E', selectedNode))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    resfreshTrees();
                }
            }
        }
        private void tree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            System.Windows.Forms.TreeView tree = (System.Windows.Forms.TreeView)sender;

            var hitTest = tree.HitTest(e.Location);

            Debug.WriteLine($"Tree side:{tree.Name}");

            if (hitTest.Node == null)
            {
                tree.SelectedNode = null;
                Debug.WriteLine("Nothing selected");

                ContextMenuConfig(null);
                tree.Refresh();
            }
            else
            {
                tree.SelectedNode = hitTest.Node;
                Debug.WriteLine($"Clicked node:{tree.SelectedNode.Text}");

                ContextMenuConfig(hitTest.Node);
            }
        }

        /// <summary>
        /// DRAG & DROP
        /// </summary>

        private void tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }
        private void tree_DragOver(object sender, DragEventArgs e)
        {
            System.Windows.Forms.TreeView targetTree = (System.Windows.Forms.TreeView)sender;

            TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            Point pt = targetTree.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = targetTree.GetNodeAt(pt);

            targetTree.SelectedNode = targetNode;

            if (IsTargetValid(sourceNode, targetNode))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void tree_DragDrop(object sender, DragEventArgs e)
        {
            System.Windows.Forms.TreeView targetTree = (System.Windows.Forms.TreeView)sender;
            TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TreeNode targetNode = targetTree.SelectedNode;

            var sourceData = (TreeNodeLocation)sourceNode.Tag;

            int newParentId = ((TreeNodeLocation)targetNode.Tag).Id;

            var dh = DatabaseHandler.Instance;

            if (sourceData.IsLocation)
                dh.MoveLocation(sourceData.Id, newParentId);
            else
                dh.MoveItem(sourceData.Id, newParentId);

            resfreshTrees();
        }
        private bool IsTargetValid(TreeNode sourceNode, TreeNode targetNode)
        {
            if (targetNode == null) return false;

            if (sourceNode == targetNode) return false;

            var sourceData = (TreeNodeLocation)sourceNode.Tag;
            var targetData = (TreeNodeLocation)targetNode.Tag;

            if (!targetData.IsLocation) return false;

            if (sourceData.IsLocation)
            {
                if (targetData.TypeId >= sourceData.TypeId)
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// CONEXT MENU
        /// </summary>     
        private void ContextMenuConfig(TreeNode node)
        {
            if (node == null) //NOTHING
            {
                dodajPomieszczenieToolStripMenuItem.Enabled = true;
                dodajPrzedmiotToolStripMenuItem.Enabled = false;
                dodajLokacjeToolStripMenuItem.Enabled = false;
                edytujToolStripMenuItem.Enabled = false;
                usuńToolStripMenuItem.Enabled = false;
                return;
            }

            if (node.Tag is TreeNodeItem) //ITEM (YOU CAN ONLY EDIT OR DELETE IT)
            {
                dodajPomieszczenieToolStripMenuItem.Enabled = false;
                dodajPrzedmiotToolStripMenuItem.Enabled = false;
                dodajLokacjeToolStripMenuItem.Enabled = false;
                edytujToolStripMenuItem.Enabled = true;
                usuńToolStripMenuItem.Enabled = true;
            }
            else if (node.Tag is TreeNodeLocation loc) //LOCATION - ONLY IF TYPEID = 3 YOU CAN'T ADD ANOTHER LOCATION INTO IT
            {
                dodajPomieszczenieToolStripMenuItem.Enabled = false;
                dodajPrzedmiotToolStripMenuItem.Enabled = true;
                edytujToolStripMenuItem.Enabled = true;
                usuńToolStripMenuItem.Enabled = true;
                dodajLokacjeToolStripMenuItem.Enabled = true;
                if (loc.TypeId == 3)
                {
                    dodajLokacjeToolStripMenuItem.Enabled = false;
                }
            }
        }
        private void dodajPomieszczenieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new AddRoom())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    resfreshTrees();
                }
            }
        }
        private void dodajLokacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            System.Windows.Forms.TreeView tree = (System.Windows.Forms.TreeView)menu.SourceControl;
            TreeNode selectedNode = tree.SelectedNode;

            using (var frm = new LocationAddOrEdit('A', selectedNode))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    resfreshTrees();
                }
            }
        }
        private void dodajPrzedmiotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            System.Windows.Forms.TreeView tree = (System.Windows.Forms.TreeView)menu.SourceControl;
            TreeNode selectedNode = tree.SelectedNode;

            using (var frm = new ItemAddOrEdit('A', selectedNode))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    resfreshTrees();
                }
            }
        }
        private void edytujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            System.Windows.Forms.TreeView tree = (System.Windows.Forms.TreeView)menu.SourceControl;
            TreeNode selectedNode = tree.SelectedNode;

            var isLocation = selectedNode.Tag as TreeNodeLocation;


            if (isLocation.IsLocation)
            {
                using (var frm = new LocationAddOrEdit('E', selectedNode))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        resfreshTrees();
                    }
                }
            }
            else
            {
                using (var frm = new ItemAddOrEdit('E', selectedNode))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        resfreshTrees();
                    }
                }
            }
        }
        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = (ContextMenuStrip)((ToolStripMenuItem)sender).Owner;
            System.Windows.Forms.TreeView tree = (System.Windows.Forms.TreeView)menu.SourceControl;
            TreeNode selectedNode = tree.SelectedNode;
            var dh = DatabaseHandler.Instance;
            
            var item = selectedNode.Tag as TreeNodeLocation;
            if (item.IsLocation)
            {
                if (ConfirmDeletion(item.Name, true))
                {
                    dh.DeleteLocation(item.Id);
                    resfreshTrees();
                }
            }
            else
            {
                if (ConfirmDeletion(item.Name, false))
                {
                    dh.DeleteItem(item.Id);
                    resfreshTrees();
                }
            }
        }
        private bool ConfirmDeletion(string itemName, bool isLocation)
        {
            string message = isLocation
                ? $"Czy na pewno chcesz usunąć lokalizację '{itemName}'?\n\nUWAGA: Wszystkie podlokalizacje oraz przedmioty w nich zawarte zostaną również ukryte!"
                : $"Czy na pewno chcesz usunąć przedmiot '{itemName}'?";

            string title = isLocation ? "Potwierdzenie usunięcia kaskadowego" : "Potwierdzenie usunięcia";

            DialogResult result = MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            return result == DialogResult.Yes;
        }

        private void dg_itemsView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow selectedRow = dg_itemsView.Rows[e.RowIndex];
            ItemAddOrEdit form = new ItemAddOrEdit('E', selectedRow);
            if (form.ShowDialog() == DialogResult.OK){
                var dh = DatabaseHandler.Instance;
                DataTable items = dh.GetItmes();
                bs.DataSource = items;
                dg_itemsView.DataSource = bs;
                if (dg_itemsView.Columns.Contains("item_id"))
                    dg_itemsView.Columns["item_id"].Visible = false;
                if (dg_itemsView.Columns.Contains("item_description"))
                    dg_itemsView.Columns["item_description"].Visible = false;
                                
            }
        }

        private void lbl_categories_list_Click(object sender, EventArgs e) { }        
        
        private void lbl_owners_list_Click(object sender, EventArgs e) { }

        private void btn_add_category_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;
            dh.AddCategory(txt_category.Text);

            List<string> categories = dh.GetCategories();
            lbl_categories_list.Text = string.Join("\n", categories);
            txt_category.Clear();
            cb_categories.Items.Clear();
            cb_categories.Items.AddRange(dh.GetValueForCombobox("tbl_categories", "category_name").ToArray());
        }

        private void btn_add_owner_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;
            dh.AddOwner(txt_add_owner.Text);

            List<string> owners = dh.GetOwners();
            lbl_owners_list.Text = string.Join("\n", owners);
            txt_add_owner.Clear();
            cb_owners.Items.Clear();
            cb_owners.Items.AddRange(dh.GetValueForCombobox("tbl_owners", "owner_name").ToArray());
        }
        


    }
}
   
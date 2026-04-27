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

namespace Where_Is_My_Stuff.Forms
{
    public partial class ItemAddOrEdit : Form
    {
        private readonly char _addOrEdit;
        private readonly TreeNodeLocation _location;
        private readonly TreeNodeItem _item;
        
        public ItemAddOrEdit(char addOrEdit, TreeNode selectedNode)
        {
            DatabaseHandler dh = DatabaseHandler.Instance;
            InitializeComponent();

            _addOrEdit = addOrEdit;
            
            tb_item_location.Enabled = false;

            cb_item_category.Items.AddRange(dh.GetValueForCombobox("tbl_categories", "category_name").ToArray());
            cb_item_owner.Items.AddRange(dh.GetValueForCombobox("tbl_owners", "owner_name").ToArray());

            if (_addOrEdit == 'A')
            {
                _location = selectedNode.Tag as TreeNodeLocation;
                tb_item_location.Text = dh.GetLocationPath(_location.Id, " ");
            }
            else
            {
                _item = selectedNode.Tag as TreeNodeItem;
                tb_item_location.Text = dh.GetLocationPath(_item.ParentId, _item.Name);

                tb_item_name.Text = _item.Name;
                cb_item_category.Text = dh.GetNameOfCategory(_item.CategoryId);
                cb_item_owner.Text = dh.GetNameOfOwner(_item.OwnerId);
                tb_item_description.Text = _item.Description;
            }
        }


        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;

            if(string.IsNullOrEmpty(tb_item_name.Text) || string.IsNullOrWhiteSpace(tb_item_name.Text))
            {
                MessageBox.Show("Nazwa przedmiotu jest wymagana!", "Uzupełnij obowiązkowe pola",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tb_item_name.Focus();
                return;
            }

            if (cb_item_category.SelectedIndex == -1)
            {
                MessageBox.Show("Musisz wybrać kategorię!", "Uzupełnij obowiązkowe pola",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_item_category.Focus();
                return;
            }

            if (cb_item_owner.SelectedIndex == -1)
            {
                MessageBox.Show("Musisz wybrać właściciela!", "Uzupełnij obowiązkowe pola",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cb_item_owner.Focus();
                return;
            }


            if (_addOrEdit == 'A')
            {
                dh.AddItem(_location.Id,
                    cb_item_category.Text,
                    cb_item_owner.Text,
                    tb_item_name.Text,
                    tb_item_description.Text);
            }
            else
            {
                dh.EditItem(_item.Id,
                    tb_item_name.Text,
                    cb_item_category.Text,
                    cb_item_owner.Text,
                    tb_item_description.Text);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}

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
    public partial class LocationAddOrEdit : Form
    {
        private readonly char _addOrEdit;
        private readonly TreeNodeLocation _selectedNode;
        public LocationAddOrEdit(char addOrEdit, TreeNode selectedNode)
        {
            DatabaseHandler dh = DatabaseHandler.Instance;
            InitializeComponent();

            

            _addOrEdit = addOrEdit;
            _selectedNode = selectedNode.Tag as TreeNodeLocation;

            if (_addOrEdit == 'A')
            {
                var allTypes = dh.GetValueForCombobox("tbl_location_type", "location_type_name");

                List<string> filteredTypes = new List<string>();

                for (int i = 0; i < allTypes.Count; i++)
                {
                    int currentTypeId = i + 1; 

                    if (currentTypeId > _selectedNode.TypeId)
                    {
                        filteredTypes.Add(allTypes[i]);
                    }
                }

                cb_location_category.DataSource = filteredTypes;
            }
            else
            {
                cb_location_category.Enabled = false;
                cb_location_category.Text = dh.GetNameOfType(_selectedNode.TypeId);
                tb_location_name.Text = _selectedNode.Name;
            }
            
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;

            if (string.IsNullOrEmpty(tb_location_name.Text) || string.IsNullOrWhiteSpace(tb_location_name.Text))
            {
                MessageBox.Show("Nazwa lokacji jest wymagana!", "Uzupełnij obowiązkowe pola",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tb_location_name.Focus();
                return;
            }

            if (cb_location_category.Enabled == true)
            {
                if (cb_location_category.SelectedIndex == -1)
                {
                    MessageBox.Show("Musisz wybrać typ!", "Uzupełnij obowiązkowe pola",
                         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cb_location_category.Focus();
                    return;
                }
            }

            if (_addOrEdit == 'A')
            {
                dh.AddLocation(tb_location_name.Text, cb_location_category.Text, _selectedNode.Id);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                dh.EditLocation(tb_location_name.Text, _selectedNode.Id);
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}

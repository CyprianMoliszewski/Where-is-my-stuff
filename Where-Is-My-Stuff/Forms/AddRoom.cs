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

namespace Where_Is_My_Stuff.Forms
{
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            var dh = DatabaseHandler.Instance;

            if (string.IsNullOrEmpty(tb_room_name.Text) || string.IsNullOrWhiteSpace(tb_room_name.Text))
            {
                MessageBox.Show("Nazwa lokacji jest wymagana!", "Uzupełnij obowiązkowe pola",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tb_room_name.Focus();
                return;
            }

            dh.AddRoom(tb_room_name.Text);
            this.DialogResult = DialogResult.OK;
        }

    }
}

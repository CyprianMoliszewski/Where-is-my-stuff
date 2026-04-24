using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Where_Is_My_Stuff
{
    public partial class DetailsForm : Form
    {
        public DetailsForm(DataTable data)
        {
            InitializeComponent();

            if (data.Rows.Count > 0) { 
                DataRow row = data.Rows[0];

                lblNameValue.Text = row["item_name"].ToString();
                lblCatValue.Text = row["category_name"].ToString();
                lblOwnerValue.Text = row["owner_name"].ToString();
                lblLocValue.Text = row["location_name"].ToString();
                lblInDateValue.Text = row["create_date"].ToString();
                lblEdDateValue.Text = row["update_date"].ToString();
                txtDescription.Text = row["item_description"].ToString();

            }
        }
    }
}

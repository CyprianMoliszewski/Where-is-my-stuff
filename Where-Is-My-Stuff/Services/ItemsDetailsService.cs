using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Where_Is_My_Stuff.Database;

namespace Where_Is_My_Stuff.Services
{
    internal class ItemsDetailsService
    {
        private DatabaseHandler _dh;

        public ItemsDetailsService(DatabaseHandler dh)
        {
            _dh = dh; 
        }
        public void OpenDetails(int id)
        {
            DataTable data =_dh.GetItemsDetails(id);
            DetailsForm details = new DetailsForm(data);
            details.Show();           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Where_Is_My_Stuff.Services
{
    public class FilterService
    {
        public string FilterItems(string item, string category, string owner)
        {
            List<string> filteredItems = new List<string>();

            if (item != "")
            {
                filteredItems.Add($"Przedmiot LIKE '%{item}%'");
            }

            if (category != "Kategorie" && category !="")
            {
                filteredItems.Add($"Kategoria = '{category}'");
            }

            if (owner != "Właściciel" && owner != "")
            {
                filteredItems.Add($"Właściciel = '{owner}'");
            }

            if (filteredItems.Count > 0)
            {
                return string.Join(" OR ", filteredItems);
            }
            else
            {
                return "";
            }

        }        
    }
}

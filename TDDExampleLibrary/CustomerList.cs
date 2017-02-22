using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDExampleLibrary
{

    public class CustomerList
    {
        private List<Tuple<string, float, enumCategories>> _menuList = new List<Tuple<string, float, enumCategories>>
        {
            new Tuple<string, float, enumCategories>("cola", 0.5f, enumCategories.COLD),
            new Tuple<string, float, enumCategories>("coffee", 1.0f, enumCategories.HOT),
            new Tuple<string, float, enumCategories>("cheese sandwich", 2.0f, enumCategories.COLD),
            new Tuple<string, float, enumCategories>("steak sandwich", 4.5f, enumCategories.HOT)
        };

        private List<float> _menuCost = new List<float>();
        public CustomerList()
        {
        }

        public void Add(string item)
        {
            var itm = _menuList.Where(x => x.Item1 == item).FirstOrDefault();

            if (itm != null)
                _menuCost.Add(itm.Item2);
        }

        public string GetBill()
        {
            var ret = string.Empty;
            var total = _menuCost.Sum();
            return total.ToString("n2");
        }
    }
}

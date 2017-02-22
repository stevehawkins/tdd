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
            new Tuple<string, float, enumCategories>("cola", 0.5f, enumCategories.DRINK),
            new Tuple<string, float, enumCategories>("coffee", 1.0f, enumCategories.DRINK),
            new Tuple<string, float, enumCategories>("cheese sandwich", 2.0f, enumCategories.COLDFOOD),
            new Tuple<string, float, enumCategories>("steak sandwich", 4.5f, enumCategories.HOTFOOD)
        };

        private List<Tuple<string, float, enumCategories>> _menuCost = new List<Tuple<string, float, enumCategories>>();
        public CustomerList()
        {
        }

        public void Add(string item)
        {
            var itm = _menuList.Where(x => x.Item1 == item).FirstOrDefault();

            if (itm != null)
                _menuCost.Add(itm);
        }

        public string GetBill()
        {
            var ret = string.Empty;
            var total = _menuCost.Sum(x=>x.Item2);
            return total.ToString("n2");
        }

        public string GetServiceCost()
        {
            var ret = string.Empty;
            // 10% charge 
            var coldFood = (_menuCost.Where(p=>p.Item3==enumCategories.COLDFOOD).Sum(x => x.Item2))*0.1;
            // 20% charge
            var hotFood = (_menuCost.Where(p => p.Item3 == enumCategories.HOTFOOD).Sum(x => x.Item2)) * 0.2;
            if (hotFood > 20.0f) hotFood = 20.0f;
            return (hotFood+coldFood).ToString("n2");
        }
    }
}

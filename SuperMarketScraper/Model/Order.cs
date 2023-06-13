using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketScraper.Model
{
    public class Order
    {
        public String Name { get;set; }
        public String? Sklavenitis { get; set; }
        public String? Ab { get; set; }
        public String? Mymarket { get; set; }
        public String? Masoutis { get; set; }

        public Order(String name)
        {
            this.Name = name;
        }

    public override String ToString()
        {
            if (Sklavenitis == null && Ab == null && Mymarket == null && Masoutis == null) return Name;
            return Name + "   *";
        }
    }
}

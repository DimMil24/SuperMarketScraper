using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketScraper.Model
{
    public class Product
    {
        public String? Name { get; set; }
        public double Price { get; set; }
        public double Sale { get; set; }
        public int SuperMarket { get; set; }

        public Product()
        {
            this.Name = null;
            this.Price = 0;
            this.Sale = 0;
            this.SuperMarket = -1;
        }

        public Product(String name, double price, double sale, int superMarket)
        {
            this.Name = name;
            this.Price = price;
            this.Sale = sale;
            this.SuperMarket = superMarket;
        }


        public int hasSale()
        {
            if (Sale > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public String getSuperMarketName()
        {
            String m;
            if (SuperMarket == 1)
            {
                m = "Σκλαβενίτης";
            }
            else if (SuperMarket == 2)
            {
                m = "ΑΒ";
            }
            else if (SuperMarket == 3)
            {
                m = "My Market";
            }
            else if (SuperMarket == 4)
            {
                m = "Μασούτης";
            }
            else
            {
                m = "Δεν Βρέθηκε";
            }
            return m;
        }

    public override String ToString()
        {
            if (Name == null) return "Δεν Βρέθηκε";
            if (Price == 0)
            {
                return Name + ' ' + " Προσωρινα μη διαθέσιμο";
            }
            if (Sale > 0)
            {
                return Name + ' ' + (Math.Round(Price, 2, MidpointRounding.AwayFromZero)).ToString("#0.00") + "€    ΧΩΡΙΣ ΕΚΠΤΩΣΗ " + (Math.Round(Sale, 2, MidpointRounding.AwayFromZero)).ToString("#0.00") + " €";
            }
            return Name + ' ' + (Math.Round(Price, 2, MidpointRounding.AwayFromZero)).ToString("#0.00") + "€ ";
        }
    }
}

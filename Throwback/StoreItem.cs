using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Throwback
{
    public class StoreItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public double BusinessCost { get; set; }

        public int Owned
        {
            get { return BoughtPersonal + BoughtBusiness; }
        }

        public StoreItem()
        {
        }

        public StoreItem(string name, string description, double cost, double businessCost) : base()
        {
            Name = name;
            Description = description;
            Cost = cost;
            BusinessCost = businessCost;
        }

        public int BoughtPersonal { get; set; }
        public int BoughtBusiness { get; set; }
    }
}
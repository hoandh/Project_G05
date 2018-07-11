using System;
using System.Collections.Generic;

namespace Persistence {
    public static class OrderStatus {
        public const int Create_new_order = 1;
    }
    public class Orders {
        public int? CodeOrders { get; set; }
        public Orders (DateTime orderDate, string itemName, string price, Customer orderCustomer) {
            this.orderDate = orderDate;
            this.ItemName = itemName;
            this.Price = price;
            this.OrderCustomer = orderCustomer;

        }
        public DateTime orderDate { get; set; }
        public string ItemName { get; set; }
        public string Price { get; set; }
        public Customer OrderCustomer { get; set; }
        public List<Items> ItemsList { set; get; }

         public Items this[int index]
        {
            get
            {
                if (ItemsList == null || ItemsList.Count == 0 || index < 0 || ItemsList.Count < index) return null;
                return ItemsList[index];
            }
            set
            {
                if (ItemsList == null) ItemsList = new List<Items>();
                ItemsList.Add(value);
            }
        }
        public Orders () {
            ItemsList = new List<Items> ();
        }

        public override bool Equals (object obj) {
            if (obj is Orders) {
                return ((Orders) obj).CodeOrders.Equals (CodeOrders);
            }
            return false;
        }

        public override int GetHashCode () {
            return CodeOrders.GetHashCode ();
        }
    }
}
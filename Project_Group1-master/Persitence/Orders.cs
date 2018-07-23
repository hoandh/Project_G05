using System;
using System.Collections.Generic;
namespace Persistence
{
    public class Bill
    {
        public Items item = new Items();
        public int quantity;
    }
    public static class OrderStatus
    {
        public const int create_new_order = 1;    }
    public class Orders
    {
        public int? CodeOrder{get;set;}
        public int UserId{get; set;}
        public int ItemId{get;set;}
        public string Itemname {get; set;}
        public string Price {get; set;}
        public int Amount {get; set;}
        public List<Bill> ItemsList {get; set;}
        public Bill this[int index]
        {
            get
            {
                if (ItemsList == null || ItemsList.Count == 0 || index < 0 || ItemsList.Count <index)
                {
                    return null;
                };
                return ItemsList[index];
            }
            set
            {
                if (ItemsList == null) ItemsList = new List<Bill>();
                ItemsList.Add(value);
            }
        }
        public Orders()
        {
            ItemsList = new List<Bill>();
        }
        public override bool Equals(object obj)
        {
            if(obj is Orders )
            {
                return ((Orders)obj).CodeOrder.Equals(CodeOrder);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return CodeOrder.GetHashCode();
        }
    }
}
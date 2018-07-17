using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class ItemBL
    {
        private ItemDAL idal;
        public ItemBL()
        {
            idal = new ItemDAL();
        }
        public Items GetItemById(int itemId)
        {
            return idal.GetItemById(itemId);
        }
        public List<Items> GetAll()
        {
            return idal.GetItems(ItemFilter.GET_ALL, null);
        }
        public List<Items> GetByName(string itemName)
        {
            return idal.GetItems(ItemFilter.FILTER_BY_ITEM_NAME, new Items{ItemName=itemName});
        }
        
    }
}

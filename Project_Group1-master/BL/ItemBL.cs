using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL {
    public class Item_BL {
        private Item_DAL dal = new Item_DAL();
        public List<Items> GetItems () {
            return dal.GetItems ();
        }
        public Items getItemById (int id) {
            if(id ==0)
            {
                return null;
            }
            return dal.getItemById (id);
        }
    }
}
using System;
namespace Persitence
{
    public class Items
    {
        public int? ItemId{get; set;}
        public string ItemName{get; set;}
        public string Price{get; set;}
        public int Amount{get; set;}
        public override bool Equals(object obj){
            if(obj is Items){
                return ((Items)obj).ItemId.Equals(ItemId);
            }
            return false;
        }

        public override int GetHashCode(){
            return ItemId.GetHashCode();
        }
    }
}
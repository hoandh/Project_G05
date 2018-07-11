using System;

namespace Persistence
{
    public class Customer
    {
        public int? UserId {get; set;}
        public string UserName {get; set;}
        public string Password {get; set;}
        public int Phone{get; set;}
        // Hàm Equals kiểm tra đối tượng có tham chiếu đến bộ nhớ
        public override bool Equals(object obj){
            if(obj is Customer){
                return ((Customer)obj).UserId.Equals(UserId);
            }
            return false;
            }
            // Hàm GetHashCode lấy ra giá trị băm(int)
            public override int GetHashCode(){
                return UserId.GetHashCode();
            }
    }
    
    
}

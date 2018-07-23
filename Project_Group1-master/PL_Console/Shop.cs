using System;
using System.Collections.Generic;
using BL;
using Persistence;

namespace PL_Console {
    class ShopInterface {
        public void Shop () {
            while (true) {

                Console.Clear ();
                MenuCinema ();
                int number;
                while (true) {
                    bool isINT = Int32.TryParse (Console.ReadLine (), out number);
                    if (!isINT) {
                        Console.WriteLine ("Giá trị sai vui lòng nhập lại. ");
                        Console.Write ("#Chọn: ");
                    } else if (number < 0 || number > 4) {
                        Console.WriteLine ("Giá trị sai vui lòng nhập lại từ 1 - 3.");
                        Console.Write ("#Chọn : ");
                    } else {
                        break;
                    }
                }
                /*
                 TryParse phương pháp không ném một ngoại lệ nếu chuyển đổi thất bại. Nó loại bỏ sự cần thiết phải sử dụng xử lý ngoại lệ
                 để kiểm tra cho một Format Exception trong trường hợp không hợp lệ và không thể được thành công phân tích cú pháp.
                */
                Console.WriteLine ("=============================================================");
                switch (number) {
                    case 1:
                        Console.Clear ();
                        Itemshop listitem = new Itemshop();
                        listitem.ShowItem();
                        break;
                    // case 2:
                    //     Console.Clear ();
                    //     Shopping Shop = new Shopping();
                    //     Shop.OrderItem();
                    //     break;
                    case 3:
                        return;
                }
            }
        }
        public static void MenuCinema () {
            string[] menu = { "Mặt Hàng.", "Thanh Toán.", "Đăng Xuất.", "#Chọn: " };
            Console.WriteLine ("=============================================================");
            Console.WriteLine ("------------- Chào Mừng Đến Với Hệ Thống Mua Hàng -----------");
            Console.WriteLine ("=============================================================");
            for (int i = 0; i < 4; i++) {
                if (i != 3) {
                    Console.WriteLine ($"{i+1}. {menu[i]}");
                } else {
                    Console.WriteLine ("------------------------------------------------------------- ");
                    Console.Write ($"{menu[i]}");
                }
            }
            
        }
    }
}
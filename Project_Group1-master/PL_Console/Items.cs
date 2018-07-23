using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL;
using Persistence;

namespace PL_Console {
    class Itemshop {
        public void ShowItem () {
            while (true) {
                Console.WriteLine ("*********************************************************************************");
                Console.WriteLine ("--- 	Danh sách mặt hàng ---");
                Console.WriteLine ("---------------------------------------------------------------------------------");
                Console.WriteLine("Mã sản phẩm   | Tên mặt hàng    |     Giá Tiền    |    Số Lượng");
                ListItem();
                
            }
        }
        // Lấy ra và hiển thị các mặt hàng. 
        public void ListItem () {
            Item_BL item = new Item_BL ();
            Console.WriteLine ();
            foreach (var Item in item.GetItems ()) {
                string format = string.Format ($"{Item.ItemId,1}.     {Item.ItemName,15}   {Item.Price,17}       {Item.Amount,12} \n");
                Console.WriteLine (format);
            }
            Console.WriteLine ("--------------------------------------------------------------------------------------------");
        

       
            Console.WriteLine ($"");
            Console.WriteLine ("--------------------------------------------------------------------------------------------");
            Console.WriteLine ("1. Mua hàng.");
            Console.WriteLine ("\n2. Trở về menu chính.");
            Console.WriteLine ("--------------------------------------------------------------------------------------------");

            Console.Write ("#Chọn : ");
            int number;
            while (true) {
                bool isINT = Int32.TryParse (Console.ReadLine (), out number);
                if (!isINT) {
                    Console.WriteLine ("Giá trị sai vui lòng nhập lại");
                    Console.Write ("#Chọn : ");
                } else if (number < 0 || number > 2) {
                    Console.WriteLine ("Giá trị sai vui lòng nhập lại 1 - 2. ");
                    Console.Write ("#Chọn : ");
                } else {
                    break;
                }
            }
            switch (number) {
                // case 1:
                //     Shopping ticket = new Shopping ();
                //     ticket.OrderItem();
                //     break;
                case 2:
                    ShopInterface shop = new ShopInterface ();
                    shop.Shop ();
                    break;

            // // }
            // Console.WriteLine ();
            }
        }

        }
    }


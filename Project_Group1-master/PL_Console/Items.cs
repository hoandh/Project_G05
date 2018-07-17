using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL;
using Persistence;

namespace PL_Console {
    class Iteminterface{
        public void itemlist (){
        
        while (true){
        Console.WriteLine("------Mat Hang-------"\n);
        Console.WriteLine("1.xem danh sach mat hang\n2.mua hang");
        Console.WriteLine("#choice");
        int choose = int.Parse(Console.ReadLine());
            switch (choose){
                case 1: 
                showitemlist();
                break;
                case 2:
                buyItem()
                break; 
                default :
                    Console.WriteLine("Vui lòng nhập lại số từ 1 đến 2");
                    

    public void showitemlist()
    {
    Console.WriteLine("______________DANH SACH MAT HANG__________________");
    for (int i =1, i< lstItem.Count , i++){
         Console.WriteLine(lstItem[i].ItemID + "\t|"+ lstItem[i].ItemName +"\t|" lstItem[i].Amount+"\t|"lstItem[i].Price);
        }
    }
    
}


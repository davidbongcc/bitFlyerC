using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
namespace consoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
          Dictionary<int,Transaction> block = new Dictionary<int,Transaction>();
          const int MAXBLOCKSIZE = 1000000;
          const double BONUS = 12.5;
          int blockSize =0;
          double totalFee=0.0;
           List<Transaction> alist= new List<Transaction>();
           alist.Add(new Transaction(1,57247,0.0887));
           alist.Add(new Transaction(2,98732,0.1856));
           alist.Add(new Transaction(3,134928,0.2307));
           alist.Add(new Transaction(4,77275,0.1522));
           alist.Add(new Transaction(5,29240,0.0532));
           alist.Add(new Transaction(6,15440,0.0250));
           alist.Add(new Transaction(7,70820,0.1409));
           alist.Add(new Transaction(8,139603,0.2541));
           alist.Add(new Transaction(9,63718,0.1147));
           alist.Add(new Transaction(10,143807,0.2260));
           alist.Add(new Transaction(11,190457,0.2933));
           alist.Add(new Transaction(12,40572,0.0686));

           var SortedList = (from l in alist
                        orderby l.Size descending
                        select l).ToList();
               SortedList.ForEach((x)=>{
               var hashedCode = x.GetHashCode();
              
                    if(blockSize + x.Size <=MAXBLOCKSIZE){
                    block.Add(hashedCode,new Transaction(x.Id,x.Size,x.Fee));
                    blockSize += x.Size;
                    totalFee += x.Fee;
                    }
            });


            Console.WriteLine(String.Format("totalSize:{0},totalFee:{1}",blockSize,totalFee + BONUS));
            Console.ReadLine();
          
        }
    }
}

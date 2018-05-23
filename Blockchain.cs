using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

class Blockchain{
    public int NodeId;
    public IList<Transaction> Open_transaction;
    public IList<Block> Publicchain;
    public Blockchain(int nodeId){
        this.NodeId = nodeId;
        this.Open_transaction = new List<Transaction>();
        this.Publicchain = new List<Block>();

    }
   public void addUnhandleBlock(int id,int size,double fee){
        Open_transaction.Add(new Transaction(id,size,fee));
   }
   /*
    This is the core mining function to mine the selected transaction in a Block.
    This is just a very rough design. This function should consits of the transaction validation, hashing function, 
    and the mininig reward to the miner's digital wallet(Public key).
    */
    public Tuple<int,double> mineBlock(){
         int blockSize =0;
          double totalFee=0.0;
     IList<Transaction> selectedTransaction = new List<Transaction>();
           var SortedList = (from l in Open_transaction
                        orderby l.Size descending
                        select l).ToList();

               SortedList.ForEach((x)=>{
               var hashedCode = x.GetHashCode();
                    if(blockSize + x.Size <=1000000){
                     blockSize += x.Size;
                     totalFee += x.Fee;
                    selectedTransaction.Add(x);
                    }
            });
              
            var dummyHashed = new Random();
            Publicchain.Add(new Block(dummyHashed.Next(),dummyHashed.GetHashCode().ToString(),selectedTransaction,DateTime.Now));
                 
        
        return Tuple.Create(blockSize,totalFee+ 12.5);
    }
}
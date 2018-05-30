using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

class Blockchain{
    public int NodeId;
    public IList<Transaction> Open_transaction;
    public IList<Block> Publicchain;
    public int MaxBlockSize;

    public double Bonus;
    public Blockchain(int nodeId,int maxBlockSize, double bonus=0){
        this.NodeId = nodeId;
        this.Open_transaction = new List<Transaction>();
        this.Publicchain = new List<Block>();
        this.MaxBlockSize = maxBlockSize;
        this.Bonus = bonus;
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
            var space=0;
            var totalSize=0;
            for(int i=0; i < SortedList.Count;i++){
            if(SortedList.Count < 0)
                break;
                
           
                space  = MaxBlockSize -totalSize; 

                if(SortedList[i].Size <= space)
                {
                    totalSize +=SortedList[i].Size;
                }else
                {
                    //break;
                }


            }
            totalFee +=  Bonus;
            var dummyHashed = new Random();
            Publicchain.Add(new Block(dummyHashed.Next(),dummyHashed.GetHashCode().ToString(),selectedTransaction,DateTime.Now,blockSize,totalFee));
            selectedTransaction.ToList().ForEach((x)=>{
                    Console.WriteLine(String.Format("Selected Item : Size:{0},Fee:{1}",x.Size,x.Fee));
            });
            SortedList.ForEach((x)=>{
                    Console.WriteLine(String.Format("Remaining Item : Size:{0},Fee:{1}",x.Size,x.Fee));
            });
                 
        
        return Tuple.Create(blockSize,totalFee);
    }
}
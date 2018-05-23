using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
struct Block{

    public int Index;
    public string PreviousHash;
    public IList<Transaction> Transactions;
    public DateTime dateTime;
    public Block(int index,string previous_hash,IList<Transaction> transactions,DateTime datetime){
        this.Index = index;
        this.PreviousHash = previous_hash;
        this.Transactions = transactions;
        this.dateTime = datetime;
    }
}
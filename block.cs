using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
struct Block{

    public int Index;
    public string PreviousHash;
    public IList<Transaction> Transactions;
    public DateTime dateTime;
    public int ActualSize;
    public double TotalReward;
    public Block(int index,string previous_hash,IList<Transaction> transactions,DateTime datetime,int actualSize,double totalReward){
        this.Index = index;
        this.PreviousHash = previous_hash;
        this.Transactions = transactions;
        this.dateTime = datetime;
        this.TotalReward = totalReward;
        this.ActualSize = actualSize;
    }
}
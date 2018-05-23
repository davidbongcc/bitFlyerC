struct Transaction{
    public int Id;
    public int Size;
    public double Fee;
    public Transaction(int id,int size,double fee){

        this.Size = size;
        this.Fee = fee;
        this.Id = id;

    }
}
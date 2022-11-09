class prog
{
    static void Main()
    {
        Facade fac = new Facade();
        fac.Replenishment();
        fac.ReceiveMoney();
    }
}
class ReceiveCreditCard
{
    public void ReceiveCC()
    {
        Console.WriteLine("A credit Card has been inserted");
    }
}
class MoneyOp
{
    public void AmountOfMoney()
    {
        Console.WriteLine("An amount of money has been entered");
    }
}
class ReplenishmentOp
{
    public void Replenishment()
    {
        Console.WriteLine("Replenishment has been made");
    }
}
class MoneyOut
{
    public void Money_Out()
    {
        Console.WriteLine("Money has been given to the user");
    }
}
class Facade
{
    ReceiveCreditCard rcc;
    MoneyOp mo;
    ReplenishmentOp ro;
    MoneyOut moout;
    public Facade()
    {
        rcc = new ReceiveCreditCard();
        mo=new MoneyOp();
        ro=new ReplenishmentOp();
        moout = new MoneyOut();
    }
    public void Replenishment()
    {
        rcc.ReceiveCC();
        mo.AmountOfMoney();
        ro.Replenishment();
    }
    public void ReceiveMoney()
    {
        rcc.ReceiveCC();
        mo.AmountOfMoney();
        moout.Money_Out();
    }
}
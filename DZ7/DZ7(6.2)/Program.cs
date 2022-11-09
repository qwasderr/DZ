using System;

class prog
{
    static void Main()
    {
        var sys2 = new System2();
        Controller.Out(sys2);
        var sys1 = new System1();
        // Controller.Out(sys1); error
        var adapter = new Adapter(sys1);
        Controller.Out(adapter);
    }
}
class System1
{
    public void NonSpecialOutput()
    {
        Console.WriteLine("This is a non special output");
    }
}
interface ISpecial
{
    void SpecialOutput();
}
class System2: ISpecial
{
    public void SpecialOutput()
    {
        Console.WriteLine("This is a special output");
    }
}
class Adapter: ISpecial
{
    private System1 sys1;
    public Adapter(System1 sys1)
    {
        this.sys1 = sys1;
    }
    public void SpecialOutput()
    {
        sys1.NonSpecialOutput();
    }
}
class Controller
{
    public static void Out(ISpecial i)
    {
        i.SpecialOutput();
    }
}

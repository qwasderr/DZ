using System;
using System.ComponentModel;
using System.Collections;
class prog
{
    static void Main()
    {
        ConcreteCTree tree = new ConcreteCTree();
        DecoratorDec dec1 = new DecoratorDec();
        DecoratorLight dec2 = new DecoratorLight();
        DecoratorDec dec3 = new DecoratorDec();
        DecoratorLight dec4 = new DecoratorLight();
        dec1.SetComponent(tree);
        dec2.SetComponent(dec1);
        dec3.SetComponent(dec2);
        dec4.SetComponent(dec3);
        dec4.Light();
    }
}
/*class Ctree
{
    private List<string> dec;

}*/
abstract class CTree
{
    public abstract void Light();
}

class ConcreteCTree : CTree
{
    public override void Light()
    {
        //Console.WriteLine("ConcreteCTree.Light()");
    }
}
abstract class Decorator : CTree
{
    protected CTree ctree;
    public void SetComponent(CTree ctree)
    {
        this.ctree = ctree;
    }
    public override void Light()
    {
        if (ctree != null)
        {
            ctree.Light();
        }
    }
}
class DecoratorDec: Decorator
{
    private string decoration;
    
    public override void Light()
    {
        base.Light();
        var list = new List<string> { "tree", "snowman", "santa", "deer" };
        var random = new Random();
        decoration = list[random.Next(list.Count)];
        Console.WriteLine("Added {0} decoration", decoration);
    }
}
class DecoratorLight: Decorator
{
    public override void Light()
    {
        base.Light();
        Light_Add();
    }
    public void Light_Add()
    {
        var list = new List<string> { "red", "green", "blue", "yellow" };
        var random = new Random();
        string colour = list[random.Next(list.Count)];
        Console.WriteLine("Added {0} lights", colour);
    }
}
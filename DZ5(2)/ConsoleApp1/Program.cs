// See https://aka.ms/new-console-template for more information
class a
{
    public void r()
    {
        Console.WriteLine("qqq");
    }
}
class b : a
{
    public void g()
    {
        Console.WriteLine("fhgfh");
    }
}
class Prog
{
    static void Main()
    {
        List<a> g = new List<a>();
        
        a fg=new b();
        fg = (b)fg;
        g.Add(fg);
        fg.g();
        
    }
}
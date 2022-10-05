// See https://aka.ms/new-console-template for more information
using System.Dynamic;
using System.Xml.Linq;

public interface Geo
{
    double GetX();
    double GetY();
    string GetName();
    string GetDescription();
      

    void SetX(double x);
    void SetY(double y);
    void SetName(string name);
    void SetDescription(string descr);

}
public interface IRiver
{
    double GetSpeed();
    double GetLen();
    void SetSpeed(double speed);
    void SetLen(double len);
}
public interface IMount
{
    double GetPeak();
    void SetPeak(double peak);
}
abstract class GeoObject: Geo
{
    double x, y;
    string name = "", descr = "", method = "virtual";
    public double GetX()
    {
        return x;
    }
    public double GetY()
    {
        return y;
    }
    public string GetName()
    {
        return name;
    }
    public string GetDescription()
    {
        return descr;
    }
    public void SetX(double x)
    {
        this.x = x;
    }
    public void SetY(double y)
    {
        this.y = y;
    }
    public void SetName(string name)
    {
        this.name = name;
    }
    public void SetDescription(string descr)
    {
        this.descr = descr;
    }

}
class River : GeoObject, IRiver
{
    double speed, length;
    public double GetSpeed()
    {
        return speed;
    }
    public double GetLen()
    {
        return length;
    }
    public void SetSpeed(double speed)
    {
        this.speed = speed;
    }
    public void SetLen(double len)
    {
        length = len;
    }
   

}
class Mount : GeoObject, IMount
{
    double peak;
    public double GetPeak()
    {
        return peak;
    }
    public void SetPeak(double peak)
    {
        this.peak = peak;
    }
   
}
class prog2
{
    static void Main()
    {

    }
}

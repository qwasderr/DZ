using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/
//Interface Segregation Principle
interface IItem
{
    

    

    
}
interface IApply_SetPrice
{
    void ApplyDiscount(String discount);
    void ApplyPromocode(String promocode);
    void SetPrice(double price);
}
interface ISet
{
    void SetColor(byte color);
    void SetSize(byte size);
    
}
class Book : IApply_SetPrice
{
    double price;
    public void ApplyDiscount(string discount)
    {

    }
    public void ApplyPromocode(string promocode)
    {

    }
    public void SetPrice(double price)
    {
        this.price = price;
    }
}
class Clothes : ISet, IApply_SetPrice
{
    double price;
    byte color, size;
    public void ApplyDiscount(string discount)
    {

    }
    public void ApplyPromocode(string promocode)
    {

    }
    public void SetPrice(double price)
    {
        this.price = price;
    }
    public void SetColor(byte color)
    {
        this.color = color;
    }
    public void SetSize(byte size)
    {
        this.size = size;
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Console.ReadKey();
    }
}
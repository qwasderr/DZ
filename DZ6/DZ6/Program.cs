using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using (FileStream fs = new FileStream("C:/json.json", FileMode.OpenOrCreate))
{
   
    var book =  await JsonSerializer.DeserializeAsync<List<Book>>(fs);
    foreach (var b in book)
    {
        Console.WriteLine($"{b.PublishingHouseId} - {b.Title} - {b.PublishingHouse.Id} - {b.PublishingHouse.Name} - {b.PublishingHouse.Adress}");
    }
}


public class Book
{
    //[JsonIgnore]; - без серіалізації
    public int PublishingHouseId { get; set; }
    
    //[JsonPropertyName("Name")]; - зміна ім'я поля
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
    //public PublishingHouse PublishingHouse - без десеріалізації 
    public Book(int publishingHouseId, string title)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;
        PublishingHouse = new PublishingHouse();
        
    }


}
public class PublishingHouse
{
   
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
   
}

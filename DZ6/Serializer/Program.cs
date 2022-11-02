using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using (FileStream fs = new FileStream("C:/json.json", FileMode.Create))
{
    var opt = new JsonSerializerOptions
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
    };
    var book = new List<Book>();
    book.Add(new Book(25, "123", 34, "First", "Adress1"));
    book.Add(new Book(34, "12453", 21, "Second", "Adress2"));
    /*var book = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
    foreach (var b in book)
    {
        Console.WriteLine($"{b.PublishingHouseId} - {b.Title} - {b.PublishingHouse.Id} - {b.PublishingHouse.Name} - {b.PublishingHouse.Adress}");
    }*/
    await JsonSerializer.SerializeAsync(fs,book,opt);
}

/*var book = new List<Book>();
book.Add(new Book(25, "123", 34, "First", "Adress1"));
book.Add(new Book(34, "12453", 21, "Second", "Adress2"));
Console.WriteLine(JsonSerializer.Serialize(book));*/

public class Book
{
    [JsonIgnore]
    public int PublishingHouseId { get; set; }

    [JsonPropertyName("Name")]
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
    //public PublishingHouse PublishingHouse - без десеріалізації 
    public Book(int publishingHouseId, string title, int id, string name, string adress)
    {
        PublishingHouseId = publishingHouseId;
        Title = title;
        PublishingHouse = new PublishingHouse(id, name, adress);


    }


}
public class PublishingHouse
{
    public PublishingHouse(int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }

}


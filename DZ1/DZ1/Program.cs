// See https://aka.ms/new-console-template for more information
try
{
    Console.WriteLine("Type int number");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Ви ввели число " + n);
}
catch
{
    Console.WriteLine("INT NUMBER, do you know how to read?");
}


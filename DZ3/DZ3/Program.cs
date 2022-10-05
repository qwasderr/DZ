// See https://aka.ms/new-console-template for more information
class prog
{
    class Converter
    {
        private decimal usd_hrn = 36.82m, eur_hrn = 35.74m;
        public Converter(decimal usd_hrn, decimal eur_hrn)
        {
            this.usd_hrn = usd_hrn;
            this.eur_hrn = eur_hrn;
        }
        public decimal HrnToUsd(decimal hrn)
        {
            return hrn / usd_hrn;
        }
        public decimal HrnToEur(decimal hrn)
        {
            return hrn / eur_hrn;
        }
        public decimal UsdToHrn(decimal usd)
        {
            return usd * usd_hrn;
        }
        public decimal EurToHrn(decimal eur)
        {
            return eur * eur_hrn;
        }
    }
    static void Main()
    {
        int choice;
        int i = 0,j=0;
        decimal usd_to_hrn=36.82m, eur_to_hrn=35.74m, hrn=0, usd=0, eur=0, temp=0;
        while (i == 0)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter Usd/Hrn");
                //decimal k = decimal.Parse(Console.ReadLine());
                
                j = 0;
                while (j == 0)
                {
                    temp = Convert.ToDecimal(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Incorrect input");
                    else
                    {
                        usd_to_hrn = temp;
                        j = 1;
                    }
                    
                }
                Console.WriteLine("Enter Eur/Hrn");
                j = 0;
                while (j == 0)
                {
                    temp = Convert.ToDecimal(Console.ReadLine());
                    if (temp <= 0) Console.WriteLine("Incorrect input");
                    else
                    {
                        eur_to_hrn = temp;
                        j = 1;
                    }
                }
                    
                i = 1;

            }
            catch
            {
                i = 0;
                Console.WriteLine("Wrongh input, use ',' except '.' ");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
        Converter conv = new Converter(usd_to_hrn, eur_to_hrn);
        while (true)
        {
            Console.Clear();
            i = 0;
            while (i == 0)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Write Hrn amount");
                    j = 0;
                    while (j == 0)
                    {
                        temp = Convert.ToDecimal(Console.ReadLine());
                        if (temp <= 0) Console.WriteLine("Incorrect input");
                        else
                        {
                            hrn = temp;
                            j = 1;
                        }
                    }
                    i = 1;
                }
                catch
                {
                    i = 0;
                    Console.WriteLine("Wrongh input, use ',' except '.' ");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Hrn_To_Usd");
            Console.WriteLine("2 - Hrn_To_Eur");
            Console.WriteLine("3 - Usd_To_Hrn");
            Console.WriteLine("4 - Eur_To_Hrn");
            
                choice = Convert.ToInt32(Console.ReadLine());
                while (choice <= 0 || choice > 4)
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Wrong input, type again");
                }
                if (choice == 1)
                {
                    Console.WriteLine(Convert.ToString(conv.HrnToUsd(hrn))+" usd");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                    

                }
                else if (choice == 2)
                {
                    Console.WriteLine(Convert.ToString(conv.HrnToEur(hrn))+" eur");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                    
                }
                else if (choice == 3)
                {
                i = 0;
                    while (i == 0) {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Write Usd amount");
                        j = 0;
                        while (j == 0)
                        {
                            temp = Convert.ToDecimal(Console.ReadLine());
                            if (temp <= 0) Console.WriteLine("Incorrect input");
                            else
                            {
                                usd = temp;
                                j = 1;
                            }
                        }
                        Console.WriteLine(Convert.ToString(conv.UsdToHrn(usd)) + " hrn");
                        i = 1;
                    }
                    catch
                    {
                        i = 0;
                        Console.WriteLine("Wrongh input, use ',' except '.' ");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                    
                }
                else
                {
                i = 0;
                    while (i == 0) {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Write Eur amount");
                        j = 0;
                        while (j == 0)
                        {
                            temp = Convert.ToDecimal(Console.ReadLine());
                            if (temp <= 0) Console.WriteLine("Incorrect input");
                            else
                            {
                                eur = temp;
                                j = 1;
                            }
                        }
                        Console.WriteLine(Convert.ToString(conv.EurToHrn(eur)) + " hrn");
                        i = 1;
                    }
                    catch
                    {
                        i = 0;
                        Console.WriteLine("Wrongh input, use ',' except '.' ");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }
                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
                    
                }
            }
        }
    }



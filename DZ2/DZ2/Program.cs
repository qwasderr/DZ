// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System.Xml;

class Prog
{
    abstract class Worker
    {
        protected string Name = "", Position = "", WorkDay = "";
        Worker(string Name)
        {
            this.Name = Name;
        }
        protected Worker() { }
        public void Call() { }
        public void WriteCode() { }
        public void Relax() { }
        public void SetName(string Name)
        {
            this.Name = Name;
        }
        public void SetWorkDay(string Day)
        {
            WorkDay = Day;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetPosition()
        {
            return Position;
        }
        public string GetWorkDay()
        {
            return WorkDay;
        }
        public abstract void FillWorkDay();

    }
    class Developer : Worker
    {
        public Developer()
        {
            this.Position = "Розробник";
        }
        override public void FillWorkDay()
        {
            Call();
            WriteCode();
            Relax();
        }
    }
    class Manager : Worker
    {
        public Manager()
        {
            this.Position = "Менеджер";
        }
        private Random r = new Random();
        public override void FillWorkDay()
        {
            for (int i = 0; i < r.Next(1, 10); ++i) Call();
            Relax();
            for (int i = 0; i < r.Next(1, 5); ++i) Call();
        }
    }
    class Team
    {
        private string TeamName = "";
        public Team(string TeamName)
        {
            this.TeamName = TeamName;
        }
        private Worker[] w = new Worker[100];
        private int count = 0;
        public void AddWorker(string name, int type, string day)
        {
            if (type == 1)
            {
                w[count] = new Developer();
                w[count].SetName(name);
                w[count].SetWorkDay(day);
                ++count;
            }
            else if (type == 2)
            {
                w[count] = new Manager();
                w[count].SetName(name);
                w[count].SetWorkDay(day);
                ++count;
            }
        }
        public void ShowWorkers()
        {
            Console.WriteLine(TeamName);
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine(w[i].GetName());
            }
        }
        public void ShowMore()
        {
            Console.WriteLine(TeamName);
            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine(w[i].GetName() + " - " + w[i].GetPosition() + " - " + w[i].GetWorkDay());
            }
        }
        public string GetTeamName()
        {
            return TeamName;
        }
    }
    static void Main()
    {
        int i=0;
        string name;
        int pick=-1;
        int tcount = 0;
        string WorkerName;
        string WorkerDay;
        int typepick;
        Team[] t = new Team[100];
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose Option:");
            Console.WriteLine("1 - Show teams");
            Console.WriteLine("2 - Add Team");
            Console.WriteLine("3 - Add Member");
            Console.WriteLine("4 - Show Members (short info)");
            Console.WriteLine("5 - Show Members");
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
            }

            if (i == 1)
            {
                Console.Clear();
                if (tcount == 0)
                {
                    Console.WriteLine("Nothing is here... Come back later");
                }
                else
                {
                    for (int j = 0; j < tcount; ++j)
                    {
                        Console.WriteLine(t[j].GetTeamName());
                    }
                }
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
            else if (i == 2)
            {
                Console.Clear();
                Console.WriteLine("Write a team name");
                name = Console.ReadLine();
                Team teamm = new Team(name);

                t[tcount] = teamm;
                Console.WriteLine(t[0].GetTeamName());
                ++tcount;
            }
            else if (i == 3)
            {
                Console.Clear();
                if (tcount == 0)
                {
                    Console.WriteLine("You don't have any teams, create firstly");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Pick a team");
                    for (int j = 0; j < tcount; ++j)
                    {
                        Console.WriteLine(Convert.ToInt32(j + 1) + "  " + t[j].GetTeamName());
                    }
                    try
                    {
                        pick = Convert.ToInt32(Console.ReadLine());
                        while (pick > tcount)
                        {
                            Console.WriteLine("Wrong input, type again");
                            pick = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.Clear();
                        Console.WriteLine("Write a worker's name");
                        WorkerName = Console.ReadLine();
                        Console.WriteLine("Write a worker's WorkerDay");
                        WorkerDay = Console.ReadLine();
                        Console.WriteLine("Choose a worker type (1-developer, 2-manager)");
                        typepick = Convert.ToInt32(Console.ReadLine());
                        t[pick - 1].AddWorker(WorkerName, typepick, WorkerDay);
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input");
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                    }

                }
            }
            else if (i == 4)
            {
                Console.Clear();
                if (tcount == 0)
                {
                    Console.WriteLine("You don't have any teams, create firstly");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Pick a team");
                    for (int j = 0; j < tcount; ++j)
                    {
                        Console.WriteLine(Convert.ToInt32(j + 1) + "  " + t[j].GetTeamName());
                    }
                    try
                    {
                        pick = Convert.ToInt32(Console.ReadLine());
                        while (pick > tcount)
                        {
                            Console.WriteLine("Wrong input, type again");
                            pick = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.Clear();
                        t[pick - 1].ShowWorkers();
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input");
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
            }
            else if (i == 5)
            {
                Console.Clear();
                if (tcount == 0)
                {
                    Console.WriteLine("You don't have any teams, create firstly");
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Pick a team");
                    for (int j = 0; j < tcount; ++j)
                    {
                        Console.WriteLine(Convert.ToInt32(j + 1) + "  " + t[j].GetTeamName());
                    }
                    try
                    {
                        pick = Convert.ToInt32(Console.ReadLine());
                        while (pick > tcount)
                        {
                            Console.WriteLine("Wrong input, type again");
                            pick = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.Clear();
                        t[pick - 1].ShowMore();
                    }
                    catch
                    {
                        Console.WriteLine("Wrong input");
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Wrong input");
                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }

    }
}


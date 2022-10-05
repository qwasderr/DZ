// See https://aka.ms/new-console-template for more information

    class prog
    {


        abstract class GeoObject
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
        class River : GeoObject
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
        class Mount : GeoObject
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

        static void Main(string[] args)
        {

        }
    }
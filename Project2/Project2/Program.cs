using System.Text;
using System.Xml;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using System.Xml.Xsl;

class Program
{
    public static void parsingXmlDocument()
    {
        try
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("Doc.xml"));
            RecurseNodes(xmlDoc.DocumentElement);
        }
        catch
        {
            Console.WriteLine("Error");
        }

    }

    public static void RecurseNodes(XmlNode node)
    {
        var sb = new StringBuilder();
        RecurseNodes(node, 0, sb);
        Console.WriteLine(sb.ToString());

    }
    
    public static void RecurseNodes(XmlNode node, int level, StringBuilder sb)
    {
        try
        {
            sb.AppendFormat("{0,-2} Type:{1,-9} Name:{2,-13} Attr:",level, node.NodeType, node.Name);
            foreach (XmlAttribute attr in node.Attributes)
            {
                sb.AppendFormat("{0}={1} ", attr.Name, attr.Value);
            }
            sb.AppendLine();
            foreach (XmlNode n in node.ChildNodes)
            {
                RecurseNodes(n, level + 1, sb);
            }
        }
        catch
        {
            Console.WriteLine("Error");
        }

    }
    
    public static string getFilePath(string fileName)
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
    }

    public static void searchingInXmlDocument()
    {
        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("Doc.xml"));
            var node = xmlDoc.SelectSingleNode("//Game[@ID='2']");
            RecurseNodes(node);
        }
        catch
        {
            Console.WriteLine("Error");
        }

    }

    public static void parsingWithXmlTextReader()
    {
        try
        {
            var sb = new StringBuilder();
            var xmlReader = new XmlTextReader(getFilePath("Doc.xml"));
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.Element:
                    case XmlNodeType.Comment:
                        sb.AppendFormat("{0}: {1} = {2}", xmlReader.NodeType, xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                        break;
                    case XmlNodeType.Text:
                        sb.AppendFormat(" - Value: {0}", xmlReader.Value);
                        sb.AppendLine();
                        break;
                }
                if (xmlReader.HasAttributes)
                {
                    while (xmlReader.MoveToNextAttribute())
                    {
                        sb.AppendFormat(" - Attribute: {0} = {1}", xmlReader.Name, xmlReader.Value);
                        sb.AppendLine();
                    }
                }
            }
            xmlReader.Close();
            Console.WriteLine(sb.ToString());
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }

    public static void getElementsByTagName()
    {
        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("Doc.xml"));
            var elmts = xmlDoc.GetElementsByTagName("Dev");
            var sb = new StringBuilder();
            foreach (XmlNode node in elmts)
            {
                RecurseNodes(node, 0, sb);
            }
            Console.WriteLine(sb.ToString());
        }
        catch
        {
            Console.WriteLine("Error");
        }

    }
    
    public static void selectNodesTool()
    {
        try
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(getFilePath("Doc.xml"));
            var elmts = xmlDoc.SelectNodes("//Crew");
            var sb = new StringBuilder();
            foreach (XmlNode node in elmts)
            {
                RecurseNodes(node, 0, sb);
            }
            Console.WriteLine(sb.ToString());
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }
    
    public static void XmlTextReaderSearch()
    {
        /* int i = 0;
         var xmlReader = new XmlTextReader(getFilePath("Doc.xml"));
         while (xmlReader.Read())
         {
             if (xmlReader.Name == "Dev") { parsingWithXmlTextReader(xmlReader); i = 1; }
             xmlReader.MoveToNextAttribute();
         }
         if (i == 0) Console.WriteLine("Nothing has been found");
         xmlReader.Close();
     }*/
        //var sb = new StringBuilder();
        var xmlReader = new XmlTextReader(getFilePath("Doc.xml"));
        while (xmlReader.Read())
        {
            while (xmlReader.ReadToFollowing("Dev")) Console.WriteLine("Attributes: {0}, {1}", xmlReader.GetAttribute("NAME_D"), xmlReader.GetAttribute("AGE"));

            /*do
            {
                Console.WriteLine("Attributes: {0}, {1}", xmlReader.GetAttribute("NAME_D"), xmlReader.GetAttribute("AGE"));
            } while (xmlReader.ReadToNextSibling("Dev"));*/
        }
    }

    public static void LINQSearch()
    {
        try
        {
            var doc = XDocument.Load(getFilePath("Doc.xml"));
            var result = (from dev in doc.Descendants("Dev")
                          where dev.Attributes("AGE").Any(z => Convert.ToInt32(z.Value) > 30)
                          select new
                          {
                              Name = dev.Attribute("NAME_D"),
                              Age = (int)dev.Attribute("AGE")
                          }).Distinct().ToList();
            foreach (var b in result)
            {
                Console.WriteLine(string.Format("Name:{0}\nAge:{1}", b.Name, b.Age));
            }
        }
        catch
        {
            Console.WriteLine("Error");
        }
    }

    public static void Transform()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        string f1 = getFilePath("Style.xsl");
        xslt.Load(f1);
        string f2 = getFilePath("Doc.xml");
        string f3 = getFilePath("Doc_T.html");
        xslt.Transform(f2, f3);
    }
}
    class Program_Main
    {
        public static void Main(string[] args)
    {
        Program.parsingXmlDocument();
        Program.searchingInXmlDocument();
        Program.parsingWithXmlTextReader();
        Program.getElementsByTagName();
        Program.selectNodesTool();
        Program.XmlTextReaderSearch();
        Program.LINQSearch();
        Program.Transform();
        Console.ReadKey();
    }
    }

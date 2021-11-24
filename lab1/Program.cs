using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace lab1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            List<student> ISP171 = new List<student>();
            ISP171.Add(new student("Гурин", 18, "М"));
            ISP171.Add(new student("Малородов", 18, "М"));
            ISP171.Add(new student("Саврасов", 18, "М"));
            ISP171.Add(new student("Чайкина", 18, "Ж"));
            ISP171.Add(new student("Юсов", 18, "М"));

            group ISP17 = new group("ИСП-17", ISP171, "Инофрмационные Системы и программирование", "Умнова Т. В.");
            ISP17.GroupInfo();
            Console.WriteLine();

            List<student> ISP181_182 = new List<student>();
            ISP181_182.Add(new student("Гурин", 18, "М"));
            ISP181_182.Add(new student("Малородов", 18, "М"));
            ISP181_182.Add(new student("Саврасов", 18, "М"));
            ISP181_182.Add(new student("Чайкина", 18, "Ж"));
            ISP181_182.Add(new student("Юсов", 18, "М"));

            group ISP18 = new group("ИСП-18", ISP181_182, "Инофрмационные Системы и программирование", "Умнова Т. В.");
            ISP18.GroupInfo();

            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("group1.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, ISP181_182);
            }

            var xmlFormatter = new XmlSerializer(typeof(List<student>));
            using (var file = new FileStream("group.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, ISP181_182);
            }
            /*
            */
            var jsonFormatter = new DataContractJsonSerializer(typeof(student[]));
            using (var file = new FileStream("group.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, ISP17.GroupList.ToArray());
            }
            Console.ReadKey();
        }
    }
}
/*

*/
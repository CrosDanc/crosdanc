using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace lab1
{
    [DataContract]
    class group
    {
        public group()
        {
        }

        public group(string name, List<student> studentsList, string specialty, string curator)
        {
            GroupList = studentsList;
            _name = name;
            _specialty = specialty;
            _curator = curator;
        }
        public string _name = "";
        public List<student> GroupList;
        public string _specialty = "";
        public string _curator = "";

        public void GroupInfo()
        {
            Console.Write($"Название группы: {_name} ");
            Console.Write($"Спецальность: {_specialty}");
            Console.WriteLine($"Куратор группы: {_curator}");
            Console.WriteLine($"Список группы:");
            for (int i = 0; i < GroupList.Count; i++)
            {
                Console.Write((i + 1) + ". ");
                GroupList[i].StudentInfo();
                Console.WriteLine();
            }
        }
    }
}

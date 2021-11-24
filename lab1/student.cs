using System;

namespace lab1
{
    [Serializable]
     public class student
    {
        public student()
        { }

        public student(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name = "";
        
        public int Age = 0;

        public string Gender = "";

        public void StudentInfo()
        {
            Console.Write($"Имя: {Name}, ");
            Console.Write($"Возраст: {Age}, ");
            Console.Write($"Пол: {Gender};");
        }
    }
}

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Vovk.Lab9.Zadanie1
{
    public class Tables
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Phone { get; set; }
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public string Tag { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {
            return $"{Id} Name: {Name}  Email: {Email} Age : {Age } City: {City} Street: {Street }Phone: {Phone }  CustomerId: { CustomerId}  ProductId: {ProductId}  Tag:{Tag} Price: {Price}";
        }
    }
    internal class Tablees
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string path = @"C:\Users\667\source\repos\Vovk.Lab-9.Nom1\Vovk.Lab-9.Nom1\bin\Debug\net6.0\table.csv";
            string line;
            Console.WriteLine(path);
            var lines = File.ReadAllLines(path);
            int g = lines.Length - 1;
            Console.WriteLine("Людей в списке: " + g);
            var persons = new Person[lines.Length + 1];
            for (var i = 0; i < lines.Length + 1; i++)
            {
                if (i < 40)
                {
                    var splits = lines[i + 1].Split(',');
                    var person = new Person();
                    person.Id = i + 1;
                    person.Name = splits[1];
                    person.Email = splits[2];
                    person.Phone = splits[3];
                    person.Age = Convert.ToInt32(splits[4]);
                    person.City = splits[5];
                    person.Street = splits[6];
                    person.Tag = splits[7];
                    person.Price = Convert.ToInt32(splits[8]);
                    person.CustomerId = splits[9];
                    person.ProductId = splits[10];
                    persons[i] = person;
                    line = person.ToString();
                    //Console.WriteLine(line);
                }
                else
                {
                    var person = new Person();
                    person.Id = i + 1;
                    person.Name = "1";
                    person.Email = "1";
                    person.Phone = "1";
                    person.Age = 2;
                    person.City = "1";
                    person.Street = "1";
                    person.Tag = "1";
                    person.Price = 2;
                    person.CustomerId = "1";
                    person.ProductId = "1";
                    persons[i] = person;
                }
            }
            Console.WriteLine("Добавление 2 новых записей");
            for (var i = 1; i < 3; i++)
            {
                Random rnd = new Random(); //получаем случайное число для CustomerId and ProductId
                int value = rnd.Next(10, 15);
                string val;
                var person = new Person();
                person.Id = 40 + i;
                Console.WriteLine("Введите Имя и Фамилию"); // добавляем 2 записи 
                person.Name = Console.ReadLine();
                val = Str(10) + "@mail.ru";
                while (persons.Any(x => x.Email == val))
                {
                    val = Str(10) + "@mail.ru";
                }
                person.Email = val;
                val = "(" + rnd.Next(900, 999) + ")" + rnd.Next(100, 999) + "-" + rnd.Next(10, 99) + "-" + rnd.Next(10, 99);
                while (persons.Any(x => x.Phone == val))
                {
                    val = "(" + rnd.Next(900, 999) + ")" + rnd.Next(100, 999) + "-" + rnd.Next(10, 99) + "-" + rnd.Next(10, 99);
                }
                person.Phone = val;
                Console.WriteLine("Введите возраст");
                person.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите город");
                person.City = Console.ReadLine();
                Console.WriteLine("Введите улицу");
                person.Street = Console.ReadLine();
                Console.WriteLine("Введите товар");
                person.Tag = Console.ReadLine();
                Console.WriteLine("Введите цену");
                person.Price = Convert.ToInt32(Console.ReadLine());
                val = Str(value);
                while (persons.Any(x => x.CustomerId == val | x.ProductId == val))
                {
                    val = Str(value);
                }
                person.CustomerId = val;
                value = rnd.Next(10, 15);
                val = Str(value);
                while (persons.Any(x => x.CustomerId == val | x.ProductId == val))
                {
                    val = Str(value);
                }
                person.ProductId = val;
                persons[persons.Length - i] = person;
            }
            Console.WriteLine("Добавление прошло успешно.");
            int chel = 0; // смотрим уникальность имён 
            for (var i = 0; i < persons.Length; i++)
            {
                int k = persons.Count(s => s.Name == persons[i].Name);
                if (k != 1)
                {
                    Console.WriteLine("Нет повторяющихся имён: false");
                    break;
                }
                chel++;
            }
            if (chel == persons.Length) Console.WriteLine("Нет повторяющихся имён: true");
            Console.WriteLine("Минимальный возраст: " + persons.Min(s => s.Age)); // минимальный возраст 
            IEnumerable<Person> sortedCitys = // сортируем по городам
            from person in persons
            orderby person.City ascending
            select person;
            foreach (Person person in sortedCitys)
                Console.WriteLine(person.Id + " " + person.City + " " + person.Name + " " + person.Email + " " + person.Phone + " " + person.Age + " " + person.Street + " " + person.Tag + " " + person.Price + " " + person.CustomerId + " " + person.ProductId + " ");
            int pc = 0; //создаем отдельный список для РС
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i].Tag == "Компьютер")
                    pc++;
            }
            var Pc = new Person[pc + 1];
            int shet = 0;
            for (int i = 0; i < persons.Length; i++)
            {
                if (persons[i].Tag == "Компьютер")
                {
                    Pc[shet] = persons[i];
                    shet++;
                    persons[i] = null;
                }
            }
            Console.WriteLine("Список РС:");
            for (int i = 0; i < Pc.Length; i++)
            {
                Console.WriteLine(Pc[i]);
            }
        }
        static string Str(int k) //рандомная строка для CustomerId and ProductId
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < k; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            string lin = str_build.ToString();
            return lin;
        }
    }
}
public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string Tag { get; set; }
    public int Price { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }

    public override string ToString()
    {
        return $"{Id} {Name} {Email} {Phone} {Age} {City} {Street} {Tag} {Price} {CustomerId} {ProductId}";
    }
}


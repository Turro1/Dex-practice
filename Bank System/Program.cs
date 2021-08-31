using Bank_System.Models;
using Bank_System.Service;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Bogus;
using System.Reflection;
using Bogus.DataSets;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml.Schema;
using System.Threading;

namespace Bank_System
{
    class Program
    {
        public int count = 1;
        public int number1 = 1;
        public int number2 = 1;

        Random random = new Random();
        BankServic bankService = new BankServic();

        string[] positionArray = { "Cleaner", "Security", "Manager", "Administrator", "Accountant", "Director" };

    List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {

            var locker = new object();
            
            //SampleForDeadlock sampleForDeadlock = new SampleForDeadlock();
            //sampleForDeadlock.GetDeadlockSample();

            //figureCalc.PrintFigure();
            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (int i = 0; i < 100; i++)
                    lock (locker)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(i);
                        Console.ResetColor();
                    }
                Thread.Sleep(500);

            });
        }

        public void Search()
        {
            Console.WriteLine("\tПоиск человека по номеру паспорта");
            Console.WriteLine("Введите номер паспорта человека, которого хотите найти");
            int userPassport = Convert.ToInt32(Console.ReadLine());
            //Поиск пользователя по номеру паспорта
            if (userPassport <= bankService.clients.Count && userPassport < bankService.employs.Count)
            {
                Client client = (Client)bankService.Find(bankService.clients, userPassport);
                Console.WriteLine($"Найден клиент: {client.Name}. {client.SurName}.\nВозраст: {client.Age}.\nНомер паспорта: {client.Passport}.");
            }

            if (userPassport > bankService.clients.Count && userPassport <= bankService.employs.Count)
            {
                Employ employ = (Employ)bankService.Find(bankService.employs, userPassport);
                Console.WriteLine($"Найден сотрудник:  {employ.Name}. {employ.SurName}.\nВозраст {employ.Age}.\nНомер паспорта: " +
                    $"{employ.Passport}.\nДолжность: {employ.Position}.");
            }

            if (userPassport > bankService.employs.Count)
            {
                Console.WriteLine($"Человек с данным номером паспорта - {userPassport}. не зарегестрирован в банке");
            }
        }

        public void GeneratingPersonsList()
        {
            Console.WriteLine("Генерируем клиентов!");
            for (int i = 0; i < 10; i++)
            {
                string firstName = new Bogus.DataSets.Name("ru").FirstName();
                string lastName = new Bogus.DataSets.Name("ru").LastName();
                var user = new Client(firstName, lastName, random.Next(18,75),count++);
                bankService.AddClient(bankService.clients, user);
            }

            for (int i = 0; i < 10; i++)
            {
                string firstName = new Bogus.DataSets.Name("ru").FirstName();
                string lastName = new Bogus.DataSets.Name("ru").LastName();
                var user = new Employ() { Name = firstName, SurName = lastName, Age = random.Next(18, 75), Passport = count++, Position = positionArray[random.Next(0, positionArray.Length)] };
                bankService.AddEmploy(bankService.employs, user);
            }        }


        public void DisplayPersons()
        {
            Console.WriteLine("\tCписок клиентов");
            foreach (var item in bankService.clients)
            {
                Console.WriteLine($"\t Клиент №{number1++}.\nИмя: {item.Name}.\nФамилия: {item.SurName}.\nВозраст: {item.Age}." +
                    $" лет\nНомер паспорта: {item.Passport}.\n");
            }

            Console.WriteLine("\tCписок работников");
            foreach (var item in bankService.employs)
            {
                Console.WriteLine($"\t Сотрудник №{number2++}.\nИмя: { item.Name}.\nФамилия: { item.SurName}.\nВозраст:" +
                    $" { item.Age}. лет\nНомер паспорта: { item.Passport}.\nДолжность: {item.Position}.\n");
            }
        }

        public void MethodTransfer()
        {
            Console.WriteLine("Введиет сумму денег для перевода:");
            int sum = Convert.ToInt32(Console.ReadLine());
            foreach (var item in bankService.dictClients)
            {
                var account = item.Value;
            }

            var account1 = accounts[0];
            var account2 = accounts[1];
            var del = new BankServic.ExChangeHandler(SendMessage);
            bankService.MoneyTransfer(sum, account1, account2, del);
        }

        public static void SendMessage(string message)

        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}

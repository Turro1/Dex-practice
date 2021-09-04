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

        public BankServic bankService = new BankServic();
        List<Account> accounts = new List<Account>();

        static async Task Main(string[] args)
        {
            Random random = new Random();
            BankServic bankService = new BankServic();
            var locker = new object();
            CurrencyService currencyService = new CurrencyService();
            string path = Path.Combine("E:\\", "Курсы Dex", "Dex Practic", "Bank System", "Files");

            await currencyService.GetCurrency();
            ThreadPool.QueueUserWorkItem(_ =>
            {
                
                while (true)
                    //for (int i = 0; i < 50; i++)
                    
                lock (locker)
                    {
                        var generator = new FakePersons();
                        var account1 = generator.NewAccount();
                        Console.WriteLine(/*account1.ID,account1.moneyCount,*/ account1.Name.ToString(), account1.Value.ToString());
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        GeneratingPersonsList(bankService.clients, 10);
                        Console.ResetColor();
                    }
                Thread.Sleep(500);
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                
                while (true)
                    //for (int i = 0; i < 100; i++)
                    
                lock (locker)
                    {
                        var readText = File.ReadAllText($"{path}\\ clients.txt");
                        var pos = JsonConvert.DeserializeObject<List<Client>>(readText);
                        foreach (var item in pos)
                        {
                            Console.WriteLine($"{item.Name} {item.SurName}, Возраст:{item.Age},Номер паспорта:{item.Passport}");
                        }
                    }
                Thread.Sleep(500);
            });
            Console.ReadLine();
        }
        public static void GeneratingPersonsList<T>(List<T> usersList, int usersCount)
        {
            BankServic bankService = new BankServic();
            var generator = new FakePersons();
            for (int i = 0; i < usersCount; i++)
            {
                if (usersList is List<Client>)
                {
                  bankService.AddClient(bankService.clients, generator.NewClient());
                }
                else if (usersList is List<Employ>)
                {
                    bankService.AddEmploy(bankService.employs, generator.NewEmploy());
                }
            }
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
            //bankService.MoneyTransfer(sum, account1, account2, del);
        }

        public static void SendMessage(string message)

        {
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}

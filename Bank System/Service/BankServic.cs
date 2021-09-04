using Bank_System.Models;
using Bank_System.Exception;
using System.IO;
using System;
using Bogus;
using Bogus.DataSets;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Linq;

namespace Bank_System.Service
{
   
    public class BankServic
    {
        public string path = Path.Combine("E:\\","Курсы Dex","Dex Practic","Bank System", "Files");

        public delegate void ExChangeHandler(string message);

        public Exchange exchange = new Exchange();

        public int Sum { get; set; }

        ExChangeHandler _exchangeHandler;

        public List<Employ> employs = new List<Employ>();

        public List<Client> clients = new List<Client>();

        public Dictionary<Client, List<Account>> dictClients = new Dictionary<Client, List<Account>>();
        
        public void DeligateRegister(ExChangeHandler exchangeHandler)
        {
            _exchangeHandler = exchangeHandler;
        }

        public IPerson Find<T>(List<T> list, int userId) where T : IPerson
        {
            if (list is Client)
            {
                string readText = File.ReadAllText($"{path}\\ clients.txt");
                clients = JsonConvert.DeserializeObject<List<Client>>(readText);
            }
            if (list is Employ)
            {
                string readText = File.ReadAllText($"{path}\\ employs.txt");
                employs = JsonConvert.DeserializeObject<List<Employ>>(readText);
            }
            T person = list.Find(user => user.Passport == userId);
            return person;
        }
        public List<Client> GetClients()
        {
            return clients;
        }
        public List<Employ> GetEmployees()
        {
            return employs;
        }

        public void AddClient<T>(List<T> clients, T user) where T : IPerson
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
                string client = JsonConvert.SerializeObject(clients);
                System.IO.File.WriteAllText($"{path}\\ clients.txt", client);

            string mass = File.ReadAllText($"{path}\\ clients.txt");
                    if (mass.Contains($"\"Passport\":{user.Passport}") == false)
                    {
                        Console.WriteLine("Добавлен новый клиент");
                        clients.Add(user);
                        string client1 = JsonConvert.SerializeObject(clients);
                        System.IO.File.WriteAllText($"{path}\\ clients.txt", client1);
                    }
                    
                    else
                    {
                     
                    }
        }

        public void AddEmploy<T>(List<T> employs, T user) where T : IPerson
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
                string employ = JsonConvert.SerializeObject(employs);
                System.IO.File.WriteAllText($"{path}\\ employs.txt", employ);
                string mass = File.ReadAllText($"{path}\\ employs.txt");
            if (mass.Contains($"\"Passport\":{user.Passport}") == false)
            {
                Console.WriteLine("Добавлен новый сотрудник");
                employs.Add(user);
                string employ1 = JsonConvert.SerializeObject(employs);
                System.IO.File.WriteAllText($"{path}\\ employs.txt", employ1);
            }
            else
            {

            }
        }

        public void ReadClientsFile(string path)
        {
            var readText = File.ReadAllText($"{path}\\ clients.txt");
            clients = JsonConvert.DeserializeObject<List<Client>>(readText);
        }
       
        public void ReadEmploysFile(string path)
        {
            var readText = File.ReadAllText($"{path}\\ employs.txt");
            employs = JsonConvert.DeserializeObject<List<Employ>>(readText);
        }

        public void AddClientAccount(Client client, Account account)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
            if (dictClients.ContainsKey(client))
            {
                dictClients[client].Add(account);
                string clients = JsonConvert.SerializeObject(dictClients);
                System.IO.File.WriteAllText($"{path}\\ dictClients.txt", clients);
            }

            else
            {
                dictClients.Add(client, new List<Account>() { account });
                string clients = JsonConvert.SerializeObject(dictClients);
                System.IO.File.WriteAllText($"{path}\\ dictClients.txt", clients);
            }
        }


        public void RegisterClient(string name, string surname, int age, int passport)
        {
            if (age < 18)
            {
                throw new AgeException("18+");
            }

            else
            {
                //Client client = new Client(name, surname,age,passport);
                //dictClients.Add(client, new List<Account>());
            }
        }

        public object Get<T>(T person) where T : IPerson 
        {
            return person.Passport;
        }

        

        public void MoneyTransfer(double sum, Account account1, Account account2,ExChangeHandler exChangeHandler )
        {
            if (sum > 0)

            {
                exChangeHandler.Invoke($"Счёт первого аккаунта: {account1.moneyCount}\n" +
                    $"Счёт второго аккаунта: {account2.moneyCount}");
                account1.moneyCount = account1.moneyCount - sum;
                //double res = exchange.ExchangeMoney(account2.typeMoney,account1.typeMoney, sum);
               // account2.moneyCount = res * account2.typeMoney.rate + account2.moneyCount;
                exChangeHandler.Invoke($"денежные средства переведены успешно\n" +
                    $"Счёт первого аккаунта: {account1.moneyCount}\n" +
                    $"Счёт второго аккаунта: {account2.moneyCount} в долларах");
            }

            else
            {
                throw new InsufficientFundsException("На аккаунте нет денег");
            }
        }

    }
}

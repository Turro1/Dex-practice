using Bank_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Bank_System.Service;
using System.Threading;


namespace Bank.Tests
{
    public class BankServiceTests
    {
        [Fact]
        public void AddClientTofile ()
        {
            //Arrange
            BankServic bankServic = new BankServic();
            var clients = bankServic.GetClients();
            var client = new Client() {Name = "Егор",SurName = "Катафотов",Age = 25,Passport = 15 };

            //Act
            bankServic.AddClient(clients, client);
            var find = bankServic.Find<Client>(clients, 15);
            //Assert
            Assert.Equal(client.Passport, find.Passport);
        }
        [Fact]
        public void Account_Adding_200_And_450_Grn_From_Different_Threads_Eq_650()
        {
            //Arrange
            BankServic bankServic = new BankServic();
            var grn = new Grn();
            var account1 = new Account() { typeMoney = grn, moneyCount = 0 };
            var account2 = new Account() { typeMoney = grn, moneyCount = 1500 };
            var account3 = new Account() { typeMoney = grn, moneyCount = 600 };
            object locker = new object();

            //Act
            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (locker)
                {
                    bankServic.MoneyTransfer(200, account2, account1);
                }
            });
            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (locker)
                {
                    bankServic.MoneyTransfer(450, account3, account1);
                }
            });
            Thread.Sleep(10);

            //Assert
            Assert.Equal(650, account1.moneyCount);
        }
    }
}
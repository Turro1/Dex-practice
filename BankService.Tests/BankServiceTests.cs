using Bank_System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Bank_System.Service;


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
            var client = new Client("Егор", "Катафотов",25,15);

            //Act
            bankServic.AddClient(clients, client);
            var find = bankServic.Find<Client>(clients, 15);
            //Assert
            Assert.Equal(client.Passport, find.Passport);
        }
    }
}

using Bank_System.Models;
using Bank_System.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bank.Tests
{
    public class MoneyTransferTests
    {
        public void MoneyTransfer_1_um_2_Eq3()
        {
            //Arrange
            BankServic bankService = new BankServic();
            var generator = new FakePersons();
            var account1 = generator.NewAccount();
            var account2 = generator.NewAccount();

            //Act 
            //double result = bankService.MoneyTransfer(100, account1, account2);
            //var result = bankService.MoneyTransfer(100,account1,account2);
            //Assert
            //Assert.Equal(625, result);
        }
    }
}

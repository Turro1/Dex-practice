using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Bank_System.Models;
using Bank_System.Service;
using Bank_System;

namespace BankService.Tests
{
    public class ExChangeTests
    {
        [Fact]
        public void ExchangeMoney_100_divide_80_Um_50_Eq_625_pozitive()
        {
            //Arrange
            Exchange xchange = new Exchange();
            var rub = new Rub();
            var grn = new Grn();

            //Act
            var result = xchange.ExchangeMoney(1000, rub, grn);
            //Assert
             Assert.Equal(625, result);
        }

        [Fact]
        public void ExchangeMoney_100_divide_80_Um_50_NotEq_100_negative()
        {
            //Arrange
            Exchange xchange = new Exchange();
            var rub = new Rub();
            var grn = new Grn();

            //Act
            var result = xchange.ExchangeMoney(1000, rub, grn);
            //Assert
            Assert.NotEqual(100, result);
        }
    }
}

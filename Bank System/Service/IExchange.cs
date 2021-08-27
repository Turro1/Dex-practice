using Bank_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Service
{
    public interface IExchange
    {

        double ExchangeMoney<T, U>(double countMoney, T originalCurrency, U converingCurrency); //where T : ICurrency where U : ICurrency;

    }
}

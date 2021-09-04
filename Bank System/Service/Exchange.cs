using Bank_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Service
{
    public class Exchange : IExchange
    {
        public double ExchangeMoney<T, U>(double countMoney, T originalCurrency, U converingCurrency) where T : Currency where U : Currency
       {
            

            double result = (countMoney / originalCurrency.Value) * converingCurrency.Value;
            return result;
       }
    }
}

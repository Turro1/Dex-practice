using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    public class Account : Currency
    {
        public Currency typeMoney { get; set; }
        public double moneyCount { get; set; }
    }
}

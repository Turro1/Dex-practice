using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    
    public class CurrencyResponse
    { 
        public DateTime Date { get; set; }

        public DateTime PreviusDate { get; set; }

        public string PreviusUrl = "//www.cbr-xml-daily.ru/archive/2021/08/27/daily_json.js";

        public DateTime TimeStamp { get; set; }

        public Dictionary<string ,Currency> Valute { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    public class Dol : Currency
    {
            public override double Value { get; set; } = 1;

            public override string Name { get; set; } = "USD";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
   public interface IPerson
    {
         string Name { get; set; }
        string SurName { get; set; }
        int Age { get; set; }
        int Passport { get; set; }
    }
}

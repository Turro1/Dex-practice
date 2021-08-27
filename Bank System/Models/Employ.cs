using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
   public class Employ : IPerson 
    {
        public string Name { get; set; }

        public string SurName { get; set; }
        public int Age { get; set; }
        public int Passport { get; set; }

        public string Position { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Employ))
            {
                return false;
            }

            Employ result = (Employ)obj;
            return result.Passport == Passport;
        }
        public override int GetHashCode()
        {
            return Passport;
        }
    }
}


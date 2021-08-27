using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System.Models
{
    public class Client : IPerson
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public int Passport { get; set; }

        public Client(string Name, string SurName, int Age, int Passport)
        {
            this.Name = Name;
            this.SurName = SurName;
            this.Age = Age;
            this.Passport = Passport;

        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Client))
            {
                return false;
            }

            Client result = (Client)obj;
            return result.Passport == Passport;
        }
    public override int GetHashCode()
    {
        return Passport;
    }

    }
}
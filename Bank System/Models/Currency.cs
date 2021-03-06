using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_System.Models
{
   
    public class Currency 
    {
        public string ID { get; set; }

        public string NumCode { get; set; }

        public string CharCode { get; set; }

        public int Nominal { get; set; }

        public virtual string Name { get; set; }

        public virtual double Value { get; set; }

        public double Previous { get; set; }
    }
}

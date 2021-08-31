using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_System.Models;
using Bogus;

namespace Bank_System.Service
{
    public class FakePersons
    {
        public Client GetNewClient()
        {
            var fakeClient = new Faker<Client>()
                .RuleFor(x => x.Name, x => x.Person.FirstName)
                .RuleFor(x => x.SurName, x => x.Person.LastName)
                .RuleFor(x => x.Age, x => x.Person.DateOfBirth)
                .RuleFor(x => x.Passport, x => x.Person.Random.Number(1, 1000000))
                ;
            return fakeClient.Generate();
        }
        public Employ GetNewEmployee()
        {
            var fakeEmployee = new Faker<Employ>()
                .RuleFor(x => x.Name, x => x.Person.FirstName)
                .RuleFor(x => x.Surname, x => x.Person.LastName)
                .RuleFor(x => x.DateOfBirth, x => x.Person.DateOfBirth)
                .RuleFor(x => x.PassportId, x => x.Person.Random.Number(1, 1000000))
                .RuleFor(x => x.Position, x => x.Name.JobType())
                ;
            return fakeEmployee.Generate();
        }
        public Account GetNewAccount()
        {
            var fakeAccount = new Faker<Account>()
                .RuleFor(x => x.MoneyAmount, x => x.Random.Number(1, 10000))
                .RuleFor(x => x.CurrencyType, x => x.PickRandom<Currency>(new Lei(), new Rubles(), new Dollars()))
                ;
            return fakeAccount.Generate();
        }
    }
}

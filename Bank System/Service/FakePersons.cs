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
        public Employ NewEmploy()
        {
            var fakeEmployee = new Faker<Employ>("ru")
                .RuleFor(x => x.Name, x => x.Person.FirstName)
                .RuleFor(x => x.SurName, x => x.Person.LastName)
                .RuleFor(x => x.Age, x => x.Person.Random.Number(18, 100))
                .RuleFor(x => x.Passport, x => x.Person.Random.Number(1, 1000000))
                .RuleFor(x => x.Position, x => x.Name.JobType())
                ;
            return fakeEmployee.Generate();
        }
        public Client NewClient()
        {
            var fakeClient = new Faker<Client>("ru")
                .RuleFor(x => x.Name, x => x.Person.FirstName)
                .RuleFor(x => x.SurName, x => x.Person.LastName)
                .RuleFor(x => x.Age, x => x.Person.Random.Number(18, 100))
                .RuleFor(x => x.Passport, x => x.Person.Random.Number(1, 1000000))
                ;
            return fakeClient.Generate();
        }
        public Account NewAccount()
        {
            var currency = new CurrencyService();
            BankServic bankServic = new BankServic();
            currency.GetCurrency();
            var fakeAccount = new Faker<Account>()
                .RuleFor(x => x.moneyCount, x => x.Random.Number(1, 10000))
                .RuleFor(x => x.typeMoney, x => x.PickRandom<Currency>(currency.currency.Valute.Values))
                ;
            return fakeAccount.Generate();
        }
    }
}

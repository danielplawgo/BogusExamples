using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace BogusExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string locale = "pl";

            var users = new Faker<User>(locale)
                .StrictMode(true)
                .RuleFor(u => u.Gender, (f, u) => f.PickRandom<Gender>())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName((Bogus.DataSets.Name.Gender)u.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.FirstName((Bogus.DataSets.Name.Gender)u.Gender))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .Generate(10);

            var products = new Faker<Product>(locale)
                .StrictMode(true)
                .RuleFor(p => p.Name, (f, p) => f.Commerce.ProductName())
                .RuleFor(p => p.Company, (f, p) => f.Company.CompanyName())
                .RuleFor(p => p.Price, (f, p) => f.Random.Decimal(0.01M, 1000M))
                .Generate(10);

            var orders = new Faker<Order>(locale)
                .StrictMode(true)
                .RuleFor(o => o.User, (f, p) => f.PickRandom(users))
                .RuleFor(o => o.Product, (f, p) => f.PickRandom(products))
                .RuleFor(o => o.Count, (f, p) => f.Random.Int(1, 20))
                .RuleFor(o => o.Date, (f, p) => f.Date.Past(2))
                .RuleFor(o => o.Status, (f, p) => f.PickRandom<OrderStatus>())
                .Generate(100);

            users.Dump();
            products.Dump();
            orders.Dump();
        }
    }
}

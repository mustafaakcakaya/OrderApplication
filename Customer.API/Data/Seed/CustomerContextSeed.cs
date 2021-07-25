using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Data.Seed
{
    public class CustomerContextSeed
    {
        public static void SeedData(IMongoCollection<Entities.Customer> customerCollection)
        {
            bool existCustomer = customerCollection.Find(p => true).Any();
            if (!existCustomer)
            {
                customerCollection.InsertManyAsync(GetPreconfiguredCustomers());
            }
        }

        private static IEnumerable<Entities.Customer> GetPreconfiguredCustomers()
        {
            return new List<Entities.Customer>()
            {
                new Entities.Customer()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Mustafa Akçakaya",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "m.akcakaya.tr@gmail.com",
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new Entities.Customer()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Yunus Koçak",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "yunuskocak@gmail.com",
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new Entities.Customer()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Fuat Kazan",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "fuatkazan@gmail.com",
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new Entities.Customer()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Erkan Yanık",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "erkanyanik@gmail.com",
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new Entities.Customer()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Yavuz Tuna",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Email = "yavuztuna@gmail.com",
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                }
            };
        }
    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Order.Application.Data
{
    public class OrderContextSeed
    {
        public static void SeedData(IMongoCollection<CommonLibrary.Entities.Order> orderCollection)
        {
            bool existOrder = orderCollection.Find(p => true).Any();
            if (!existOrder)
            {
                var orders = GetPreconfiguredOrders().ToList();
                orderCollection.InsertManyAsync(orders);
            }
        }

        private static IEnumerable<CommonLibrary.Entities.Order> GetPreconfiguredOrders()
        {
            return new List<CommonLibrary.Entities.Order>()
            {
                new CommonLibrary.Entities.Order()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    CustomerId = "602d2149e773f2a3990b47f5",
                    Product = new CommonLibrary.Entities.Product
                    {
                         Id  = "102d2149e773f2a3990b47f0",
                         Name = "Xiaomi Note 9",
                         ImageUrl = "image.png"
                    },
                    Price = 2699.0,
                    Quantity = 1,
                    Status = "Teslim Edildi.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new CommonLibrary.Entities.Order()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    CustomerId = "602d2149e773f2a3990b47f5",
                    Product = new CommonLibrary.Entities.Product
                    {
                         Id  = "102d2149e773f2a3990b47f1",
                         Name = "Xiaomi Note 9 Pro",
                         ImageUrl = "image2.png"
                    },
                    Price = 3199.0,
                    Quantity = 3,
                    Status = "Kargodan Dağıtıma Çıktı.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new CommonLibrary.Entities.Order()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    CustomerId = "602d2149e773f2a3990b47f6",
                    Product = new CommonLibrary.Entities.Product
                    {
                         Id  = "102d2149e773f2a3990b47f2",
                         Name = "Apple Iphone 11",
                         ImageUrl = "image3.png"
                    },
                    Price = 11999.0,
                    Quantity = 1,
                    Status = "Kargoya Verilecek.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new CommonLibrary.Entities.Order()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    CustomerId = "602d2149e773f2a3990b47f8",
                    Price = 8999.0,
                    Product = new CommonLibrary.Entities.Product
                    {
                         Id  = "102d2149e773f2a3990b47f3",
                         Name = "Beko Derindonduruculu Buzdolabı",
                         ImageUrl = "image4.png"
                    },
                    Quantity = 1,
                    Status = "Teslim Edildi.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    Address  = new CommonLibrary.Entities.Address
                    {
                        AddressLine  = "Altınsehir Mah.",
                        City = "Istanbul",
                        CityCode = 34,
                        Country = "Turkey"
                    }
                },
                new CommonLibrary.Entities.Order()
                {
                    Id = "602d2149e773f2a3990b47f0",
                    CustomerId = "602d2149e773f2a3990b47f7",
                    Product = new CommonLibrary.Entities.Product
                    {
                         Id  = "102d2149e773f2a3990b47f4",
                         Name = "Nokia 3310",
                         ImageUrl = "image.png"
                    },
                    Price = 50.0,
                    Quantity = 1,
                    Status = "İade Edildi.",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
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

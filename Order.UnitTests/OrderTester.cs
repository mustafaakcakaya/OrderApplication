using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Order.Application.Data;
using Order.Application.Repository;
using System.Threading.Tasks;
using System;

namespace Order.UnitTests
{
    [TestClass]
    public class OrderTester
    {
        private IOrderRepository _orderRepository;
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config != null) return _config;
                var builder = new ConfigurationBuilder().AddJsonFile("testsettings.json", optional: false);
                _config = builder.Build();

                return _config;
            }
        }
        [TestInitialize]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(Configuration);
            _orderRepository = new OrderRepository(new OrderContext(_config));
        }

        [TestMethod]
        public async Task ShouldChangeOrderStatus()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            const string status = "Adrese Teslim Edildi.";
            await CheckoutNewOrder(id);

            //Act
            var isSuccess = await _orderRepository.ChangeStatus(id, status);
            var order = await _orderRepository.GetByIdAsync(id);

            //Assert
            Assert.IsTrue(isSuccess && order.Status == status);

            await _orderRepository.DeleteAsync(id);
        }

        private async Task CheckoutNewOrder(string id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);
            var newEntity = new CommonLibrary.Entities.Order()
            {
                Id = id,
                CustomerId = "602d2149e773f2a3990b47f5",
                Product = new CommonLibrary.Entities.Product
                {
                    Id = "102d2149e773f2a3990b47f1",
                    Name = "Xiaomi Note 9 Pro",
                    ImageUrl = "imageXiamoN9P.png"
                },
                Price = 3199.0,
                Quantity = 3,
                Status = "Kargodan Daðýtýma Çýktý.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Address = new CommonLibrary.Entities.Address
                {
                    AddressLine = "Altýnsehir Mah.",
                    City = "Istanbul",
                    CityCode = 34,
                    Country = "Turkey"
                }
            };
            if (entity == null)
            {
                await _orderRepository.AddAsync(newEntity);
            }
            else
            {
                await _orderRepository.DeleteAsync(id);
                await _orderRepository.AddAsync(newEntity);
            }
        }
    }
}


using Customer.API.Data.Implementations;
using Customer.API.Data.Interfaces;
using Customer.API.Repositories.Implementations;
using Customer.API.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.UnitTests
{
    [TestClass]
    public class CustomerTester
    {
        private ICustomerRepository _customerRepository;
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }
        [TestInitialize]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(Configuration);
            _customerRepository = new CustomerRepository(new CustomerContext(_config));
        }
        //NOTE: yapılan ortak base context metodlarının test edilebilmesi için bir kereliğine burada testleri yazıldı.
        //NOTE: bunun dışında entity'ye özel aksiyonların testleri yazılacak diğer testlerde.
        [TestMethod]
        public async Task ShouldGetExistingCustomer()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            await CreateNewCustomer(id);
            //Act
            var customer = await _customerRepository.GetAsync(id);

            //Assert
            Assert.IsTrue(customer.Id == id);

            await _customerRepository.DeleteAsync(id);
        }
        [TestMethod]
        public async Task ShouldValidateExistingCustomer()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            await CreateNewCustomer(id);
            //Act
            var isValidated = await _customerRepository.ValidateAsync(id);
            
            //Assert
            Assert.IsTrue(isValidated);

            await _customerRepository.DeleteAsync(id);
        }

        [TestMethod]
        public async Task ShouldCreateNewCustomer()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            await CreateNewCustomer(id);
            //Act
            var customer = await _customerRepository.GetAsync(id);

            //Assert
            Assert.IsNotNull(customer);

            await _customerRepository.DeleteAsync(id);
        }

        [TestMethod]
        public async Task ShouldDeleteExistingCustomer()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            await CreateNewCustomer(id);
            //Act
            var isDeleted = await _customerRepository.DeleteAsync(id);

            //Assert
            Assert.IsTrue(isDeleted);
        }

        [TestMethod]
        public async Task ShouldUpdateExistingCustomer()
        {
            //Arrange
            const string id = "111d1111e111f1a1111b11f1";
            var entity = await _customerRepository.GetAsync(id);
            await CreateNewCustomer(id);

            //Act
            var customer = await _customerRepository.GetAsync(id);
            customer.Email = "newtestmail@gmail.com";
            customer.Name = "New Test Name";

            await _customerRepository.UpdateAsync(customer);

            var updatedCustomer = await _customerRepository.GetAsync(id);

            //Assert
            Assert.IsTrue(updatedCustomer.Name == customer.Name && updatedCustomer.Email == customer.Email);

            await _customerRepository.DeleteAsync(id);
        }

        [TestMethod]
        public async Task ShouldLoadAllCustomers()
        {
            //Arrange
            const string id1 = "111d1111e111f1a1111b11f1";
            const string id2 = "222d2222e222f2a2222b22f2";
            await CreateNewCustomer(id1);
            await CreateNewCustomer(id2);

            //Act
            var customers = await _customerRepository.GetAsync();
            
            //Assert
            Assert.IsTrue(customers.ToList().Count > 1);
            await _customerRepository.DeleteAsync(id1);
            await _customerRepository.DeleteAsync(id2);
        }
        private async Task CreateNewCustomer(string id)
        {
            API.Entities.Customer newEntity;
            var entity = await _customerRepository.GetAsync(id);
            newEntity = new API.Entities.Customer
            {
                Id = id,
                Name = "Test İsim",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Email = "testisim@gmail.com",
                Address = new CommonLibrary.Entities.Address
                {
                    AddressLine = "Altınsehir Mah.",
                    City = "Istanbul",
                    CityCode = 34,
                    Country = "Turkey"
                }

            };
            if (entity == null)
            {
                await _customerRepository.CreateAsync(newEntity);
            }
            else
            {
                await _customerRepository.DeleteAsync(id);
                await _customerRepository.CreateAsync(newEntity);
            }
        }
    }
}

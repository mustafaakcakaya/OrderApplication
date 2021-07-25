using Customer.API.Data.Interfaces;
using Customer.API.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerContext _context;
        public CustomerRepository(ICustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> CreateAsync(Entities.Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            customer.UpdatedAt = DateTime.Now;
            await _context.Entities.InsertOneAsync(customer);

            return customer.Id;
        }
        public async Task<bool> UpdateAsync(Entities.Customer customer)
        {
            customer.UpdatedAt = DateTime.Now;
            var updateResult = await _context
                                         .Entities
                                         .ReplaceOneAsync(filter: g => g.Id == customer.Id, replacement: customer);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Entities.Customer> filter = Builders<Entities.Customer>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Entities
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Entities.Customer>> GetAsync()
        {
            return await _context
                            .Entities
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Entities.Customer> GetAsync(string id)
        {
            return await _context
                            .Entities
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidateAsync(string id)
        {
            return await _context
                            .Entities
                            .Find(p => p.Id == id)
                            .AnyAsync();
        }
    }
}

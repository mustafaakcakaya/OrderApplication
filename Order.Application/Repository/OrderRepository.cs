using CommonLibrary.Context;
using CommonLibrary.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Order.Application.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repository
{
    public class OrderRepository : BaseRepository<BaseContext<CommonLibrary.Entities.Order>, CommonLibrary.Entities.Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }

        public async Task<bool> ChangeStatus(string id, string status)
        {
            var order = await GetByIdAsync(id);

            order.UpdatedAt = DateTime.Now;
            order.Status = status;

            var updateResult = await _context
                                         .Entities
                                         .ReplaceOneAsync(Builders<CommonLibrary.Entities.Order>.Filter.Eq(p => p.Id, id), replacement: order);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}

using CommonLibrary.Context;
using CommonLibrary.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Repository
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : BaseContext<TEntity>
    {
        protected readonly TContext _context;
        public BaseRepository(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<string> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            await _context.Entities.InsertOneAsync(entity);

            return entity.Id;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Entities
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context
                            .Entities
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context
                            .Entities
                            .Find(predicate)
                            .ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _context
                            .Entities
                            .Find(p => p.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;
            var updateResult = await _context
                                         .Entities
                                         .ReplaceOneAsync(filter: g => g.Id == entity.Id, replacement: entity);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}

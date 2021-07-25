using CommonLibrary.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLibrary.Context
{
    public class BaseContext<TEntity> where TEntity : BaseEntity 
    {
        public BaseContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings:DatabaseName").Value/*configuration.GetValue<string>("DatabaseSettings:DatabaseName")*/);

            Entities = database.GetCollection<TEntity>(configuration.GetSection("DatabaseSettings:CollectionName").Value/*configuration.GetValue<string>("DatabaseSettings:CollectionName")*/);
        }
        public IMongoCollection<TEntity> Entities { get; }
    }
}

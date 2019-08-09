using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.DataAccess
{
    public static class ServiceCollactionBuilderExtensions
    {
        public static void AddMongoSingleton(this IServiceCollection service, MongoConnectionConfiguration opts)
        {
            service.AddSingleton<IMongoClient>(new MongoClient(opts.ConnectionString));
            service.AddSingleton<IMongoDatabase>(x => x.GetService<IMongoClient>().GetDatabase(opts.DatabaseName));
        }

        public static void AddMongoCollection<TEntity>(this IServiceCollection service, string collectionName)
        {
            service.AddSingleton<IMongoCollection<TEntity>>(x => x.GetService<IMongoDatabase>().GetCollection<TEntity>(collectionName));
        }
    }
}

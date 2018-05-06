﻿namespace Castanha.Infrastructure.MongoDataAccess
{
    using MongoDB.Driver;
    using System;
    using System.Threading.Tasks;
    using OrdersWebApi.Application.Repositories;
    using OrdersWebApi.Infrastructure.MongoDataAccess;
    using OrdersWebApi.Domain.Tracking;

    public class OrderRepository : IOrderReadOnlyRepository, IOrderWriteOnlyRepository
    {
        private readonly TrackingContext mongoContext;

        public OrderRepository(TrackingContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task<Order> Get(Guid orderId)
        {
            Order order = await mongoContext.Orders
                .Find(e => e.Id == orderId)
                .SingleOrDefaultAsync();

            return order;
        }

        public async Task Add(Order order)
        {
            await mongoContext.Orders
                .InsertOneAsync(order);
        }

        public async Task Update(Order order)
        {
            await mongoContext.Orders
                .ReplaceOneAsync(e => e.Id == order.Id, order);
        }
    }
}

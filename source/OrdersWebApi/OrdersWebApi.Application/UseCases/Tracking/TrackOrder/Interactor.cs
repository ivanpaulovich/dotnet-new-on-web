﻿namespace OrdersWebApi.Application.UseCases.Tracking.TrackOrder
{
    using OrdersWebApi.Application.Repositories;
    using OrdersWebApi.Domain.Tracking;
    using System.Threading.Tasks;

    public class Interactor : IInputBoundaryAsync<Input>
    {
        private readonly IOrderReadOnlyRepository orderReadOnlyRepository;
        private readonly IOutputBoundary<TrackingOutput> outputBoundary;
        private readonly IOutputConverter outputConverter;
        private readonly string downloadUrlBase;

        public Interactor(
            IOrderReadOnlyRepository orderReadOnlyRepository,
            IOutputBoundary<TrackingOutput> outputBoundary,
            IOutputConverter outputConverter,
            string downloadUrlBase)
        {
            this.orderReadOnlyRepository = orderReadOnlyRepository;
            this.outputBoundary = outputBoundary;
            this.downloadUrlBase = downloadUrlBase;
            this.outputConverter = outputConverter;
        }

        public async Task Process(Input input)
        {
            Order order = await orderReadOnlyRepository.Get(input.OrderId);
            TrackingOutput output = outputConverter.Map<TrackingOutput>(order);
            outputBoundary.Populate(output);
        }
    }
}

﻿namespace Cart.WebApi.UseCases.OrderEventSourcingTemplate
{
    using Cart.Application;
    using Microsoft.AspNetCore.Mvc;
    using Cart.Application.UseCases.EventSourcingTemplate;

    [Route("api/[controller]")]
    public class Orders : Controller
    {
        private readonly IInputBoundary<Input> orderEventSourcingTemplateBoundary;
        private readonly OrderPresenter orderEventSourcingTemplatePresenter;

        public Orders(
            IInputBoundary<Input> orderEventSourcingTemplateBoundary,
            OrderPresenter orderEventSourcingTemplatePresenter)
        {
            this.orderEventSourcingTemplateBoundary = orderEventSourcingTemplateBoundary;
            this.orderEventSourcingTemplatePresenter = orderEventSourcingTemplatePresenter;
        }

        [HttpPost("EventSourcing")]
        public IActionResult Post([FromBody]OrderEventSourcingRequest request)
        {
            Input input = new Input(
                request.Name,
                request.UseCases,
                request.UserInterface,
                request.DataAccess,
                request.ServiceBus,
                request.Tips,
                request.SkipRestore);

            orderEventSourcingTemplateBoundary.Process(input);

            return orderEventSourcingTemplatePresenter.ViewModel;
        }
    }
}

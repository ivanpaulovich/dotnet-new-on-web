﻿namespace Tracking.Application.UseCases.UploadFinished
{
    using System;

    public class Input
    {
        public Guid OrderId { get; private set; }

        public Input(Guid orderId)
        {
            this.OrderId = orderId;
        }
    }
}

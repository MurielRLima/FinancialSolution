﻿using FinancialDocument.Domain.Entities;
using MediatR;
using System;

namespace FinancialDocument.Service.Commands
{
    public class PaymentMethodUpdateCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Observation { get; set; }
        public bool Active { get; set; }
        public int Installments { get; set; }

        public static PaymentMethod MapTo(PaymentMethodUpdateCommand model)
        {
            return new PaymentMethod()
            {
                Id = model.Id,
                Description = model.Description,
                Observation = model.Observation,
                Active = model.Active,
                Installments = model.Installments
            };
        }
    }
}
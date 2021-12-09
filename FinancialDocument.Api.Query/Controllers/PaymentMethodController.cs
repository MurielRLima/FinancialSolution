using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinancialDocument.Api.Query.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {

        private readonly IMediator _mediator;
        //private readonly IRepository<PaymentMethod> _repository;

        public PaymentMethodController(IMediator mediator/*, IRepository<PaymentMethod> repository*/)
        {
            this._mediator = mediator;
            //this._repository = repository;
        }

      

    }
}

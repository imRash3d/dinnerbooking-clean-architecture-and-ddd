using DinnerBooking.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Abstraction.Query
{
    public interface IQuery : IRequest<QueryResponse>
    {
    }
}

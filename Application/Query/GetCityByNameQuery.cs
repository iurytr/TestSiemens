using Application.PipilineBehavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query
{
    public class GetClientByIdQuery : IRequest<Response>
    {
        public GetClientByIdQuery(int clientId)
        {
            Id = clientId;
        }
        public int Id { get; private set; }
    }
}

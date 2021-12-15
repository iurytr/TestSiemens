using Application.PipilineBehavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query
{
    public class GetCityByStateQuery : IRequest<Response>
    {
        public GetCityByStateQuery(string state)
        {
            State = state;
        }
        public string State { get; private set; }
    }
}

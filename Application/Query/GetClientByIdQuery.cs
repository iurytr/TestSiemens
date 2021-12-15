using Application.PipilineBehavior;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query
{
    public class GetClientByNameQuery : IRequest<Response>
    {
        public GetClientByNameQuery(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City : BaseEntity
    {

        public City(string name, string state)
        {
            Name = name;
            State = state;
        }

        public string Name { get; private set; }

        public string State { get; private set; }
    }
}

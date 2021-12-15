using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : BaseEntity
    {
        public Client(string name, SexoType sexo, DateTime birthdDate, string city)
        {
            Name = name;
            Sexo = sexo;
            BirthdDate = birthdDate;
            City = city;
        }

        public string Name { get; private set; }

        public SexoType Sexo { get; private set; }

        public DateTime BirthdDate { get; private set; }

        [NotMapped]
        public int Age
        {
            get
            {
                return GetAge();
            }
        }

        public string City { get; private set; }

        private int GetAge()
        {
            return DateTime.Now.Year - BirthdDate.Year;
        }

        public void UpdateClient(string name, SexoType sexo, DateTime birthdDate, string city)
        {
            Name = name;
            Sexo = sexo;
            BirthdDate = birthdDate;
            City = city;
        }
    }
}

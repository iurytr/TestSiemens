using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ICityRepository
    {
        Task<City> SaveCityAsync(City city);

        Task UpdateCityAsync(City city);
        Task<City> GetCityByName(string name);
        Task<IEnumerable<City>> GetCityByState(string state);
        Task<IEnumerable<City>> GetAll();
    }
}

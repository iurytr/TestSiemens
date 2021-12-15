using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.BaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly SiemensContext _context;

        public CityRepository(SiemensContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.City.Where(x => x.ExclusionDate == null).ToListAsync();
        }

        public async Task<City> GetCityByName(string name)
        {
            return await _context.City.Where(x => x.Name == name && x.ExclusionDate == null).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<City>> GetCityByState(string state)
        {
           return await  _context.City.Where(x => x.State == state && x.ExclusionDate == null).ToListAsync();
        }

        public async Task<City> SaveCityAsync(City city)
        {
            await _context.City.AddAsync(city);
            await _context.SaveChangesAsync();

            return city;
        }


        public async Task UpdateCityAsync(City city)
        {
            _context.City.Update(city);
            await _context.SaveChangesAsync();
        }

    }
}

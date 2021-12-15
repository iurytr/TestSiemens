using Application.Command;
using Application.PipilineBehavior;
using Application.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Handler
{
    public class CityHanadle : IRequestHandler<CreateCityCommand, Response>,
                               IRequestHandler<GetCityByNameQuery, Response>,
                               IRequestHandler<GetCityByStateQuery, Response>,
                               IRequestHandler<GetAllCityQuery, Response>
    {
        private readonly ICityRepository _cityRepository;

        public CityHanadle(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<Response> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var city = new City(request.CityDto.Name, request.CityDto.State);

                await _cityRepository.SaveCityAsync(city);

                var response = new Response(city, true);

                return response;
            }
            catch (Exception ex)
            {
                var response = new Response();

                response.AddError(ex.Message);
                response.Success = false;

                return response;
            }
        }

        public async Task<Response> Handle(GetCityByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var city = await _cityRepository.GetCityByName(request.Name);

                var response = new Response(city, true);

                return response;
            }
            catch (Exception ex)
            {
                var response = new Response();

                response.AddError(ex.Message);
                response.Success = false;

                return response;
            }
        }

        public async Task<Response> Handle(GetCityByStateQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var city = await _cityRepository.GetCityByState(request.State);

                var response = new Response(city, true);

                return response;
            }
            catch (Exception ex)
            {
                var response = new Response();

                response.AddError(ex.Message);
                response.Success = false;

                return response;
            }
        }

        public async Task<Response> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
        {
            try
            {

                var cities = await _cityRepository.GetAll();

                var response = new Response(cities, true);

                return response;
            }
            catch (Exception ex)
            {
                var response = new Response();

                response.AddError(ex.Message);
                response.Success = false;

                return response;
            }
        }
    }

}

using Application.Command;
using Application.PipilineBehavior;
using Application.Query;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Siemens.Application.Handler
{
    public class ClientHandle : IRequestHandler<CreateClientCommand, Response>,
                                IRequestHandler<DeleteClientCommand, Response>,
                                IRequestHandler<GetClientByIdQuery, Response>,
                                IRequestHandler<GetClientByNameQuery, Response>,
                                IRequestHandler<GetAllClientQuery, Response>,
                                IRequestHandler<UpdateClientNameCommand, Response>
    {
 
        private readonly IClientRepository _clientRepository;

        public ClientHandle(IClientRepository clientRepository)
        {

            _clientRepository = clientRepository;
        }

        public async Task<Response> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.ClientDto;
                var client = new Client(dto.Name, dto.Sexo, dto.BirthdDate, dto.City);

                await _clientRepository.SaveClientAsync(client);
                var response = new Response(client, true);

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

        public async Task<Response> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _clientRepository.DeleteClient(request.ClientId);
                var response = new Response(true);

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

        public async Task<Response> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                 var client = await _clientRepository.GetById(request.Id);
                var response = new Response(client, true);

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

        public async Task<Response> Handle(GetClientByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var client = await _clientRepository.GetClientbyName(request.Name);
                var response = new Response(client, true);

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

        public async Task<Response> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clients = await _clientRepository.GetAll();
                var response = new Response(clients, true);

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

        public async Task<Response> Handle(UpdateClientNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = await _clientRepository.GetById(request.Id);

                if(client != null)
                {
                    client.UpdateClient(request.Name, client.Sexo, client.BirthdDate, client.City);
                }

                await _clientRepository.UpdateClient(client);
                var response = new Response(true);

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

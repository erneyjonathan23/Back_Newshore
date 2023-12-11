using AutoMapper;
using MediatR;
using OP.Prueba.Application.Exceptions;
using OP.Prueba.Application.Interfaces;
using OP.Prueba.Application.Wrappers;
using OP.Prueba.Domain.Entities;

namespace OP.Prueba.Application.Features.DeletePersonCommand.Commands.DeletePersonCommand
{
    public class DeletePersonCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, Response<int>>
    {
        private readonly IPersonService _PersonService;

        public DeletePersonCommandHandler(IPersonService PersonService)
        {
            _PersonService = PersonService;
        }

        public async Task<Response<int>> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            return await _PersonService.DeletePerson(request, cancellationToken);
        }
    }
}

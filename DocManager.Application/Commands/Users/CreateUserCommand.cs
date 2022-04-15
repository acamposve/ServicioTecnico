using AutoMapper;
using ServicioTecnico.Application.Interfaces;
using ServicioTecnico.Domain.Entities;
using ServicioTecnico.Domain.Models.Users;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServicioTecnico.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]


        public string Role { get; set; }

        [Required]

        public string Username { get; set; }
        [Required]

        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IConfiguration configuration;
            private readonly IUserService _service;
            private readonly IMapper _mapper;
            public CreateUserCommandHandler(IConfiguration configuration, IUserService service, IMapper mapper)
            {
                this.configuration = configuration;
                _service = service;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var usuario = _mapper.Map<CreateRequest>(command);

                int valor = await _service.Create(usuario);


                return 1;
            }
        }
    }
}

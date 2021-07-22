using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Commands.GenreCommands
{
    public class CreateGenreCommand : IRequest
    {
        [Display(Name = "Название: ")]
        public string Name { get; set; }
    }

    public class CreateContentHandler : IRequestHandler<CreateGenreCommand, Unit>
    {
        private readonly IGenreRepository _repo;

        public CreateContentHandler(IGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            await _repo.Insert(new Genre { Name = request.Name });
            return Unit.Value;
        }
    }
}

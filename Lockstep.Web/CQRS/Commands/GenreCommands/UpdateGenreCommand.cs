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
    public class UpdateGenreCommand : IRequest
    {
        [Display(Name = "Название: ")]
        public string Name { get; set; }
    }

    public class UpdateContentHandler : IRequestHandler<UpdateGenreCommand, Unit>
    {
        private readonly IGenreRepository _repo;

        public UpdateContentHandler(IGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            await _repo.Update(new Genre { Name = request.Name });
            return Unit.Value;
        }
    }
}

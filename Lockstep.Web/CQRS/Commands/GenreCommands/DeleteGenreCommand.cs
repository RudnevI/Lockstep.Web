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
    public class DeleteGenreCommand : IRequest
    {
        [Display(Name = "Id: ")]
        public int Id { get; set; }
    }

    public class DeleteContentHandler : IRequestHandler<DeleteGenreCommand, Unit>
    {
        private readonly IGenreRepository _repo;

        public DeleteContentHandler(IGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
        {
            await _repo.Delete(request.Id);
            return Unit.Value;
        }
    }
}

using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : IRequest
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }

    public class UpdateContentCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _repo;

        public UpdateContentCommandHandler(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
        {
            await _repo.Update(new Author { Name = command.Name });
            return Unit.Value;
        }
    }
}

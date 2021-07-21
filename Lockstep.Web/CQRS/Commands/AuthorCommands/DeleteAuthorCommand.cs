using Lockstep.Web.CQRS.Queries.AuthorQueries;
using Lockstep.Web.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Commands.AuthorCommands
{
    public class DeleteAuthorCommand : IRequest
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
    }

    public class DeleteContentCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _repo;


        public DeleteContentCommandHandler(IAuthorRepository repo)
        {
            _repo = repo;
         
        }

        public async Task<Unit> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            await _repo.Delete(command.Id);
            return Unit.Value;
        }
    }
}

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
        private readonly IMediator _mediator;

        public DeleteContentCommandHandler(IAuthorRepository repo, IMediator mediator)
        {
            _repo = repo;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand command, CancellationToken cancellationToken)
        {
            await _repo.Delete(_mediator.Send(new GetAuthorByIdQuery { Id = command.Id }));
            return Unit.Value;
        }
    }
}

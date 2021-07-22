using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Commands.BookCommands
{
    public class DeleteBookCommand : IRequest
    {
        [Display(Name ="Id: ")]
        public int Id{ get; set; }
    }

    public class DeleteContentHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly IBookRepository _repo;

        public DeleteContentHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repo.Delete(request.Id);
            return Unit.Value;
        }
    }
}

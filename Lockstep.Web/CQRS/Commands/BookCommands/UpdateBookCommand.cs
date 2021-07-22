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
    public class UpdateBookCommand : IRequest
    {
        [Display(Name = "Название: ")]
        public string Name { get; set; }
    }

    public class UpdateContentHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _repo;

        public UpdateContentHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _repo.Update(new Book { Name = request.Name });
            return Unit.Value;
        }
    }
}

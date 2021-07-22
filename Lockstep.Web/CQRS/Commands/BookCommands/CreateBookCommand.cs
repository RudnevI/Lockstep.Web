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
    public class CreateBookCommand : IRequest
    {
        [Display(Name = "Название: ")]
        public string Name { get; set; }
    }

    public class CreateContentHandler : IRequestHandler<CreateBookCommand, Unit>
    {
        private readonly IBookRepository _repo;

        public CreateContentHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            await _repo.Insert(new Book { Name = request.Name });
            return Unit.Value;
        }
    }
 }

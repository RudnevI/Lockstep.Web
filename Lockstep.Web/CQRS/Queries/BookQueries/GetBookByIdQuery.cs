using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int? Id { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookRepository _repo;

        public GetBookByIdQueryHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.Id);
        }
    }

}

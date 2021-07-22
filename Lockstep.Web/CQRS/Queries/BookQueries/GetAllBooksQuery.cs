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
    public class GetAllBooksQuery : IRequest<IEnumerable<Book>> { }
    public class GetAllContentQueryHandler : IRequestHandler<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IBookRepository _repo;

        public GetAllContentQueryHandler(IBookRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get();
        }
    }
}

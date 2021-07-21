using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Queries.AuthorQueries
{
    public class GetAllAuthorsQuery : IRequest<IEnumerable<Author>> { }
    public class GetAllContentQueryHandler : IRequestHandler<GetAllAuthorsQuery, IEnumerable<Author>>
    {
        private readonly IAuthorRepository _repo;

        public GetAllContentQueryHandler(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get();
        }
    }
}

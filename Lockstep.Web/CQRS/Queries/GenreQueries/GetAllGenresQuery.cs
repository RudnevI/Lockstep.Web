using Lockstep.Web.Interfaces;
using LockStep.Library.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lockstep.Web.CQRS.Queries.GenreQueries
{
    public class GetAllGenresQuery : IRequest<IEnumerable<Genre>> { }
    public class GetAllContentQueryHandler : IRequestHandler<GetAllGenresQuery, IEnumerable<Genre>>
    {
        private readonly IGenreRepository _repo;

        public GetAllContentQueryHandler(IGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Genre>> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
        {
            return await _repo.Get();
        }
    }
}

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
    public class GetGenreByIdQuery : IRequest<Genre>
    {
        public int? Id { get; set; }
    }

    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, Genre>
    {
        private readonly IGenreRepository _repo;

        public GetGenreByIdQueryHandler(IGenreRepository repo)
        {
            _repo = repo;
        }

        public async Task<Genre> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.Id);
        }
    }

}

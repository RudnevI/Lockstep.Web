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
    public class GetAuthorByIdQuery : IRequest<Author> 
    { 
        public int? Id { get; set; }
    }

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _repo;

        public GetAuthorByIdQueryHandler(IAuthorRepository repo)
        {
            _repo = repo;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request.Id);
        }
    }
   
}

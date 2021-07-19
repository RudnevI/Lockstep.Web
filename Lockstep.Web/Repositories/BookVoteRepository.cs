using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockstep.Web.Data;
using LockStep.Library.Domain;

namespace LockStepNew
{
    public class BookVoteRepository : GenericRepository<BookVote>, IBookVoteRepository
    {
        public BookVoteRepository(ApplicationDbContext context) : base(context) { }
    }
}

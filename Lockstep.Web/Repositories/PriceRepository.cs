using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lockstep.Web.Data;
using Lockstep.Web.Interfaces;
using LockStep.Library.Domain.Finance;


namespace Lockstep.Web.Repositories
{
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext context) : base(context) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LockStep.Library.Domain.Finance;

namespace Lockstep.Web.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
    }
}

using Lockstep.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockstep.Web.Controllers.FinanceControllers
{
    public class PayController : Controller
    {

        private readonly IPaymentRepository _repo;

        public PayController(IPaymentRepository repo)
        {
            _repo = repo;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}

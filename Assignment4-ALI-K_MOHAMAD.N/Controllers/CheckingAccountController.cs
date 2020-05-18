using Assignment4_ALI_K_MOHAMAD.N.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment4_ALI_K_MOHAMAD.N.Controllers
{
    public class CheckingAccountController : Controller
    {
        private ApplicationDbContext _context;
        public CheckingAccountController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: CheckingAccount
        [Route("CheckingAccount/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
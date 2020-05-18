using Assignment4_ALI_K_MOHAMAD.N.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Assignment4_ALI_K_MOHAMAD.N.ListViewModel;

namespace Assignment4_ALI_K_MOHAMAD.N.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _context;
        public TransactionController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }
        [Route("Transaction/Inquiry")]
        public ActionResult Inquiry()
        {
            var acc = _context.CheckingAccounts.Single(c => c.Id == 1);

            return View(acc);
        }


        [Route("Transaction/Deposit")]
        public ActionResult Deposit(Transaction ts)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ConfirmDeposit(Transaction ts)
        {
            var Amount = ts.Amount;
            if (Amount <= 0)
            {
                return Content("That was a good attempt :)");
            }
            string username = User.Identity.GetUserId();
            var acc = _context.CheckingAccounts.Single(c => c.ApplicationUserId == username);
            acc.Balance = acc.Balance + Amount;
            _context.SaveChanges();
            return View();
        }


        [Route("Transaction/Withdraw")]
        public ActionResult Withdraw(Transaction ts)
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult ConfirmWithdraw(Transaction ts)
        {
            var Amount = ts.Amount;
            if (Amount <= 0)
            {
                return Content("That was a good attempt :)");
            }
            string username = User.Identity.GetUserId();
            var acc = _context.CheckingAccounts.Single(c => c.ApplicationUserId == username);
            if (acc.Balance > Amount)
            {
                acc.Balance = acc.Balance - Amount;
                _context.SaveChanges();
                return View();
            }
            else
            {
                TempData["Message"] = "You dont have enough balance to withdraw this amount \n You only have" + acc.Balance + " $ left";
                return RedirectToAction("Index", "CheckingAccount");
            }

        }

        public ActionResult QuickCash()
        {
            var acc = _context.CheckingAccounts.Single(c => c.Id == 1);

            if (acc.Balance >= 100)
            {
                acc.Balance = acc.Balance - 100;
                TempData["Message"] = "You withdrew 100$ from your balance\n" + acc.Balance + "$ Left";
                _context.SaveChanges();
                return RedirectToAction("Index", "CheckingAccount");

            }
            else
            {
                TempData["Message"] = "You cannot withdraw 100$ from your account . \n You only have " + acc.Balance + "$ Left";
                return RedirectToAction("Index", "CheckingAccount");
            }

        }
        [Route("Transaction/TransferMoney")]
        public ActionResult TransferMoney()
        {
            return View();
        }
        [Route("Transaction/PrintStatement")]
        public IQueryable PrintStatement()
        {
            var x = _context.CheckingAccounts;
            return x;
            
            
        }
        public ActionResult ConfrimTransferMoney(Transaction ts)
        {
            string username = User.Identity.GetUserId();
            var acc = _context.CheckingAccounts.Single(c => c.ApplicationUserId == username);
            if(username == null)
            {
                return Content("Log in first");
            }
            var destination = ts.CheckingAccountId.ToString();
            if(acc.AccountNumber == destination)
            {
                return Content("You can't transfer to yourself");
            }
            var Amount = ts.Amount;
            var TF = _context.CheckingAccounts.SingleOrDefault(c => c.AccountNumber == destination);
            
            if (TF == null)
            {
                return Content("Receiver does not exist");
            }
            else
            {
                if (acc.Balance > Amount)
                {
                    acc.Balance = acc.Balance - Amount;
                    TF.Balance = TF.Balance + Amount;
                    Transaction Tsx = new Transaction()
                    {
                        Amount = Amount,
                        CheckingAccount = acc,
                        CheckingAccountId = int.Parse(TF.AccountNumber),
                        TransactionDate = DateTime.Now,
                        TransactionSource = acc.AccountNumber
                    };

                    _context.Transactions.Add(Tsx);
                    _context.SaveChanges();
                    return Content("Money transfered to account #" + destination + "You transfered : " + Amount + "$");
                
                }
                else
                {
                    return Content("You dont have enough money ");
                }
            }
        }
    }

}
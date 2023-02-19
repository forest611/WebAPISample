using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIServer.Controllers
{

    public class UserAndAMount
    {
        public string MCID { get; set; }
        public double Amount { get; set; }
    }
    
    [Route("api/[controller]")]
    public class BankController : Controller
    {

        [HttpGet("{mcid}")]
        public double GetBalance(string mcid)
        {
            var balance = Bank.GetBalance(mcid);

            Console.WriteLine($"Get:{balance}");

            return balance;
        }

        [HttpPost]
        public double SetBalance(UserAndAMount data)
        {
            var result = Bank.SetBalance(data.MCID, data.Amount);
            return result;
        }
        
        
    }
}


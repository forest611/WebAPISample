using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPIServer.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIServer.Controllers
{
    [Route("api/[controller]")]
    public class BankController : Controller
    {

        [HttpGet("{mcid}")]
        public double Get(string mcid)
        {
            var balance = Bank.GetBalance(mcid);

            Console.WriteLine($"Get:{balance}");

            return balance;
        }
    }
}


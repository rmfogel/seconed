using Server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class BankController : ApiController
    {
        [HttpGet]
        public BankNumbers[] GetAllNaumbers()
        {
            return BankList.GetBankNumbers();
        }
        
        public SniffNumbers[] GetAllSniffs(int id)
        {
            return SniffList.GetSniffNumbers(id);
        }

    }
}

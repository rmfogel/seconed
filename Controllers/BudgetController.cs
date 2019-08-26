using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class BudgetController : ApiController
    {


     
        public Models.MyBudgets[] Get()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<Models.MyBudgets> list = new List<Models.MyBudgets>();
                context.Budgets.ToList().ForEach(p => list.Add(new Models.MyBudgets(p)));
                return list.ToArray();
       
            }
        }
        [HttpPost]
        //[Route("api/Chaluka/newBudgets")]
        public string Post(Models.Budgets b)
        {

            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                DateTime DT =  DateTime.Today;
                b.DateOfAdd = DT;
                context.Budgets.Add(b);

                context.SaveChanges();
                return " ";
            }

        }
        public void Options() { }
    }
}

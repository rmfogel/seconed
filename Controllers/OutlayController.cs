using Server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class OutlayController : ApiController
    {
        [HttpGet]
        public Models.MyOutlay[] Get()
        {

            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Chaluka thisChaluka = new Chaluka();
                List<MyOutlay> list = new List<MyOutlay>();
                context.Outlay.ToList().ForEach(p => list.Add(new MyOutlay(p)));
                return list.ToArray();
            }

        }
        [HttpPost]

        public int Post(Models.Outlay[] o)
        {

            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Chaluka e = context.Chaluka.ToArray().LastOrDefault();
                int sum = 0;
                foreach (var item in o)
                {
                    Models.Outlay w = context.Outlay.FirstOrDefault(c => c.PersonId == item.PersonId && item.Date >= e.Date);
                    if (w == null)
                    {
                        item.ProjectId = 1;
                        item.TransferId = 1;
                        context.Outlay.Add(item);
                        if (context.Kolel.FirstOrDefault(a => a.id == context.Persons.FirstOrDefault(b => b.Id == item.PersonId).InstituteId) != null)
                        {
                            if (context.Kolel.FirstOrDefault(a => a.id == context.Persons.FirstOrDefault(b => b.Id == item.PersonId).InstituteId).HelpId == 1)
                                sum += e.SumKerenGive;
                            else
                            {
                                sum += e.SumGivePrecent;
                            }

                        }

                    }
                    // int a = context.Kolel.FirstOrDefault(u => u.id == context.Persons.FirstOrDefault(b => b.Id == item.PersonId).InstituteId).HelpId;
                    //  if (context.Kolel.FirstOrDefault(a=>a.id==context.Persons.FirstOrDefault(b=>b.Id==item.PersonId).InstituteId).HelpId==1)



                }
            
            if (sum != 0)
            {
                Models.Budgets b = new Models.Budgets();
                DateTime DT = DateTime.Today;
                b.DateOfAdd = DT;
                b.Sum = sum * -1;
                context.Budgets.Add(b);
            }



            context.SaveChanges();
            return sum;
        }


    }
    [HttpGet]
    [Route("api/Outlay/GetProjectName/{id}")]
    public string GetProjectName(int id)
    {

        using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
        {

            Projects p = context.Projects.FirstOrDefault(o => o.id == id);
            if (p != null)
                return p.Name;
            else
                return " ";
        }

    }
    public void Options() { }
}
}

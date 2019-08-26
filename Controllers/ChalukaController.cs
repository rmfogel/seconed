using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class ChalukaController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(Models.Chaluka c)
        {

            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                c.Date = new DateTime();
                context.Chaluka.Add(c);

                context.SaveChanges();

            }
            return Ok(c);

        }

      
      
        [HttpGet]

        public Models.MyChaluka Get()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<Models.MyChaluka> list = new List<Models.MyChaluka>();
                context.Chaluka.ToList().ForEach(p => list.Add(new Models.MyChaluka(p)));
                return list.ToArray().LastOrDefault();
                // return new Models.MyChaluka(context.Chaluka.LastOrDefault());
            }
        }
       
        
        public void Options() { }
    } 
    
}

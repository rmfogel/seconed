using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class KolelController : ApiController
    {
        public Models.MyKolel[] Get()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<Models.MyKolel> list = new List<Models.MyKolel>();
                context.Kolel.Where(c => c.DateOfDelete == null).ToList().ForEach(p => list.Add(new Models.MyKolel(p)));
                return list.ToArray();
            }
        }
        [HttpGet]
      
        public Models.MyKolel Get(int id)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Kolel k = context.Kolel.FirstOrDefault(y => y.id == id );
                if (k != null)
                    return new Models.MyKolel(k);
                else
                    return new Models.MyKolel();
            }
        }
        [HttpGet]
        [Route("api/kolel/GetOne/{pass}/{user}")]
        public Models.MyKolel GetOne(string pass,string user)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Kolel k = context.Kolel.FirstOrDefault(y => y.Password == pass && y.UserName == user);
                if (k != null)
                    return new Models.MyKolel(k);
                else
                    return new Models.MyKolel();
            }
        }
        [HttpGet]
        [Route("api/kolel/GetId/{id}/{id1}")]
        public int Get(string id,string id1)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                return context.Kolel.FirstOrDefault(k => k.Password == id&&k.UserName==id1).id;
            }
        }

        //public Models.MyPersons GetHeadKolel(Models.MyKolel k)
        //{
        //    using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
        //    {


        //       return new Models.MyPersons(context.Persons.FirstOrDefault(a => a.InstituteId == k.id && a.RoleId == 3));

        //    }

        //}
        //}
        [HttpGet]
        [Route("api/kolel/GetHelp")]
        public Models.MyHelp[] GetHelp()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<Models.MyHelp> list = new List<Models.MyHelp>();
                context.Help.ToList().ForEach(p => list.Add(new Models.MyHelp(p)));
                return list.ToArray();
            }
        }

        [HttpPost]
        //[Route("api/kolel/SetOkNew")]
        public string Post(Models.Kolel k)
        {
           
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                if (k.id == 0)
                {
                    if (k.Ok == null)
                    {
                        if (k.NumSniff == 0)
                            k.NumSniff = 5;
                        
                        k.Ok = false;
                        DateTime dt = DateTime.Today;
                        k.DateOfAdd = dt;
                        context.Kolel.Add(k);
                        context.SaveChanges();
                    }
                }
                else if(k.Ok==false)
                {
                    context.Kolel.Find(k.id).Ok = true;
                    context.SaveChanges();
                }
                else
                {
                    Models.Kolel n = context.Kolel.FirstOrDefault(o => o.id == k.id);
                    if (n != null)
                    {
                        n.AccountNumber = k.AccountNumber;
                        n.Bank = k.Bank;
                        n.KName = k.KName;
                        n.HelpId = k.HelpId;
                        n.City = k.City;
                        n.DateOfAdd = k.DateOfAdd;
                        n.DateOfDelete = k.DateOfDelete;
                        n.Email = k.Email;
                        n.Ok = k.Ok;
                        n.Space = k.Space;
                        n.Style = k.Style;
                        n.CalcBudget = k.CalcBudget;
                        n.UserName = k.UserName;
                        context.SaveChanges();
                    }
                    return "עודכן בהצלחה";
                }
            }
            return " ";
           // return Ok(k);
            
        }
        [HttpPost]
        [Route("api/kolel/deleteKolel")]
        public IHttpActionResult deleteKolel(int id)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Kolel k = context.Kolel.FirstOrDefault(p => p.id == id);
                DateTime dt =  DateTime.Today;
                k.DateOfDelete = dt;
                context.SaveChanges();
                return Ok(k);
            }
        }
        [HttpGet]
        [Route("api/kolel/checkPassUser/{pass}")]
        public bool checkPassUser(string pass)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Kolel k = context.Kolel.FirstOrDefault(l => l.Password == pass);
                Models.Persons p= context.Persons.FirstOrDefault(l => l.Password == pass);
                if (k != null||p!=null)
                {
                    return true;
                }
                return false;
            }
            }
       // [HttpPost]
       //// [Route("api/kolel/update")]
       // public string update(Models.Kolel p)
       // {
       //     using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
       //     {
       //         //צריך לשנות חיפוש 
             
       //     }
       // }

        public void Options() { }

    }
}

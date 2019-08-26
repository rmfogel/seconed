using Server2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server2.Controllers
{
    public class PersonController : ApiController
    {
        
       public Models.MyPersons[] Get()
        {

            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                //MyPersons[] users = AutoMapper.Mapper.Map<List<MyPersons>>(context.Persons).ToArray();
                //return users;
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.OrderBy(p => p.LastName.Trim()).ThenBy(p => p.FirstName.Trim()).Where(o=>o.RoleId==5).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray();
            }

        }
        [HttpGet]
        [Route("api/person/GetPersonBykolelIdRoulId/{Kolelid}/{RoulId}")]
        public Models.MyPersons GetPersonBykolelIdRoulId(int Kolelid,int RoulId)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {

                Persons p = context.Persons.FirstOrDefault(o => o.InstituteId == Kolelid && o.RoleId==RoulId );
                if (p != null)
                    return new MyPersons(p);
                else
                    return new MyPersons();
            }
        }
        [HttpGet]
        [Route("api/person/GetStudentsBykolelId/{Kolelid}")]
        public Models.MyPersons[] GetStudentsBykolelId(int Kolelid)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.Where(o => o.RoleId == 5 && o.InstituteId==Kolelid).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray();
             
            }
        }
        [HttpGet]
        [Route("api/person/GetStudentsNumBykolelId/{kolelid}")]
        public int GetStudentsNumBykolelId(int Kolelid)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.Where(o => o.RoleId == 5 && o.InstituteId == Kolelid).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray().Length;

            }
        }
        [HttpGet]
        [Route("api/person/GetWorkers")]
        public Models.MyPersons[] GetWorkers()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.Where(o => o.RoleId == 2).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray();

            }
        }
        [HttpGet]
        [Route("api/person/GetOne/{pass}/{user}")]
        //לא מגיע לכאן בכללל!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public Models.MyPersons GetOne(string pass,string user)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
               
           Persons p= context.Persons.FirstOrDefault(o => o.Password == pass && o.UserName == user);
                if (p != null)
                    return new MyPersons(p);
                else
                    return new MyPersons();
            }
        }
        [HttpGet]
        [Route("api/person/GetOneById/{id}")]
       
        public Models.MyPersons GetOneById(int id)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {

                Persons p = context.Persons.FirstOrDefault(o => o.Id == id );
                if (p != null)
                    return new MyPersons(p);
                else
                    return new MyPersons();
            }
        }
        [HttpGet]
        [Route("api/person/checkPass/{pass}")]
        public bool checkPass(string pass)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Persons p = context.Persons.FirstOrDefault(l => l.Password == pass);
                if (p != null)
                {
                    return true;
                }
                return false;
            }
        }
        
             [HttpGet]
        [Route("api/person/checkPassId/{pass}/{id}")]
        public bool checkPassId(string pass,int id)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Persons p = context.Persons.FirstOrDefault(l => l.Password == pass && l.Id!=id );
                if (p != null)
                {
                    return true;
                }
                return false;
            }
        }
        [HttpGet]
        [Route("api/person/getMaching")]
        public int getMaching()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                //DateTime dt = context.Chaluka.Last().Date;
                DateTime dt = context.Chaluka.ToArray().LastOrDefault().Date;
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.Where(o => o.Kolel.HelpId == 1 &&o.RoleId==5&& (o.Outlay.FirstOrDefault(r => r.DateDone != null && r.Date >= dt)) == null).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray().Length;
            }
        }
        [HttpGet]
        [Route("api/person/getPrecent")]
        public int getPrecent()
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                // new DateTime();
                //dt=    context.Chaluka.Last().Date;
               DateTime dt = context.Chaluka.ToArray().LastOrDefault().Date;
                List<MyPersons> list = new List<MyPersons>();
                context.Persons.Where(o => o.Kolel.HelpId == 2&& o.Staete== true&& o.RoleId == 5 && (o.Outlay.FirstOrDefault(r => r.DateDone != null && r.Date >=dt)) == null).ToList().ForEach(p => list.Add(new MyPersons(p)));
                return list.ToArray().Length;
            }
        }
        
        [HttpPost]
        public string AddPerson(Models.Persons p)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                if (p.Id==0 )
                {
                    Models.Persons n = context.Persons.FirstOrDefault(o => o.IdentityOrPassport == p.IdentityOrPassport&&p.IdentityOrPassport!=null);
                    if (n == null)
                    {
                        //  p.RoleId = context.Roles.Find(e).Id;
                        DateTime dt = DateTime.Today;
                       p.DateOfAdd = dt;
                        //p.DateOfAdd = new DateTime().Date;
                        context.Persons.Add(p);
                        context.SaveChanges();
                        return "נכנס";
                    }
                    else
                    {
                        return p.LastName + " " + p.IdentityOrPassport + " לא נכנס";
                    }
                }
                else
                {
                    Models.Persons n = context.Persons.FirstOrDefault(o => o.IdentityOrPassport == p.IdentityOrPassport);
                    if (n != null&&n.InstituteId==p.InstituteId)
                    {
                        n.AccountNumber = p.AccountNumber;
                        n.Bank = p.Bank;
                        n.CellPhone = p.CellPhone;
                        n.Children = p.Children;
                        n.City = p.City;
                        n.DateOfAdd = p.DateOfAdd;
                        n.DateOfDelete = p.DateOfDelete;
                        n.Email = p.Email;
                        n.FirstName = p.FirstName;
                       // n.Id = p.Id;
                        n.IdentityOrPassport = p.IdentityOrPassport;
                        n.InstituteId = p.InstituteId;
                        n.LastName = p.LastName;
                        n.NumHouse = p.NumHouse;
                        n.NumSniff = p.NumSniff;
                        n.Password = p.Password;
                        n.RoleId = p.RoleId;
                        n.Staete = p.Staete;
                        n.Street = p.Street;
                        n.UserName = p.UserName;
                        n.DateOfBirth = p.DateOfBirth;
                        context.SaveChanges();
                        
                        return "עודכן בהצלחה";
                    }
                    else
                    {
                        return "האברך קיים בכולל אחר";

                    }
                }
               
            }
        }

        //[HttpPost]
        ////[Route("api/person/update")]
        //public string UpdatePerson(Models.Persons p)
        //{
        //    using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
        //    {
               
              
        //    }
        //}
        [Route("api/person/GetHeadKolel/{k}")]
        [HttpGet]
        public Models.MyPersons GetHeadKolel(int k)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Persons p = context.Persons.FirstOrDefault(a => a.InstituteId == k && a.RoleId == 3);
                if (p != null)
                    return new Models.MyPersons(p);
                else
                    return null;

            }

        }
        [Route("api/person/GetContactKolel/{k}")]
        [HttpGet]
        public Models.MyPersons GetContactKolel(int k)
        {
            using (Models.KerenTorahEntities3 context = new Models.KerenTorahEntities3())
            {
                Models.Persons p = context.Persons.FirstOrDefault(a => a.InstituteId == k && a.RoleId == 4);
                if (p != null)
                    return new Models.MyPersons(p);
                else
                    return null;

            }

        }

        public void Options() { }

    }
}

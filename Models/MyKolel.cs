using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    
    public class MyKolel
    {
        public int id { get; set; }
        public string KName { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Bank { get; set; }
        public int NumSniff { get; set; }
        public string AccountNumber { get; set; }
        public System.DateTime DateOfAdd { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }
        public int HelpId { get; set; }
        public Nullable<bool> Ok { get; set; }
        public string Style { get; set; }
        public string Space { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<double> CalcBudget { get; set; }
        public int KodMosad { get; set; }

        
        public MyKolel()
        {

        }
        public MyKolel(Kolel k)
        {
            this.id = k.id;
            this.KName = k.KName;
            this.City = k.City;
            this.Adress = k.Adress;
            this.City = k.City;
            this.Bank = k.Bank;
            this.Email = k.Email;
            this.NumSniff = k.NumSniff;
            this.AccountNumber = k.AccountNumber;
            this.DateOfAdd = k.DateOfAdd;
            this.DateOfDelete = k.DateOfDelete;
            this.HelpId = k.HelpId;
            this.Ok = k.Ok;
            this.Style = k.Style;
            this.Space = k.Space;
            this.UserName = k.UserName;
            this.Password = k.Password;
            this.KodMosad = k.KodMosad;
        }
    }
}
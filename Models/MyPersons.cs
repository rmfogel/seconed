using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyPersons
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public Nullable<int> NumHouse { get; set; }
        public string CellPhone { get; set; }
        public string IdentityOrPassport { get; set; }
        public int? Bank { get; set; }
        public int? NumSniff { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<bool> Staete { get; set; }
        public Nullable<int> InstituteId { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfAdd { get; set; }
        public Nullable<System.DateTime> DateOfDelete { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Children { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }


        public MyPersons()
        {

        }
        public MyPersons(Persons p)
        {
            this.Id = p.Id;
            this.RoleId = p.RoleId;
            this.Street = p.Street;
            this.City = p.City;
            this.NumHouse = p.NumHouse;
            this.CellPhone = p.CellPhone;
            this.IdentityOrPassport = p.IdentityOrPassport;
            this.Bank = p.Bank;
            this.NumSniff = p.NumSniff;
            this.AccountNumber = p.AccountNumber;
            this.Staete = p.Staete;
            this.InstituteId = p.InstituteId;
            this.Email = p.Email;
            this.DateOfAdd = p.DateOfAdd;
            this.DateOfDelete = p.DateOfDelete;
            this.FirstName = p.FirstName;
            this.LastName = p.LastName;
            this.UserName = p.UserName;
            this.Password = p.Password;
            this.Children = p.Children;
            this.DateOfBirth = p.DateOfBirth;
        }
    }
}
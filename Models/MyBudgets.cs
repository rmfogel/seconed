using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyBudgets
    {
        public int id { get; set; }
        public int Sum { get; set; }
        public System.DateTime DateOfAdd { get; set; }
        public MyBudgets()
        {

        }
        public MyBudgets(Models.Budgets b)
        {
            this.id = b.id;
            this.Sum = b.Sum;
            this.DateOfAdd = b.DateOfAdd;
        }
       
    }
}
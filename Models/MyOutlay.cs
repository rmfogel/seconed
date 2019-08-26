using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyOutlay
    {

        public int id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<double> Sum { get; set; }
        public int ProjectId { get; set; }
        public int TransferId { get; set; }
        public int PersonId { get; set; }
        public Nullable<System.DateTime> DateDone { get; set; }
        public Nullable<int> UserId { get; set; }


        public MyOutlay()
        {

        }
        public MyOutlay(Outlay o)
        {
            this.id = o.id;
            this.Date = o.Date;
            this.Sum = o.Sum;
            this.ProjectId = o.ProjectId;
            this.TransferId = o.TransferId;
            this.PersonId = o.PersonId;
            this.DateDone = o.DateDone;
            this.UserId = o.UserId;
        }

    }
}
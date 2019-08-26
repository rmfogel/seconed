using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyChaluka
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int SumKerenGive { get; set; }
        public int SumkolelGive { get; set; }
        public int Precent { get; set; }
        public int SumGivePrecent { get; set; }
        public System.DateTime Date { get; set; }
        public MyChaluka(Chaluka c)
        {
            this.id = c.id;
            this.Name = c.Name;
            this.SumKerenGive = c.SumKerenGive;
            this.SumGivePrecent = c.SumGivePrecent;
            this.SumkolelGive = c.SumkolelGive;
            this.Precent = c.Precent;
            this.Date = c.Date;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyHelp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MyHelp()
        {

        }
        public MyHelp(Help h)
        {
            this.Id = h.Id;
            this.Name = h.Name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server2.Models
{
    public class MyProject
    {

        public int id { get; set; }
        public string Name { get; set; }

        public MyProject()
        {

        }
        public MyProject(Projects p)
        {
            this.id = p.id;
            this.Name = p.Name;
        }
    }
}
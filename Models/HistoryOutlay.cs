//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Server2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistoryOutlay
    {
        public int id { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<double> Sum { get; set; }
        public int ProjectId { get; set; }
        public int TransferId { get; set; }
        public int PersonId { get; set; }
    
        public virtual Persons Persons { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual Transfers Transfers { get; set; }
    }
}
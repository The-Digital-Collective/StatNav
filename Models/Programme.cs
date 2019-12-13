using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StatNav.Models
{
    public class Programme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Problem { get; set; }
        [ForeignKey("Status")]
        [Display(Name= "Status")]
        public int StatusID { get; set; }
        public Status Status { get; set; }
    }
}
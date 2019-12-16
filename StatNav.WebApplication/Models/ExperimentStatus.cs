using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class ExperimentStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
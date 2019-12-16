using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class Organisation
    {
        public int Id { get; set; }
        public string OrganisationName { get; set; }
        public bool Shared { get; set; }
    }
}
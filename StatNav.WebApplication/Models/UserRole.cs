using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public bool ReadTeamProgrammes { get; set; }

        public bool EditTeamProgrammes { get; set; }

        public bool ReadOrganisationProgrammes { get; set; }

        public bool EditOrganisationProgrammes { get; set; }

        public bool Administrator { get; set; }
    }
}
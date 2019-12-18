using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class Team
    {
        public int Id { get; set; }
        [ForeignKey("Organisation")]
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
        public string TeamName { get; set; }
        public bool Shared { get; set; }

    }
}
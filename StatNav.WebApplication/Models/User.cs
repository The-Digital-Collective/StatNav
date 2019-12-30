using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey("UserRole")]
        public int RoleId { get; set; }

        public UserRole UserRole { get; set; }

        public string Username { get; set; }

        public bool Shared { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class Method
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public string Title { get; set; }
    }
}
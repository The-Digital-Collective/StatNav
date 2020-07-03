using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class MarketingAssetPackage
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Team")]
        public int? TeamId { get; set; }

        public Team Team { get; set; }

        [Display(Name = "Package Name")]
        [Required]
        public string MAPName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Problem { get; set; }

        [Display(Name = "Problem Validation")]
        [DataType(DataType.MultilineText)]
        public string ProblemValidation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Hypothesis { get; set; }

        //STORY 2069 attributes removed from UI        

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ForeignKey("MarketingAssetPackageId")]
        public ICollection<Experiment> Experiments { get; set; }

        [ForeignKey("PackageContainer")]
        [Display(Name = "Container")]
        public int PackageContainerId { get; set; }

        public PackageContainer PackageContainer { get; set; }
    }
}
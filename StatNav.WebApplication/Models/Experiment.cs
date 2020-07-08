using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class Experiment
    {
        public int Id { get; set; }

        [ForeignKey("MarketingAssetPackage")]
        [Display(Name = "Marketing Asset Package")]
        public int MarketingAssetPackageId { get; set; }

        public MarketingAssetPackage MarketingAssetPackage { get; set; }

        [Display(Name = "Experiment Name")]
        [Required]
        public string ExperimentName { get; set; }

        [Display(Name = "Required Duration For Significance")]
        public string RequiredDurationForSignificance { get; set; }

        [Display(Name = "Experiment Number")]
        public int? ExperimentNumber { get; set; }

        [DataType(DataType.Date), UIHint("DatePicker"), Display(Name = "Start Date")]
        public DateTime? StartDateTime { get; set; }

        [DataType(DataType.Date), UIHint("DatePicker"), Display(Name = "End Date")]
        public DateTime? EndDateTime { get; set; }        

        [DataType(DataType.MultilineText)]
        [Display(Name = "Success Outcome")]
        public string SuccessOutcome { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Failure Outcome")]
        public string FailureOutcome { get; set; }

        [ForeignKey("ExperimentId")]
        public ICollection<Variant> Variants { get; set; }
    }
}
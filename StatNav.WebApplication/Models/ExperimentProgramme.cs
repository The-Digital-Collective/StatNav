using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class ExperimentProgramme
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
        public string ProgrammeName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Problem { get; set; }

        [Display(Name = "Problem Validation")]
        [DataType(DataType.MultilineText)]
        public string ProblemValidation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Hypothesis { get; set; }

        [ForeignKey("ProgrammeMethod")]
        [Display(Name = "Method")]
        public int MethodId { get; set; }

        public Method ProgrammeMethod { get; set; }

        [ForeignKey("ProgrammeTargetMetricModel")]
        [Display(Name = "Target Metric")]
        public int ProgrammeTargetMetricModelId { get; set; }

        public MetricModel ProgrammeTargetMetricModel { get; set; }

        [Display(Name = "Target Value")]
        public float TargetValue { get; set; }

        [ForeignKey("ProgrammeImpactMetricModel")]
        [Display(Name = "Impact Metric")]
        public int ProgrammeImpactMetricModelId { get; set; }

        public MetricModel ProgrammeImpactMetricModel { get; set; }

        [Display(Name = "Impact Value")]
        public float ImpactValue { get; set; }        

        [ForeignKey("ExperimentStatus")]
        [Display(Name = "Status")]
        public int ExperimentStatusId { get; set; }

        public ExperimentStatus ExperimentStatus { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ForeignKey("ExperimentProgrammeId")]
        public ICollection<ExperimentIteration> ExperimentIterations { get; set; }

        [ForeignKey("PackageContainer")]
        [Display(Name = "Package Container")]
        public int? PackageContainerId { get; set; }
        // TODO
        public PackageContainer PackageContainer { get; set; }
    }
}
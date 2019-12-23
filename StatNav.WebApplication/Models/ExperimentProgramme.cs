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

        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Problem { get; set; }

        [Display(Name = "Problem Validation")]
        [DataType(DataType.MultilineText)]
        public string ProblemValidation { get; set; }

        [DataType(DataType.MultilineText)]
        public string Hypothesis { get; set; }

        [DataType(DataType.MultilineText)]
        public string Method { get; set; }

        [ForeignKey("TargetMetricModel")]
        [Display(Name = "Target Metric")]
        public int TargetMetricModelId { get; set; }

        public MetricModel TargetMetricModel { get; set; }

        [Display(Name = "Target Value")]
        public float TargetValue { get; set; }

        [ForeignKey("ImpactMetricModel")]
        [Display(Name = "Impact Metric")]
        public int ImpactMetricModelId { get; set; }

        public MetricModel ImpactMetricModel { get; set; }

        [Display(Name = "Impact Value")]
        public float ImpactValue { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Success Outcome")]
        public string SuccessOutcome { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Failure Outcome")]
        public string FailureOutcome { get; set; }

        [ForeignKey("ExperimentStatus")]
        [Display(Name = "Status")]
        public int ExperimentStatusId { get; set; }

        public ExperimentStatus ExperimentStatus { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ForeignKey("ExperimentProgrammeId")]
        public ICollection<ExperimentIteration> ExperimentIterations { get; set; }
    }
}
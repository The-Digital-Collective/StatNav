using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class ExperimentProgramme
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Problem { get; set; }

        [Display(Name = "Problem Validation")]
        public string ProblemValidation { get; set; }

        public string Hypothesis { get; set; }

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

        [Display(Name = "Success Outcome")]
        public string SuccessOutcome { get; set; }

        [Display(Name = "Failure Outcome")]
        public string FailureOutcome { get; set; }

        [ForeignKey("ExperimentStatus")]
        [Display(Name = "Status")]
        public int ExperimentStatusId { get; set; }

        public ExperimentStatus ExperimentStatus { get; set; }

        public string Notes { get; set; }
    }
}
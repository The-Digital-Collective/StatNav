using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class ExperimentCandidate
    {
        public int Id { get; set; }
        [Display(Name = "Experiment Iteration")]
        public int ExperimentIterationId { get; set; }

        public ExperimentIteration ExperimentIteration { get; set; }
        [Required]
        public string Name { get; set; }

        public bool Control { get; set; }

        [ForeignKey("TargetMetric")]
        [Display(Name = "Target Metric")]
        public int TargetMetricModelId { get; set; }

        public MetricModel TargetMetricModel { get; set; }

        [Display(Name = "Target Met")]
        public bool TargetMet { get; set; }

        [ForeignKey("ImpactMetric")]
        [Display(Name = "Impact Metric")]
        public int ImpactMetricModelId { get; set; }

        public MetricModel ImpactMetricModel { get; set; }

        [Display(Name = "Impact Met")]
        public bool ImpactMet { get; set; }

        
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class ExperimentCandidate
    {
        public int Id { get; set; }
        [Display(Name = "Experiment")]
        public int ExperimentId { get; set; }

        public Experiment Experiment{ get; set; }

        [Display(Name = "Candidate Name")]
        [Required]
        public string CandidateName { get; set; }

        public bool Control { get; set; }

        [ForeignKey("CandidateTargetMetricModel")]
        [Display(Name = "Target Metric")]
        public int CandidateTargetMetricModelId { get; set; }

        public MetricModel CandidateTargetMetricModel { get; set; }

        [Display(Name = "Target Met")]
        public bool TargetMet { get; set; }

        [ForeignKey("CandidateImpactMetricModel")]
        [Display(Name = "Impact Metric")]
        public int CandidateImpactMetricModelId { get; set; }

        public MetricModel CandidateImpactMetricModel { get; set; }

        [Display(Name = "Impact Met")]
        public bool ImpactMet { get; set; }

        
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class MetricCandidateResult
    {
        public int Id { get; set; }

        [ForeignKey("MetricModel")]
        public int MetricId { get; set; }

        public MetricModel MetricModel { get; set; }

        [ForeignKey("ExperimentCandidate")]
        public int  ExperimentCandidateId { get; set; }

        public ExperimentCandidate ExperimentCandidate { get; set; }

        public float Value { get; set; }

        public float SampleSize { get; set; }

    }
}
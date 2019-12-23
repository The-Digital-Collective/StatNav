using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

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
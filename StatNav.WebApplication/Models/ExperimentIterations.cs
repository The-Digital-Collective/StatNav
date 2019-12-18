using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class ExperimentIteration
    {
        public int Id { get; set; }
        [ForeignKey("ExperimentProgramme")]
        public int ExperimentProgrammeId { get; set; }
        public ExperimentProgramme ExperimentProgramme { get; set; }
        public string RequiredDurationForSignificance { get; set; }
        public int IterationNumber { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
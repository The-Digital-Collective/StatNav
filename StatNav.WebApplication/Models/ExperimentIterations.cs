using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class ExperimentIteration
    {
        public int Id { get; set; }

        [ForeignKey("ExperimentProgramme")]
        [Display(Name = "Experiment Programme")]
        public int ExperimentProgrammeId { get; set; }

        public ExperimentProgramme ExperimentProgramme { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Required Duration For Significance")]
        public string RequiredDurationForSignificance { get; set; }

        public int IterationNumber { get; set; }

        [DataType(DataType.Date), UIHint("DatePicker"), Display(Name = "Start Date")]
        public DateTime StartDateTime { get; set; }

        [DataType(DataType.Date), UIHint("DatePicker"), Display(Name = "End Date")]
        public DateTime EndDateTime { get; set; }

        [ForeignKey("ExperimentIterationId")]
        public ICollection<ExperimentCandidate> ExperimentCandidates { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class PackageContainer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Package Container Name")]
        public string PackageContainerName { get; set; }

        [Required]
        public string Type { get; set; }

        [Display(Name = "Stage")]
        public int MetricModelStageId { get; set; }

        public MetricModelStage MetricModelStage { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [ForeignKey("PackageContainerId")]
        public ICollection<ExperimentProgramme> ExperimentProgrammes { get; set; }
    }
}
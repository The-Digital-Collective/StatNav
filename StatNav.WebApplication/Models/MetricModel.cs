using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StatNav.WebApplication.Models
{
    public class MetricModel
    {
        public int Id { get; set; }
        [ForeignKey("MetricModelStage")]
        [Display(Name = "Metric Model Stage")]
        public int MetricModelStageId { get; set; }
        public MetricModelStage MetricModelStage { get; set; }
        public string Title { get; set; }
        [Display(Name = "Good Is Up")]
        public bool GoodIsUp { get; set; }
    }
}
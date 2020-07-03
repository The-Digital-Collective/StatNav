using System.ComponentModel.DataAnnotations.Schema;

namespace StatNav.WebApplication.Models
{
    public class MetricVariantResult
    {
        public int Id { get; set; }

        [ForeignKey("MetricModel")]
        public int MetricId { get; set; }

        public MetricModel MetricModel { get; set; }

        [ForeignKey("Variant")]
        public int  VariantId { get; set; }

        public Variant Variant { get; set; }

        public float Value { get; set; }

        public float SampleSize { get; set; }

    }
}
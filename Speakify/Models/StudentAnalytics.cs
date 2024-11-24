namespace Speakify.Models
{
    public class StudentAnalytics : StudentAccessRequest
    {
        public List<QuantitativeAnalytic> QuantAnalytics { get; set; } = new();
        public List<QualitativeAnalytic> QualAnalytics { get; set; } = new();

    }
}

namespace Speakify.Models
{
    public class StudentAnalytics
    {
        public int InveniraStdID { get; set; }
        public List<QuantitativeAnalytic> QuantAnalytics { get; set; } = new();
        public List<QualitativeAnalytic> QualAnalytics { get; set; } = new();

    }
}

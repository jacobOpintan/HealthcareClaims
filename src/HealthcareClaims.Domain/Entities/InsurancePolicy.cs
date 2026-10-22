namespace HealthcareClaims.Domain.Entities
{
    public class InsurancePolicy
    {
        public int InsurancePolicyId { get; set; }
        public int PatientId { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string InsuranceProviderName { get; set; } = string.Empty;
        public DateOnly CoverageStartDate { get; set; }
        public DateOnly CoverageEndDate { get; set; }
        public decimal CoverageLimit { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

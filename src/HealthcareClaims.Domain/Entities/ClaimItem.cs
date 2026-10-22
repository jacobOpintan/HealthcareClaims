using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthcareClaims.Domain.Entities
{
    public class ClaimItem
    {
        public int ClaimItemId { get; set; }
        public int ClaimId { get; set; }
        public int MedicalServiceId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileRecharge.Models
{
    public class History
    {
        [Key]
        public int HistoryId { get; set; }
       
        public IdentityUser CustomerId { get; set; }

        [ForeignKey("Recharge")]
        public int PlanId { get; set; }

        public RechargeModel Recharge { get; set; }
    }
}

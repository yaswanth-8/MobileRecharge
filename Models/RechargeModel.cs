using System.ComponentModel.DataAnnotations;

namespace MobileRecharge.Models
{
    public class RechargeModel
    {
        [Key]
        public int Id { get; set; }
        public string PlanName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}

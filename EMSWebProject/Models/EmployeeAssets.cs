using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSWebProject.Models
{
    public class EmployeeAssets
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int AssetId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public string Remarks { get; set; }

      
    }
}

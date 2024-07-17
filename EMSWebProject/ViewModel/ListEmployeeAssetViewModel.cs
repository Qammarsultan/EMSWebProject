using System.ComponentModel.DataAnnotations;

namespace EMSWebProject.ViewModel
{
    public class ListEmployeeAssetViewModel
    {
        public int Id { get; set; }
        public string Emp_Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }



    //Asset Detail
        public string Asset_Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PurchasingPrice { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}

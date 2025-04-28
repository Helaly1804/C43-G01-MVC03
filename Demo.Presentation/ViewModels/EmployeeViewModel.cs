using Demo.DataAccess.Models.DepartmentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo.Presentation.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The length should be less than 50 characters")]
        [MinLength(5, ErrorMessage = "The length should be greater than 5 characters")]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Address must be like 123-street-city-country")]
        public string Address { get; set; } = string.Empty;
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Range(22, 35)]
        public int Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        [Display(Name = "Hire Date")]
        public DateOnly HireDate { get; set; }
        public string? Gender { get; set; }
        public string? EmployeeType { get; set; }
        public int? DepartmentId { get; set; }
        public string? Department { get; set; }
    }
}

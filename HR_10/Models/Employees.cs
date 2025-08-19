// Models/Employee.cs
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_10.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uid { get; set; }

        [Required]
        [StringLength(250)]
        public string EmployeeID { get; set; }

        [StringLength(250)]
        public string? EmployeeName { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? CNIC { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? FatherName { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? DOB { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? MobileNo { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? Department { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? Designation { get; set; } // Changed to nullable

        public DateTime? DateOfJoining { get; set; }

        [StringLength(250)]
        public string? EmployeeStatus { get; set; } // Changed to nullable

        public string? ModifiedBy { get; set; } // Changed to nullable

        [StringLength(250)]
        public string? ModifiedOn { get; set; } // Changed to nullable

        public string? Details { get; set; } // Changed to nullable

        [StringLength(50)]
        public string? Project { get; set; } // Changed to nullable

        public double? CarryForwardLeaves { get; set; }

        public double? Year2022 { get; set; }

        public double? Year2023 { get; set; }

        public int? AdjustedAjusted { get; set; }

        public int? Year2024 { get; set; }

        public double? CarryForwardLeaves1 { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Year2023New { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BasicSalary { get; set; }

        [StringLength(20)]
        public string? ApplyTax { get; set; } // Changed to nullable
    }
}
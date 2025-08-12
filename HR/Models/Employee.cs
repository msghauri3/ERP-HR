using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.Models
{
    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Column("uid")]
        public int Uid { get; set; }

        [Required]
        [StringLength(250)]
        public string EmployeeID { get; set; } = null!;

        [StringLength(250)]
        public string? EmployeeName { get; set; }

        [StringLength(250)]
        public string? CNIC { get; set; }

        [StringLength(250)]
        public string? FatherName { get; set; }

        [StringLength(250)]
        public string? DOB { get; set; } // kept as string because in DB it's varchar

        [StringLength(250)]
        public string? MobileNo { get; set; }

        [StringLength(250)]
        public string? Department { get; set; }

        [StringLength(250)]
        public string? Designation { get; set; }

        public DateTime? DateOfJoining { get; set; }

        [StringLength(250)]
        public string? EmployeeStatus { get; set; }

        public string? ModifiedBy { get; set; } // varchar(max)

        [StringLength(250)]
        public string? ModifiedOn { get; set; }

        public string? Details { get; set; } // nvarchar(max)

        [StringLength(50)]
        public string? Project { get; set; }

        public double? CarryForwardLeaves { get; set; }
        public double? Year2022 { get; set; }
        public double? Year2023 { get; set; }
        public int? AdjustedAjusted { get; set; }
        public int? Year2024 { get; set; }
        public double? CarryForwardLeaves1 { get; set; }
        public decimal? Year2023New { get; set; }
        public decimal? BasicSalary { get; set; }

        [StringLength(20)]
        public string? ApplyTax { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HR.Models;

[Table("Configuration")]
public partial class Configuration
{
    [Key]
    [Column("UID")]
    public int Uid { get; set; }

    [StringLength(50)]
    public string? ConfigKey { get; set; }

    [StringLength(50)]
    public string? ConfigValue { get; set; }
}

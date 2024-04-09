using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using e_Parcel.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

public class ShoppingSession
{
    public Guid Id { get; set; }

    public string? UserId { get; set; } = null;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }


    [ForeignKey("UserId")]
    public UserLogin User { get; set; } = null!;
}

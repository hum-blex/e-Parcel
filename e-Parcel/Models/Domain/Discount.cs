using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models.Domain;

public class Discount
{
    public Guid Id { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? DiscountPercentage { get; set; }

    public bool? Active { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(50)]
    public string? ModifiedBy { get; set; }

    public bool? IsDeleted { get; set; }

}

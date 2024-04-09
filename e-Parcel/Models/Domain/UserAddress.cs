using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

public class UserAddress
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Address { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(20)]
    public string? Country { get; set; }

    [StringLength(50)]
    public string? Telephone { get; set; }

    [StringLength(50)]
    public string Mobile { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    public string? PostalCode { get; set; }

    [ForeignKey("UserId")]
    public UserLogin User { get; set; } = null!;
}

﻿using System.ComponentModel.DataAnnotations;

namespace e_Parcel.Models.Domain;

public class UserLogin
{
    public Guid Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    public DateTime CreatedOn { get; set; }

    public DateTime? LoginTime { get; set; }

    public DateTime? LogoutTime { get; set; }

    public bool? IsDisabled { get; set; }

    [StringLength(10)]
    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
}

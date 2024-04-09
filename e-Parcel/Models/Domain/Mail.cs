using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

public class Mail
{
    public Guid Id { get; set; }

    public string From { get; set; } = null!;

    public string To { get; set; } = null!;

    public string? Subject { get; set; }

    public string? Body { get; set; }

    public string? AttachmentUrl { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public string Code { get; set; } = null!;
}

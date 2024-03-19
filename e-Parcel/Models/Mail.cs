using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.Models;

public partial class Mail
{
    [Key]
    public int Id { get; set; }

    [Unicode(false)]
    public string From { get; set; } = null!;

    [Unicode(false)]
    public string To { get; set; } = null!;

    [Unicode(false)]
    public string? Subject { get; set; }

    [Unicode(false)]
    public string? Body { get; set; }

    [Unicode(false)]
    public string? AttachmentUrl { get; set; }

    public DateTime CreatedDateTime { get; set; }

    [Column("code")]
    [Unicode(false)]
    public string Code { get; set; } = null!;
}

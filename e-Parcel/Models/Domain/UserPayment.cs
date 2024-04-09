using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class UserPayment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [StringLength(50)]
    public string PaymentType { get; set; } = null!;

    [StringLength(50)]
    public string Provider { get; set; } = null!;

    [ForeignKey("UserId")]
    public UserLogin User { get; set; } = null!;
}

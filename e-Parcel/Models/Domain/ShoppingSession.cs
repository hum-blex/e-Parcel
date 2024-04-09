using System.ComponentModel.DataAnnotations.Schema;

namespace e_Parcel.Models.Domain;

public class ShoppingSession
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }


    [ForeignKey("UserId")]
    public UserLogin User { get; set; } = null!;
}

using e_Parcel.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace e_Parcel.DataAccess;

public partial class ApplicationDbContext : IdentityDbContext<AppUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{
	}

	public virtual DbSet<CartItem> CartItems { get; set; }

	public virtual DbSet<Category> Categories { get; set; }

	public virtual DbSet<Discount> Discounts { get; set; }

	public virtual DbSet<Mail> Mails { get; set; }

	public virtual DbSet<OrderDetail> OrderDetails { get; set; }

	public virtual DbSet<OrderItem> OrderItems { get; set; }

	public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

	public virtual DbSet<Product> Products { get; set; }

	public virtual DbSet<ProductInventory> ProductInventories { get; set; }

	public virtual DbSet<ShoppingSession> ShoppingSessions { get; set; }

	public virtual DbSet<UserAddress> UserAddresses { get; set; }

	public virtual DbSet<UserPayment> UserPayments { get; set; }
	public virtual DbSet<Portfolio> Portfolios { get; set; }
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.OrderItemId }));

		builder.Entity<Portfolio>()
			.HasOne(p => p.AppUser)
			.WithMany(p => p.Portfolios)
			.HasForeignKey(p => p.AppUserId);

		builder.Entity<Portfolio>()
			.HasOne(p => p.OrderItem)
			.WithMany(p => p.Portfolios)
			.HasForeignKey(p => p.OrderItemId);

		builder.Entity<OrderDetail>()
			.HasOne(o => o.Payment)
			.WithOne(p => p.Order)
			.HasForeignKey<PaymentDetail>(p => p.OrderId);

		builder.Entity<OrderDetail>()
			.HasOne(o => o.User)
			.WithMany()
			.HasForeignKey(o => o.UserId);

		builder.Entity<ShoppingSession>()
			.HasOne(s => s.User)
			.WithMany()
			.HasForeignKey(s => s.UserId);

		builder.Entity<PaymentDetail>()
			.HasOne(p => p.Order)
			.WithOne(o => o.Payment)
			.HasForeignKey<OrderDetail>(o => o.Id);

		List<IdentityRole> roles = new List<IdentityRole>()
			{
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN"
				},
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER"
				},
			};
		builder.Entity<IdentityRole>().HasData(roles);
	}
}
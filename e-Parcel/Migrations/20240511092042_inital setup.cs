using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace e_Parcel.Migrations
{
	/// <inheritdoc />
	public partial class initalsetup : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "AspNetRoles",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoles", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUsers",
				columns: table => new
				{
					Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
					LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
					IsDisabled = table.Column<bool>(type: "bit", nullable: true),
					UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
					PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
					SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
					PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
					TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
					LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
					LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
					AccessFailedCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUsers", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Categories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
					DisplayOrder = table.Column<int>(type: "int", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					IsDeleted = table.Column<bool>(type: "bit", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Categories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Discounts",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					DiscountPercentage = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
					Active = table.Column<bool>(type: "bit", nullable: true),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					IsDeleted = table.Column<bool>(type: "bit", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Discounts", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Mails",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					From = table.Column<string>(type: "nvarchar(max)", nullable: false),
					To = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
					AttachmentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
					CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Mails", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ProductInventories",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ProductInventories", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "AspNetRoleClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserClaims",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
					ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
					table.ForeignKey(
						name: "FK_AspNetUserClaims_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserLogins",
				columns: table => new
				{
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
					ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
					table.ForeignKey(
						name: "FK_AspNetUserLogins_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserRoles",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
						column: x => x.RoleId,
						principalTable: "AspNetRoles",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_AspNetUserRoles_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "AspNetUserTokens",
				columns: table => new
				{
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
					table.ForeignKey(
						name: "FK_AspNetUserTokens_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "OrderDetails",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Total = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
					PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrderDetails", x => x.Id);
					table.ForeignKey(
						name: "FK_OrderDetails_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "ShoppingSessions",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Total = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ShoppingSessions", x => x.Id);
					table.ForeignKey(
						name: "FK_ShoppingSessions_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserAddresses",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
					City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
					Telephone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserAddresses", x => x.Id);
					table.ForeignKey(
						name: "FK_UserAddresses_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "UserPayments",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					PaymentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					Provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_UserPayments", x => x.Id);
					table.ForeignKey(
						name: "FK_UserPayments_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Products",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
					CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ImageUrl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
					DiscountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					InventoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
					Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Products", x => x.Id);
					table.ForeignKey(
						name: "FK_Products_Categories_CategoryId",
						column: x => x.CategoryId,
						principalTable: "Categories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Products_Discounts_DiscountId",
						column: x => x.DiscountId,
						principalTable: "Discounts",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Products_ProductInventories_InventoryId",
						column: x => x.InventoryId,
						principalTable: "ProductInventories",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "PaymentDetails",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
					Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
					Provider = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PaymentDetails", x => x.Id);
					table.ForeignKey(
						name: "FK_PaymentDetails_OrderDetails_OrderId",
						column: x => x.OrderId,
						principalTable: "OrderDetails",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "CartItems",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: true),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CartItems", x => x.Id);
					table.ForeignKey(
						name: "FK_CartItems_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_CartItems_ShoppingSessions_SessionId",
						column: x => x.SessionId,
						principalTable: "ShoppingSessions",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "OrderItems",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Quantity = table.Column<int>(type: "int", nullable: false),
					ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
					ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_OrderItems", x => x.Id);
					table.ForeignKey(
						name: "FK_OrderItems_OrderDetails_OrderId",
						column: x => x.OrderId,
						principalTable: "OrderDetails",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_OrderItems_Products_ProductId",
						column: x => x.ProductId,
						principalTable: "Products",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Portfolios",
				columns: table => new
				{
					AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					OrderItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Portfolios", x => new { x.AppUserId, x.OrderItemId });
					table.ForeignKey(
						name: "FK_Portfolios_AspNetUsers_AppUserId",
						column: x => x.AppUserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Portfolios_OrderItems_OrderItemId",
						column: x => x.OrderItemId,
						principalTable: "OrderItems",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "AspNetRoles",
				columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
				values: new object[,]
				{
					{ "11004dee-d794-45d9-80eb-dd45390f657b", null, "Admin", "ADMIN" },
					{ "1d10d340-730c-4e07-800e-ed52219095fa", null, "User", "USER" }
				});

			migrationBuilder.CreateIndex(
				name: "IX_AspNetRoleClaims_RoleId",
				table: "AspNetRoleClaims",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "RoleNameIndex",
				table: "AspNetRoles",
				column: "NormalizedName",
				unique: true,
				filter: "[NormalizedName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserClaims_UserId",
				table: "AspNetUserClaims",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserLogins_UserId",
				table: "AspNetUserLogins",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_AspNetUserRoles_RoleId",
				table: "AspNetUserRoles",
				column: "RoleId");

			migrationBuilder.CreateIndex(
				name: "EmailIndex",
				table: "AspNetUsers",
				column: "NormalizedEmail");

			migrationBuilder.CreateIndex(
				name: "UserNameIndex",
				table: "AspNetUsers",
				column: "NormalizedUserName",
				unique: true,
				filter: "[NormalizedUserName] IS NOT NULL");

			migrationBuilder.CreateIndex(
				name: "IX_CartItems_ProductId",
				table: "CartItems",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_CartItems_SessionId",
				table: "CartItems",
				column: "SessionId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderDetails_UserId",
				table: "OrderDetails",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderItems_OrderId",
				table: "OrderItems",
				column: "OrderId");

			migrationBuilder.CreateIndex(
				name: "IX_OrderItems_ProductId",
				table: "OrderItems",
				column: "ProductId");

			migrationBuilder.CreateIndex(
				name: "IX_PaymentDetails_OrderId",
				table: "PaymentDetails",
				column: "OrderId",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_Portfolios_OrderItemId",
				table: "Portfolios",
				column: "OrderItemId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_CategoryId",
				table: "Products",
				column: "CategoryId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_DiscountId",
				table: "Products",
				column: "DiscountId");

			migrationBuilder.CreateIndex(
				name: "IX_Products_InventoryId",
				table: "Products",
				column: "InventoryId");

			migrationBuilder.CreateIndex(
				name: "IX_ShoppingSessions_UserId",
				table: "ShoppingSessions",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserAddresses_UserId",
				table: "UserAddresses",
				column: "UserId");

			migrationBuilder.CreateIndex(
				name: "IX_UserPayments_UserId",
				table: "UserPayments",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "AspNetRoleClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserClaims");

			migrationBuilder.DropTable(
				name: "AspNetUserLogins");

			migrationBuilder.DropTable(
				name: "AspNetUserRoles");

			migrationBuilder.DropTable(
				name: "AspNetUserTokens");

			migrationBuilder.DropTable(
				name: "CartItems");

			migrationBuilder.DropTable(
				name: "Mails");

			migrationBuilder.DropTable(
				name: "PaymentDetails");

			migrationBuilder.DropTable(
				name: "Portfolios");

			migrationBuilder.DropTable(
				name: "UserAddresses");

			migrationBuilder.DropTable(
				name: "UserPayments");

			migrationBuilder.DropTable(
				name: "AspNetRoles");

			migrationBuilder.DropTable(
				name: "ShoppingSessions");

			migrationBuilder.DropTable(
				name: "OrderItems");

			migrationBuilder.DropTable(
				name: "OrderDetails");

			migrationBuilder.DropTable(
				name: "Products");

			migrationBuilder.DropTable(
				name: "AspNetUsers");

			migrationBuilder.DropTable(
				name: "Categories");

			migrationBuilder.DropTable(
				name: "Discounts");

			migrationBuilder.DropTable(
				name: "ProductInventories");
		}
	}
}

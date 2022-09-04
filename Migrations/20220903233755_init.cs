using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReverseEnginereeing.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(name: "Company Name", type: "varchar(24)", unicode: false, maxLength: 24, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(124)", maxLength: 124, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alpha2Code = table.Column<string>(name: "Alpha-2 Code", type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Alpha3Code = table.Column<string>(name: "Alpha-3 Code", type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Numeric = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Experience Levels",
                columns: table => new
                {
                    Level = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Experien__AAF89963FD7FB909", x => x.Level);
                });

            migrationBuilder.CreateTable(
                name: "House types",
                columns: table => new
                {
                    TypeID = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__House ty__516F039547DF580F", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => new { x.Id, x.UserName });
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK__People__CompanyI__35BCFE0A",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "SalesMen",
                columns: table => new
                {
                    SalesManID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(name: "Phone Number", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HireDate = table.Column<DateTime>(name: "Hire Date", type: "datetime", nullable: false),
                    BirthDate = table.Column<DateTime>(name: "Birth Date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesMen", x => x.SalesManID);
                    table.ForeignKey(
                        name: "FK__SalesMen__Compan__3A81B327",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK__Cities__CountryI__2B3F6F97",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SalesManID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    Level = table.Column<string>(type: "nchar(8)", fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Speciali__6F0E227E2287D5F7", x => new { x.SalesManID, x.TypeID });
                    table.ForeignKey(
                        name: "FK__Specializ__Level__440B1D61",
                        column: x => x.Level,
                        principalTable: "Experience Levels",
                        principalColumn: "Level");
                    table.ForeignKey(
                        name: "FK__Specializ__Sales__4222D4EF",
                        column: x => x.SalesManID,
                        principalTable: "SalesMen",
                        principalColumn: "SalesManID");
                    table.ForeignKey(
                        name: "FK__Specializ__TypeI__4316F928",
                        column: x => x.TypeID,
                        principalTable: "House types",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Neighborhoods",
                columns: table => new
                {
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "char(30)", unicode: false, fixedLength: true, maxLength: 30, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhoods", x => x.NeighborhoodID);
                    table.ForeignKey(
                        name: "FK__Neighborh__CityI__2E1BDC42",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    HouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    BuiltAt = table.Column<DateTime>(name: "Built At", type: "datetime", nullable: true),
                    SizeM2 = table.Column<int>(name: "Size (M^2)", type: "int", nullable: false),
                    Rooms = table.Column<int>(type: "int", nullable: false),
                    WantedPrice = table.Column<decimal>(name: "Wanted Price", type: "money", nullable: false),
                    ForSale = table.Column<bool>(name: "For Sale", type: "bit", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: true),
                    TypeID = table.Column<string>(type: "nchar(20)", fixedLength: true, maxLength: 20, nullable: false),
                    NeighborhoodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.HouseID);
                    table.ForeignKey(
                        name: "FK__Houses__Neighbor__4CA06362",
                        column: x => x.NeighborhoodID,
                        principalTable: "Neighborhoods",
                        principalColumn: "NeighborhoodID");
                    table.ForeignKey(
                        name: "FK__Houses__OwnerID__4AB81AF0",
                        column: x => x.OwnerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK__Houses__TypeID__4BAC3F29",
                        column: x => x.TypeID,
                        principalTable: "House types",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    BuyerID = table.Column<int>(type: "int", nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: false),
                    SalesManID = table.Column<int>(type: "int", nullable: false),
                    FinalPrice = table.Column<decimal>(name: "Final Price", type: "money", nullable: true),
                    Income = table.Column<float>(type: "real", nullable: false, defaultValueSql: "((0.05))"),
                    Saledate = table.Column<DateTime>(name: "Sale date", type: "datetime", nullable: true),
                    PublishDate = table.Column<DateTime>(name: "Publish Date", type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK__Sales__BuyerID__5165187F",
                        column: x => x.BuyerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FK__Sales__HouseID__5070F446",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "HouseID");
                    table.ForeignKey(
                        name: "FK__Sales__SalesManI__5441852A",
                        column: x => x.SalesManID,
                        principalTable: "SalesMen",
                        principalColumn: "SalesManID");
                    table.ForeignKey(
                        name: "FK__Sales__SellerID__52593CB8",
                        column: x => x.SellerID,
                        principalTable: "People",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "UQ__Countrie__E056F2012BF2DF16",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Countrie__FD07398E49BCA584",
                table: "Countries",
                column: "Numeric",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_NeighborhoodID",
                table: "Houses",
                column: "NeighborhoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_OwnerID",
                table: "Houses",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_TypeID",
                table: "Houses",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhoods_CityId",
                table: "Neighborhoods",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CompanyID",
                table: "People",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "UQ__People__79578B9397F0A394",
                table: "People",
                column: "Phone Number",
                unique: true,
                filter: "[Phone Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_BuyerID",
                table: "Sales",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_HouseID",
                table: "Sales",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SalesManID",
                table: "Sales",
                column: "SalesManID");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_SellerID",
                table: "Sales",
                column: "SellerID");

            migrationBuilder.CreateIndex(
                name: "UQ__Sales__1EE3C41EB7AF572C",
                table: "Sales",
                column: "SaleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesMen_CompanyID",
                table: "SalesMen",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "UQ__SalesMen__79578B937FEB9CB2",
                table: "SalesMen",
                column: "Phone Number",
                unique: true,
                filter: "[Phone Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_Level",
                table: "Specialization",
                column: "Level");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_TypeID",
                table: "Specialization",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Experience Levels");

            migrationBuilder.DropTable(
                name: "SalesMen");

            migrationBuilder.DropTable(
                name: "Neighborhoods");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "House types");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

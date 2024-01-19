using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment3Rafia.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
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
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceOrState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipOrPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerms",
                columns: table => new
                {
                    PaymentTermsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DueDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerms", x => x.PaymentTermsId);
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
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTotal = table.Column<double>(type: "float", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentTermsId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_PaymentTerms_PaymentTermsId",
                        column: x => x.PaymentTermsId,
                        principalTable: "PaymentTerms",
                        principalColumn: "PaymentTermsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicesLineItems",
                columns: table => new
                {
                    InvoiceLineItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicesLineItems", x => x.InvoiceLineItemId);
                    table.ForeignKey(
                        name: "FK_InvoicesLineItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address1", "Address2", "City", "ContactEmail", "ContactFirstName", "ContactLastName", "IsDeleted", "Name", "Phone", "ProvinceOrState", "ZipOrPostalCode" },
                values: new object[,]
                {
                    { 1, "27371 Valderas", null, "Mission Viejo", "kgonz@bja.com", "Keeton", "Gonzalo", false, "Blanchard & Johnson Associates", "214-555-3647", "CA", "92691" },
                    { 2, "3255 Ramos Cir", null, "Sacramento", "manton@gmail.com", "Mauro", "Anton", false, "California Chamber Of Commerce", "916-555-6670", "CA", "95827" },
                    { 3, "PO Box 85826", null, "San Diego", null, "Jane", "Smith", false, "Golden Eagle Insurance Co", "917-544-7090", "CA", "92186" },
                    { 4, "1952 H Street", "P.O. Box 1952", "Fresno", null, "Chad", "Jones", false, "Fresno Photoengraving Company", "559-555-3005", "CA", "93718" },
                    { 5, "Ohio Valley Litho Division", null, "Cincinnate", null, "Paul", "Morgan", false, "Nielson", "519-824-3477", "OH", "45264" },
                    { 6, "PO Box 40513", null, "Jacksonville", "gerald.kristoff@outlook.com", "Gerald", "Kristoff", false, "Naylor Publications Inc", "800-555-6041", "FL", "32231" },
                    { 7, "60 Madison Ave", null, "New York", "tneftaly@venture.com", "Thalia", "Neftaly", false, "Venture Communications", "212-533-4800", "NY", "10010" },
                    { 8, "Attn:  Supt. Window Services", "PO Box 7005", "Madison", null, "Alberto", "Francesco", false, "US Postal Service", "800-555-1205", "WI", "53707" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTerms",
                columns: new[] { "PaymentTermsId", "Description", "DueDays" },
                values: new object[,]
                {
                    { 1, "Net due 10 days", 10 },
                    { 2, "Net due 20 days", 20 },
                    { 3, "Net due 30 days", 30 },
                    { 4, "Net due 60 days", 60 },
                    { 5, "Net due 90 days", 90 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CustomerId", "InvoiceDate", "PaymentDate", "PaymentTermsId", "PaymentTotal" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 2, 1, new DateTime(2022, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 3, 2, new DateTime(2022, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 4, 2, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 5, 3, new DateTime(2022, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 6, 3, new DateTime(2022, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, 0.0 },
                    { 7, 4, new DateTime(2022, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 8, 4, new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, 0.0 },
                    { 9, 5, new DateTime(2022, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 10, 6, new DateTime(2022, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 },
                    { 11, 7, new DateTime(2022, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, 0.0 },
                    { 12, 8, new DateTime(2022, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "InvoicesLineItems",
                columns: new[] { "InvoiceLineItemId", "Amount", "Description", "InvoiceId" },
                values: new object[,]
                {
                    { 1, 1089.99, "Part 123", 1 },
                    { 2, 173499.5, "Service XYZ", 1 },
                    { 3, 4654499.5, "Part 110", 2 },
                    { 4, 78799.5, "Part A", 2 },
                    { 5, 679.5, "Part AA", 3 },
                    { 6, 786.89999999999998, "Part Z", 3 },
                    { 7, 998.5, "Trip 1", 4 },
                    { 8, 1011.5, "Service XYZ", 4 },
                    { 9, 565735.5, "Rental DEF", 5 },
                    { 10, 5753.5, "Rental ZZZ", 5 },
                    { 11, 58453.900000000001, "Service ABC", 6 },
                    { 12, 111232.5, "Service ABC", 6 },
                    { 13, 109.5, "Rental ABC", 7 },
                    { 14, 57846.5, "Rental ABC", 8 },
                    { 15, 132.5, "Trip 2", 9 },
                    { 16, 6877.8999999999996, "Service XYZ", 9 },
                    { 17, 8999.5, "Trip 3", 10 },
                    { 18, 1033.5, "Blah blah", 10 },
                    { 19, 56455.5, "Ho hum", 11 },
                    { 20, 1454589.5, "Fiddle dee", 11 },
                    { 21, 583453.5, "Service ABC", 12 },
                    { 22, 567.5, "Fiddle dum", 12 }
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
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentTermsId",
                table: "Invoices",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicesLineItems_InvoiceId",
                table: "InvoicesLineItems",
                column: "InvoiceId");
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
                name: "InvoicesLineItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "PaymentTerms");
        }
    }
}

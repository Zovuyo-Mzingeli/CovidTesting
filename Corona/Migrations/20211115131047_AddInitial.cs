using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Corona.Migrations
{
    public partial class AddInitial : Migration
    {
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
                name: "EditUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SuburbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalAidId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlanId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditUserViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCity",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCity", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "tblClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblMedicalPlans",
                columns: table => new
                {
                    MedicalPlanId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicalAidId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicalPlans", x => x.MedicalPlanId);
                });

            migrationBuilder.CreateTable(
                name: "tblProvince",
                columns: table => new
                {
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProvince", x => x.ProvinceId);
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
                name: "tblSuburb",
                columns: table => new
                {
                    SuburbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SuburbName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSuburb", x => x.SuburbId);
                    table.ForeignKey(
                        name: "FK_tblSuburb_tblCity_CityId",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblMedicalAid",
                columns: table => new
                {
                    MedicalAidId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MedicalPlanId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblMedicalAid", x => x.MedicalAidId);
                    table.ForeignKey(
                        name: "FK_tblMedicalAid_tblMedicalPlans_MedicalPlanId",
                        column: x => x.MedicalPlanId,
                        principalTable: "tblMedicalPlans",
                        principalColumn: "MedicalPlanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idnumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SuburbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserStatus = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    MedicalAidId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalAidNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PlanId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalPlanId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProvinceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblMedicalAid_MedicalAidId",
                        column: x => x.MedicalAidId,
                        principalTable: "tblMedicalAid",
                        principalColumn: "MedicalAidId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblMedicalPlans_MedicalPlanId",
                        column: x => x.MedicalPlanId,
                        principalTable: "tblMedicalPlans",
                        principalColumn: "MedicalPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblProvince_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "tblProvince",
                        principalColumn: "ProvinceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_tblSuburb_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                name: "PatientVitals",
                columns: table => new
                {
                    VitalsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodPressure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OxygenLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NurseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LabUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientVitals", x => x.VitalsId);
                    table.ForeignKey(
                        name: "FK_PatientVitals_AspNetUsers_LabUserId",
                        column: x => x.LabUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientVitals_AspNetUsers_NurseId",
                        column: x => x.NurseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientVitals_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblDependent",
                columns: table => new
                {
                    DependentId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Idnumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SuburbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PatientId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalAidId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalAidNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicalPlanId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MainMemberId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDependent", x => x.DependentId);
                    table.ForeignKey(
                        name: "FK_tblDependent_AspNetUsers_MainMemberId",
                        column: x => x.MainMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDependent_tblCity_CityId",
                        column: x => x.CityId,
                        principalTable: "tblCity",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDependent_tblMedicalAid_MedicalAidId",
                        column: x => x.MedicalAidId,
                        principalTable: "tblMedicalAid",
                        principalColumn: "MedicalAidId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDependent_tblMedicalPlans_MedicalPlanId",
                        column: x => x.MedicalPlanId,
                        principalTable: "tblMedicalPlans",
                        principalColumn: "MedicalPlanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblDependent_tblSuburb_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblFavourateSuburb",
                columns: table => new
                {
                    FavouriteId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    SuburbId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NurseId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFavourateSuburb", x => x.FavouriteId);
                    table.ForeignKey(
                        name: "FK_tblFavourateSuburb_AspNetUsers_NurseId",
                        column: x => x.NurseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblFavourateSuburb_tblSuburb_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblTestBooking",
                columns: table => new
                {
                    TestBookingId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, defaultValueSql: "(newid())"),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeSlot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NurseId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblTestBooking", x => x.TestBookingId);
                    table.ForeignKey(
                        name: "FK_tblTestBooking_AspNetUsers_NurseId",
                        column: x => x.NurseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblRequestTest",
                columns: table => new
                {
                    RequestId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false, defaultValueSql: "(newid())"),
                    NurseId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RequestorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DependentId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuburbId = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRequestTest", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_tblRequestTest_AspNetUsers_NurseId",
                        column: x => x.NurseId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestTest_AspNetUsers_RequestorId",
                        column: x => x.RequestorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestTest_tblDependent_DependentId",
                        column: x => x.DependentId,
                        principalTable: "tblDependent",
                        principalColumn: "DependentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblRequestTest_tblSuburb_SuburbId",
                        column: x => x.SuburbId,
                        principalTable: "tblSuburb",
                        principalColumn: "SuburbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressLine1", "AddressLine2", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "Idnumber", "LastName", "LockoutEnabled", "LockoutEnd", "MedicalAidId", "MedicalAidNumber", "MedicalPlanId", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlanId", "ProvinceId", "SecurityStamp", "SuburbId", "TwoFactorEnabled", "UserName", "UserStatus" },
                values: new object[] { "1", 0, null, null, "2f9658cb-9407-4ad8-89d6-657bd8e1ce39", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null, null, false, null, null, null, null, null, null, "maria", null, false, null, null, "70546a47-84ca-4df1-998f-50d94a27ab67", null, false, "maria@gmail.com", "A" });

            migrationBuilder.InsertData(
                table: "tblCity",
                columns: new[] { "CityId", "CityName" },
                values: new object[] { "1", "Gqeberha" });

            migrationBuilder.InsertData(
                table: "tblMedicalAid",
                columns: new[] { "MedicalAidId", "MedicalName", "MedicalPlanId" },
                values: new object[,]
                {
                    { "1", "BestMed", null },
                    { "2", "Bonitas", null },
                    { "3", "Discovery Health", null }
                });

            migrationBuilder.InsertData(
                table: "tblMedicalPlans",
                columns: new[] { "MedicalPlanId", "MedicalAidId", "PlanName" },
                values: new object[,]
                {
                    { "26", "3", "Classic Comprehensive" },
                    { "27", "3", "Classic Delta Comprehensive" },
                    { "28", "3", "Classic Smart Comprehensive" },
                    { "29", "3", "Essential Comprehensive" },
                    { "30", "3", "Essential Delta" },
                    { "31", "3", "Essential Comprehensive" },
                    { "32", "3", "Essential Priority" },
                    { "33", "3", "Classic Saver" },
                    { "34", "3", "Classic Delta Saver" },
                    { "35", "3", "Essential Saver" },
                    { "37", "3", "Coastal Saver" },
                    { "25", "3", "Executive" },
                    { "38", "3", "Classic Smart" },
                    { "39", "3", "Essential Smart" },
                    { "40", "3", "Classic Core" },
                    { "41", "3", "Classic Delta Core" },
                    { "42", "3", "Essential Core" },
                    { "43", "3", "Essential Delta Core" },
                    { "44", "3", "Coastal Core" },
                    { "45", "3", "Keycare Plus" },
                    { "36", "3", "Essential Delta Saver" },
                    { "24", "2", "BonCap" },
                    { "21", "2", "Hospital Standard" },
                    { "22", "2", "BonEssential" },
                    { "1", "1", "Beat 1" },
                    { "2", "1", "Beat 2" },
                    { "3", "1", "Beat 3" },
                    { "4", "1", "Beat 4" },
                    { "5", "1", "Pulse 1" },
                    { "6", "1", "Pulse 2" },
                    { "7", "1", "Pace 1" },
                    { "8", "1", "Pulse 2" },
                    { "9", "1", "Pulse 3" },
                    { "10", "1", "Pulse 4" },
                    { "11", "2", "BonStart" },
                    { "12", "2", "Primary" },
                    { "13", "2", "Primary Select" }
                });

            migrationBuilder.InsertData(
                table: "tblMedicalPlans",
                columns: new[] { "MedicalPlanId", "MedicalAidId", "PlanName" },
                values: new object[,]
                {
                    { "14", "2", "Standard" },
                    { "15", "2", "Standard Select" },
                    { "16", "2", "BonFit Select" },
                    { "17", "2", "BonSave" },
                    { "18", "2", "BonComplete" },
                    { "19", "2", "BonClassic" },
                    { "20", "2", "BonComprehensive" },
                    { "46", "3", "Keycare Smart" },
                    { "23", "2", "BonEssentialSelect" },
                    { "47", "3", "Keycare Core" }
                });

            migrationBuilder.InsertData(
                table: "tblSuburb",
                columns: new[] { "SuburbId", "CityId", "SuburbName" },
                values: new object[,]
                {
                    { "57", "1", "Humewood" },
                    { "126", "1", "Summerstrand" },
                    { "127", "1", "Summerwood" },
                    { "56", "1", "Humerail" },
                    { "91", "1", "New Brighton" }
                });

            migrationBuilder.InsertData(
                table: "tblDependent",
                columns: new[] { "DependentId", "AddressLine1", "AddressLine2", "CityId", "Dob", "Email", "FirstName", "Gender", "Idnumber", "LastName", "MainMemberId", "MedicalAidId", "MedicalAidNumber", "MedicalPlanId", "PatientId", "PhoneNumber", "PostalCode", "SuburbId" },
                values: new object[] { "91", "19 Admirality Way", "", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "daleen@gmail.com", "Daleen", null, "8009160225083", "Meintjies", null, null, "285465885", "8", "2", "0832458796", null, "126" });

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
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalAidId",
                table: "AspNetUsers",
                column: "MedicalAidId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalPlanId",
                table: "AspNetUsers",
                column: "MedicalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProvinceId",
                table: "AspNetUsers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SuburbId",
                table: "AspNetUsers",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitals_LabUserId",
                table: "PatientVitals",
                column: "LabUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitals_NurseId",
                table: "PatientVitals",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientVitals_PatientId",
                table: "PatientVitals",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependent_CityId",
                table: "tblDependent",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependent_MainMemberId",
                table: "tblDependent",
                column: "MainMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependent_MedicalAidId",
                table: "tblDependent",
                column: "MedicalAidId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependent_MedicalPlanId",
                table: "tblDependent",
                column: "MedicalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDependent_SuburbId",
                table: "tblDependent",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavourateSuburb_NurseId",
                table: "tblFavourateSuburb",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFavourateSuburb_SuburbId",
                table: "tblFavourateSuburb",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblMedicalAid_MedicalPlanId",
                table: "tblMedicalAid",
                column: "MedicalPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestTest_DependentId",
                table: "tblRequestTest",
                column: "DependentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestTest_NurseId",
                table: "tblRequestTest",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestTest_RequestorId",
                table: "tblRequestTest",
                column: "RequestorId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRequestTest_SuburbId",
                table: "tblRequestTest",
                column: "SuburbId");

            migrationBuilder.CreateIndex(
                name: "IX_tblSuburb_CityId",
                table: "tblSuburb",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tblTestBooking_NurseId",
                table: "tblTestBooking",
                column: "NurseId");
        }

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
                name: "EditUserViewModel");

            migrationBuilder.DropTable(
                name: "PatientVitals");

            migrationBuilder.DropTable(
                name: "tblClaims");

            migrationBuilder.DropTable(
                name: "tblFavourateSuburb");

            migrationBuilder.DropTable(
                name: "tblRequestTest");

            migrationBuilder.DropTable(
                name: "tblTestBooking");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "tblDependent");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "tblMedicalAid");

            migrationBuilder.DropTable(
                name: "tblProvince");

            migrationBuilder.DropTable(
                name: "tblSuburb");

            migrationBuilder.DropTable(
                name: "tblMedicalPlans");

            migrationBuilder.DropTable(
                name: "tblCity");
        }
    }
}

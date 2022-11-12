using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookReadingEvent.ProductDomain.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Comment1 = table.Column<string>(nullable: true),
                    EventID = table.Column<int>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatorID = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    StartTime = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OtherDetails = table.Column<string>(nullable: true),
                    InviteByEmail = table.Column<string>(nullable: true),
                    Creator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetailTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PolicyTypeID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    ProductCode = table.Column<string>(maxLength: 50, nullable: false),
                    IRDACode = table.Column<string>(maxLength: 50, nullable: false),
                    ProposalIssueDaysLimit = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<Guid>(nullable: false),
                    CreatedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    ModifiedOnDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedByUserID = table.Column<int>(nullable: false),
                    ModifiedByUserID = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailID = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    InvitedEvent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EventDetailTable");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}

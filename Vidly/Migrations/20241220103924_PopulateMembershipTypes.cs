using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO ""MembershipTypes"" (""Id"", ""SignUpFee"", ""DurationInMonths"", ""DiscountRate"")
                VALUES 
                    (1, 0, 0, 0),
                    (2, 30, 1, 10),
                    (3, 90, 3, 15),
                    (4, 300, 12, 15);
                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

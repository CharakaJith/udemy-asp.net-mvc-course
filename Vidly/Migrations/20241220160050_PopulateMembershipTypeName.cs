using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                UPDATE ""MembershipTypes""
                SET ""Name"" = CASE
                    WHEN ""Id"" = 1 THEN 'Pay as you go'
                    WHEN ""Id"" = 2 THEN 'Monthly'
                    WHEN ""Id"" = 3 THEN 'Quarterly'
                    WHEN ""Id"" = 4 THEN 'Yearly'
                END
                WHERE ""Id"" IN (1, 2, 3, 4);
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

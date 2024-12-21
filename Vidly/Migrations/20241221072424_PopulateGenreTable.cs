using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                Insert INTO ""Genres"" (""Id"", ""Name"")
                VALUES
                   (1, 'Action'),
                   (2, 'Adventure'),
                   (3, 'Animation'),
                   (4, 'Comedy'),
                   (5, 'Crime'),
                   (6, 'Drama'),
                   (7, 'Fantasy'),
                   (8, 'Horror'),
                   (9, 'Mystery'),
                   (10, 'Romance'),
                   (11, 'Sci-Fi'),
                   (12, 'Thriller'),
                   (13, 'War'),
                   (14, 'Western'),
                   (15, 'Psychological');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

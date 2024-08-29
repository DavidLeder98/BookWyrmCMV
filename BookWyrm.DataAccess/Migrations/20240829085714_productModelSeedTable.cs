using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookWyrm.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class productModelSeedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Gandalor Toadbottom", "Learn the fundamentals of cantrips with this beginner-friendly guide. Perfect for aspiring wizards looking to master simple spells and impress friends at parties. No prior experience needed!", "987-0-420-70457-0", 24.989999999999998, "Cantrips for Beginners" },
                    { 2, "Gawb Lynnhunter", "A straightforward manual on goblin slaying for those new to adventuring. Packed with practical tips, tricks, and safety advice to keep you alive and victorious in the heat of battle.", "987-0-911-80085-0", 29.989999999999998, "Goblin Slaying for Dummies" },
                    { 3, "Rudolf the Armless", "An essential safety manual for aspiring dragon tamers, written by a seasoned expert. Discover the dos and don'ts of dealing with dragons while avoiding the common pitfalls that might cost you an arm and a leg.", "987-0-777-11701-0", 69.989999999999995, "A Dragon Tamer's Safety Guide" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PayCoreWebAPITutorial.Migrations
{
    public partial class ProductView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE VIEW  VW_PRODUCT AS SELECT Name FROM PRODUCTS");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

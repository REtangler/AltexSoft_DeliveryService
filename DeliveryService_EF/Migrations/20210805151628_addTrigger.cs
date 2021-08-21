using Microsoft.EntityFrameworkCore.Migrations;

namespace DeliveryService_EF.Migrations
{
    public partial class addTrigger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER insertLogger ON Products AFTER INSERT AS PRINT 'A product has been added to database'");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER insertLogger");
        }
    }
}

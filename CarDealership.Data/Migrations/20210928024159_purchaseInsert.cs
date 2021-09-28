using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Data.Migrations
{
    public partial class purchaseInsert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "e615748d-d145-458f-9010-474fef488d78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "2a86cb2e-4a17-469a-94e9-5d5e9e3d983b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "7a8e1ebd-e686-4bab-98da-a373c4d08608");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0bf7803f-0b81-4e97-9545-9e78774adf14", "AQAAAAEAACcQAAAAEGG1GkdaMQS4LwPztqOSacysCSjwPPPs6XVfF7xDxJYnuwvrC2uaub0pgxMaMJhqdQ==" });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "UserId", "VehicleId", "Name", "EmailAddress", "PhoneNumber", "StreetAddress1", "StreetAddress2", "City", "StateId", "ZipCode", "PurchasePrice", "PurchaseTypeId" },
                values: new object[,]
                {
                               {1,"B22698B8-42A2-4115-9631-1C2D1E2AC5F7",2,"test","spitum@gmail.com","xxxxxxxx","112 Test Drive","","ALBUQUERQUE","NM","87111","35500.00",1}
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01B168FE-810B-432D-9010-233BA0B380E9",
                column: "ConcurrencyStamp",
                value: "1c3b9248-37e1-4995-8b3d-7652640645e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2301D884-221A-4E7D-B509-0113DCC043E1",
                column: "ConcurrencyStamp",
                value: "9d7ce58e-7e96-4a69-9453-e4530e7864a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78A7570F-3CE5-48BA-9461-80283ED1D94D",
                column: "ConcurrencyStamp",
                value: "a11f81ab-7940-43e3-a9d7-3a552c748d2e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "B22698B8-42A2-4115-9631-1C2D1E2AC5F7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5cab8044-0899-4097-9e5e-d34a08db99c7", "AQAAAAEAACcQAAAAEAo1g6b2I7rH2E1MFLRwFC6bcgeHRgBri3YObJo8wudtzxZOAyWq3i0UP+LZ8spMew==" });
        }
    }
}

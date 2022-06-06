using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApi.SqlServerMigrations
{
	public partial class CreateEmployeeSps : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"CREATE PROCEDURE Sp_CreateEmployee (
										@Name NVARCHAR(50),
										@Email NVARCHAR(50),					
										@Phone NVARCHAR(15),
										@Title NVARCHAR(50),
										@CompanyId INT,
										@Id INT OUTPUT) AS
										BEGIN
											INSERT INTO Employees (Name, Email, Phone, Title, CompanyId) VALUES (@Name, @Email, @Phone, @Title, @CompanyId);
											SELECT @Id = CAST(SCOPE_IDENTITY() AS INT);
										END");

			migrationBuilder.Sql(@"CREATE PROCEDURE Sp_GetAllEmployees 
									AS BEGIN
										SELECT Id, Name, Email, Phone, Title, CompanyId FROM Employees
									END");

			migrationBuilder.Sql(@"CREATE PROCEDURE Sp_GetEmployee (
										@Id INT) AS
										BEGIN
											SELECT Id, Name, Email, Phone, Title, CompanyId FROM Employees
											WHERE Id = @Id
										END");

			migrationBuilder.Sql(@"CREATE PROCEDURE Sp_DeleteEmployee (
										@Id INT) AS
										BEGIN
											DELETE Employees
											WHERE Id = @Id
										END");

			migrationBuilder.Sql(@"CREATE PROCEDURE Sp_UpdateEmployee (
										@Id INT,
										@Name NVARCHAR(50),
										@Email NVARCHAR(50),
										@Phone NVARCHAR(50),
										@Title NVARCHAR(50)) AS
										BEGIN
											UPDATE Employees SET Name = @Name, Email = @Email, Phone = @Phone, Title = @Title
											WHERE Id = @Id
										END");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP PROCEDURE Sp_CreateEmployee");
			migrationBuilder.Sql("DROP PROCEDURE Sp_GetAllEmployees");
			migrationBuilder.Sql("DROP PROCEDURE Sp_GetEmployee");
			migrationBuilder.Sql("DROP PROCEDURE Sp_DeleteEmployee");
			migrationBuilder.Sql("DROP PROCEDURE Sp_UpdateEmployee");
		}
	}
}

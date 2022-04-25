using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyApi.Services;

public class EmployeeService : IEmployeeService
{
	private readonly IDbConnection db;
	private readonly ICompanyService companyService;

	public EmployeeService(ICompanyService companyService, IConfiguration configuration)
	{
		db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
		this.companyService = companyService;
	}

	public async Task<Employee> Add(Employee employee)
	{
		if (!await companyService.Contains(employee.CompanyId))
			throw new ArgumentException("Invalid CompanyId");

		var query = @"INSERT INTO Employees (Name, Email, Phone, Title, CompanyId) VALUES (@Name, @Email, @Phone, @Title, @CompanyId);
						SELECT CAST(SCOPE_IDENTITY() AS INT);";

		employee.Id = await db.ExecuteAsync(query, employee);
		return employee;
	}

	public async Task<ICollection<Employee>> GetAll()
	{
		return (await db.QueryAsync<Employee>("SELECT * FROM Employees")).ToList();
	}

	public async Task<Employee> GetEmployee(int id)
	{
		return await db.QueryFirstOrDefaultAsync<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { id });
	}

	public async Task<bool> Remove(int id)
	{
		var query = "DELETE Employees WHERE Id = @Id";

		var result = await db.ExecuteAsync(query, new { id });
		return result > 0;
	}

	public async Task<bool> Update(Employee employee)
	{
		var query = @"UPDATE Employees SET Name = @Name, Email = @Email, Phone = @Phone, Title = @Title
						WHERE Id = @Id";

		var result = await db.ExecuteAsync(query, employee);
		return result > 0;
	}
}
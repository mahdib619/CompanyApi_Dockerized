using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CompanyApi.Services;

public class EmployeeServiceSP : IEmployeeService
{
	private readonly IDbConnection db;
	private readonly ICompanyService companyService;

	public EmployeeServiceSP(ICompanyService companyService, IConfiguration configuration)
	{
		db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
		this.companyService = companyService;
	}

	public async Task<Employee> Add(Employee employee)
	{
		if (!await companyService.Contains(employee.CompanyId))
			throw new ArgumentException("Invalid CompanyId");

		var query = @"Sp_CreateEmployee";

		var arguments = new DynamicParameters();
		arguments.Add("Name", employee.Name, DbType.String);
		arguments.Add("Email", employee.Email, DbType.String);
		arguments.Add("Phone", employee.Phone, DbType.String);
		arguments.Add("Title", employee.Title, DbType.String);
		arguments.Add("CompanyId", employee.CompanyId, DbType.Int32);
		arguments.Add("Id", null, DbType.Int32, ParameterDirection.Output);

		await db.ExecuteAsync(query, arguments, commandType: CommandType.StoredProcedure);
		employee.Id = arguments.Get<int>("Id");

		return employee;
	}

	public async Task<ICollection<Employee>> GetAll()
	{
		return (await db.QueryAsync<Employee>("Sp_GetAllEmployees", commandType: CommandType.StoredProcedure)).ToList();
	}

	public async Task<Employee> GetEmployee(int id)
	{
		return await db.QueryFirstOrDefaultAsync<Employee>("Sp_GetEmployee", new { id }, commandType: CommandType.StoredProcedure);
	}

	public async Task<bool> Remove(int id)
	{
		var query = "Sp_DeleteEmployee";

		var result = await db.ExecuteAsync(query, new { id }, commandType: CommandType.StoredProcedure);
		return result > 0;
	}

	public async Task<bool> Update(Employee employee)
	{
		var query = @"Sp_UpdateEmployee";

		var result = await db.ExecuteAsync(query, employee.ToAnonymous(a => a.Company, a => a.CompanyId), commandType: CommandType.StoredProcedure);
		return result > 0;
	}
}
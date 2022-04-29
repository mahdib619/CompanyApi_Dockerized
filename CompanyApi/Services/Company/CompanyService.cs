using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services;

public class CompanyService : ICompanyService
{
	private readonly IDbConnection db;

	public CompanyService(IConfiguration configuration)
	{
		db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
	}

	public async Task<Company> Add(Company company)
	{
		var query = @"INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES (@Name, @Address, @City, @State, @PostalCode);
						SELECT CAST(SCOPE_IDENTITY() AS INT);";

		var id = await db.QueryFirstAsync<int>(query, company);
		company.Id = id;

		return company;
	}

	public async Task<ICollection<Company>> GetAll(bool includeEmployees = true)
	{
		if (!includeEmployees)
			return (await db.QueryAsync<Company>("SELECT * FROM Companies")).ToList();

		var query = @"SELECT c.*, e.* FROM Companies AS c
					  LEFT JOIN Employees AS e ON c.Id = e.CompanyId";

		var companiesDic = new Dictionary<int, Company>();
		var companies = (await db.QueryAsync<Company, Employee, Company>(query, (c, e) =>
		{
			if (!companiesDic.TryGetValue(c.Id, out var company))
				companiesDic[c.Id] = company = c;

			if (e is not null)
				company.Employees.Add(e);
			return company;
		})).ToList();

		return companiesDic.Values;
	}

	public async Task<Company> GetCompany(int id, bool includeEmployees = false)
	{
		if (!includeEmployees)
			return await db.QueryFirstOrDefaultAsync<Company>("SELECT * FROM Companies WHERE Id = @Id", new { id });

		var query = @"SELECT * FROM Companies WHERE Id = @Id;
					  SELECT * FROM Employees WHERE CompanyId = @Id";

		using var sets = await db.QueryMultipleAsync(query, new { id });

		var company = await sets.ReadSingleOrDefaultAsync<Company>();
		if (company is null)
			return null;

		company.Employees = (await sets.ReadAsync<Employee>()).ToList();

		return company;
	}

	public async Task<bool> Remove(int id)
	{
		var query = "DELETE Companies where Id = @Id";

		var result = await db.ExecuteAsync(query, new { id });
		return result > 0;
	}

	public async Task<bool> Update(Company company)
	{
		var query = @"UPDATE Companies SET Name = @Name, Address = @Address, City = @City, State = @State, PostalCode = @PostalCode
						WHERE Id = @Id";

		var result = await db.ExecuteAsync(query, company);
		return result > 0;
	}

	public async Task<bool> Contains(int id)
	{
		var query = "SELECT 1 FROM Companies where Id = @Id";

		var result = await db.ExecuteScalarAsync<int>(query, new { id });
		return result > 0;
	}
}
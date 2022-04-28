using System.Data;
using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace CompanyApi.Services;

public class EmployeeServiceContrib : IEmployeeService
{
	private readonly IDbConnection db;
	private readonly ICompanyService companyService;
	private readonly IMapper mapper;

	public EmployeeServiceContrib(ICompanyService companyService, IConfiguration configuration, IMapper mapper)
	{
		db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
		this.companyService = companyService;
		this.mapper = mapper;
	}

	public async Task<Employee> Add(Employee employee)
	{
		if (!await companyService.Contains(employee.CompanyId))
			throw new ArgumentException("Invalid CompanyId");

		employee.Id = await db.InsertAsync(employee);
		return employee;
	}

	public async Task<ICollection<Employee>> GetAll()
	{
		return (await db.GetAllAsync<Employee>()).ToList();
	}

	public async Task<Employee> GetEmployee(int id)
	{
		return await db.GetAsync<Employee>(id);
	}

	public async Task<bool> Remove(int id)
	{
		return await db.DeleteAsync(new Employee { Id = id});
	}

	public async Task<bool> Update(Employee employee)
	{
		var employeeDb = await GetEmployee(employee.Id);

		if (employee is null)
			return false;

		mapper.Map(employee, employeeDb);
		return await db.UpdateAsync(employeeDb);
	}
}
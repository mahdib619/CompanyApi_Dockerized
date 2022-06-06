using System.Data;
using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services;

public class EmployeeService : IEmployeeService
{
	private readonly ICompanyService companyService;
	private readonly ApplicationDbContext context;
	private readonly IMapper mapper;

	public EmployeeService(ICompanyService companyService, ApplicationDbContext context, IMapper mapper)
	{
		this.companyService = companyService;
		this.context = context;
		this.mapper = mapper;
	}

	public async Task<Employee> Add(Employee employee)
	{
		if (!await companyService.Contains(employee.CompanyId))
			throw new ArgumentException("Invalid CompanyId");

		context.Employees.Add(employee);
		await context.SaveChangesAsync();

		return employee;
	}

	public async Task<ICollection<Employee>> GetAll()
	{
		return await context.Employees.ToListAsync();
	}

	public async Task<Employee> GetEmployee(int id)
	{
		return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
	}

	public async Task<bool> Remove(int id)
	{
		var employee = await GetEmployee(id);
		if (employee is null)
			return false;

		context.Employees.Remove(employee);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Update(Employee employee)
	{
		var employeeDb = await GetEmployee(employee.Id);

		if (employeeDb is null)
			return false;

		mapper.Map(employee, employeeDb);
		await context.SaveChangesAsync();

		return true;
	}
}
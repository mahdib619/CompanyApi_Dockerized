using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Server.Data;
using CompanyApp.Server.Models.Entities;

namespace CompanyApp.Server.Services;

public class CompanyService : ICompanyService
{
	private readonly ApplicationDbContext context;
	private readonly IMapper mapper;

	public CompanyService(ApplicationDbContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	public async Task<Company> Add(Company company)
	{
		await context.Companies.AddAsync(company);
		await context.SaveChangesAsync();
		return company;
	}

	public async Task<Company> AddWithEmployees(Company company)
	{
		context.Companies.Add(company);
		await context.SaveChangesAsync();
		return company;
	}

	public async Task<ICollection<Company>> GetAll(bool includeEmployees = true)
	{
		IQueryable<Company> query = context.Companies;

		if (includeEmployees)
			query = query.Include(x => x.Employees);

		return await query.ToListAsync();
	}

	public async Task<Company> GetCompany(int id, bool includeEmployees = false)
	{
		IQueryable<Company> query = context.Companies;

		if (includeEmployees)
			query = query.Include(x => x.Employees);

		return await query.FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<bool> Remove(int id)
	{
		var company = await GetCompany(id);
		if (company is null)
			return false;

		context.Companies.Remove(company);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Update(Company company)
	{
		var dbCompany = await GetCompany(company.Id);
		if (dbCompany is null)
			return false;

		mapper.Map(company, dbCompany);
		await context.SaveChangesAsync();

		return true;
	}

	public async Task<bool> Contains(int id)
	{
		var count = await context.Companies.CountAsync(c => c.Id == id);
		return count > 0;
	}
}

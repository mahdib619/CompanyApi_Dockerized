using AutoMapper;
using CompanyApi.Models.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Services;

public class CompanyService : ICompanyService
{
	private readonly ApplicationDbContext context;
	private readonly IMapper mapper;
	
	public CompanyService(ApplicationDbContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}
	
	public async Task Add(AddUpdateCompanyRequest request)
	{
		var company = mapper.Map<Company>(request);
		await context.Companies.AddAsync(company);
		await context.SaveChangesAsync();
	}

	public async Task<ICollection<Company>> GetAll()
	{
		return await context.Companies.AsNoTracking().ToListAsync();
	}

	public async Task<Company> GetCompany(int id)
	{
		return await context.Companies.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
	}

	public async Task<bool> Remove(int id)
	{
		var company = await context.Companies.FindAsync(id);
		
		if(company is null)
			return false;

		context.Companies.Remove(company);
		await context.SaveChangesAsync();
		return true;
	}

	public async Task<bool> Update(int companyId, AddUpdateCompanyRequest companyRequest)
	{
		var company = await context.Companies.FindAsync(companyId);

		if (company is null)
			return false;

		mapper.Map(companyRequest, company);
		await context.SaveChangesAsync();
		return true;
	}
}
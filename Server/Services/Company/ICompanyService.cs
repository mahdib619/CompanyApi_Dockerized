using CompanyApp.Server.Models.Entities;

namespace CompanyApp.Server.Services;

public interface ICompanyService
{
	Task<Company> GetCompany(int id, bool includeEmployees = true);
	Task<ICollection<Company>> GetAll(bool includeEmployees = true);
	Task<Company> Add(Company company);
	Task<Company> AddWithEmployees(Company company);
	Task<bool> Remove(int id);
	Task<bool> Update(Company company);
	Task<bool> Contains(int id);
}

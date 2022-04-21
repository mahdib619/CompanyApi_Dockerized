using CompanyApi.Models.Contracts;

namespace CompanyApi.Services;

public interface ICompanyService
{
	Task<Company> GetCompany(int id);
	Task<ICollection<Company>> GetAll();
	Task Add(AddUpdateCompanyRequest request);
	Task<bool> Remove(int id);
	Task<bool> Update(int id, AddUpdateCompanyRequest request);
}
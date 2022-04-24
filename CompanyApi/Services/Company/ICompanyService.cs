namespace CompanyApi.Services;

public interface ICompanyService
{
	Task<Company> GetCompany(int id);
	Task<ICollection<Company>> GetAll();
	Task<Company> Add(Company company);
	Task<bool> Remove(int id);
	Task<bool> Update(Company company);
}
using CompanyApp.Server.Models.Entities;

namespace CompanyApp.Server.Services;

public interface IEmployeeService
{
	Task<Employee> GetEmployee(int id, bool includeCompany = false);
	Task<ICollection<Employee>> GetAll(bool includeCompany = false);
	Task<Employee> Add(Employee employee);
	Task<bool> Remove(int id);
	Task<bool> Update(Employee employee);
}

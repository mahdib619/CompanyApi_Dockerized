using CompanyApp.Server.Models.Entities;

namespace CompanyApp.Server.Services;

public interface IEmployeeService
{
	Task<Employee> GetEmployee(int id);
	Task<ICollection<Employee>> GetAll();
	Task<Employee> Add(Employee employee);
	Task<bool> Remove(int id);
	Task<bool> Update(Employee employee);
}

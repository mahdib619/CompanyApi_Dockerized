using Dapper.Contrib.Extensions;

namespace CompanyApi.Models.Entities;

public class Company
{
	[Key]
	public int Id { get; set; }	
	public string Name { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string PostalCode { get; set; }

	[Write(false)]
	public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
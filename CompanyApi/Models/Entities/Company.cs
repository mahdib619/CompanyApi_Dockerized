namespace CompanyApi.Models.Entities;

public class Company
{
	public int Id { get; set; }	
	public string Name { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string PostalCode { get; set; }

	public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
namespace CompanyApp.Server.Models.Entities;

public class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Title { get; set; }

	public int CompanyId { get; set; }

	public Company Company { get; set; }
}

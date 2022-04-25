namespace CompanyApi.Models.Contracts;

public class AddEmployeeRequest
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Title { get; set; }
	public int CompanyId { get; set; }
}

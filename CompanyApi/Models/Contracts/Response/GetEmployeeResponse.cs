namespace CompanyApi.Models.Contracts;

public class GetEmployeeResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string Title { get; set; }

	public int CompanyId { get; set; }
	public GetCompanyResponse Company { get; set; }
}

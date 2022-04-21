namespace CompanyApi.Models.Contracts;

public class GetCompanyResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string PostalCode { get; set; }
}
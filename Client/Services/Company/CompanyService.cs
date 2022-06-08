using System.Net.Http.Json;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Services;

public class CompanyService : ICompanyService
{
	private const string ROUTE = "companies";
	private const string INCLUDE_EMPLOYEES_QUERY = "includeEmployees";
	private readonly HttpClient http;

	public CompanyService(HttpClient http)
	{
		this.http = http;
	}

	public async Task<IEnumerable<GetCompanyResponse>> GetAll(bool includeEmployees = false)
	{
		var response = await http.GetFromJsonAsync<GetAllCompaniesResponse>($"{ROUTE}?{INCLUDE_EMPLOYEES_QUERY}={includeEmployees}");
		return response.Companies;
	}

	public async Task<GetCompanyResponse> Get(int id, bool includeEmployees = false)
	{
		var response = await http.GetFromJsonAsync<GetCompanyResponse>($"{ROUTE}/{id}?{INCLUDE_EMPLOYEES_QUERY}={includeEmployees}");
		return response;
	}

	public async Task<GetCompanyResponse> Add(AddUpdateCompanyRequest req)
	{
		var response = await http.PostAsJsonAsync(ROUTE, req);

		GetCompanyResponse resBody = null;

		if (response.IsSuccessStatusCode)
			resBody = await response.Content.ReadFromJsonAsync<GetCompanyResponse>();

		return resBody;
	}

	public async Task<bool> Update(int id, AddUpdateCompanyRequest req)
	{
		var response = await http.PutAsJsonAsync($"{ROUTE}/{id}", req);
		return response.IsSuccessStatusCode;
	}

	public async Task<bool> Delete(int id)
	{
		var response = await http.DeleteAsync($"{ROUTE}/{id}");
		return response.IsSuccessStatusCode;
	}
}

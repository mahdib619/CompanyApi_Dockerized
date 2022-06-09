using System.Net.Http.Json;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Services;

public class EmployeeService : IEmployeeService
{
	private const string ROUTE = "employees";
	private const string INCLUDE_COMPANIES_QUERY = "includeCompany";
	private readonly HttpClient http;

	public EmployeeService(HttpClient http)
	{
		this.http = http;
	}

	public async Task<IEnumerable<GetEmployeeResponse>> GetAll(bool includeCompany = false)
	{
		var response = await http.GetFromJsonAsync<GetAllEmployeesResponse>($"{ROUTE}?{INCLUDE_COMPANIES_QUERY}={includeCompany}");
		return response.Employees;
	}

	public async Task<GetEmployeeResponse> Get(int id, bool includeCompany = false)
	{
		var response = await http.GetFromJsonAsync<GetEmployeeResponse>($"{ROUTE}/{id}?{INCLUDE_COMPANIES_QUERY}={includeCompany}");
		return response;
	}

	public async Task<GetEmployeeResponse> Add(AddEmployeeRequest req)
	{
		var response = await http.PostAsJsonAsync(ROUTE, req);

		GetEmployeeResponse resBody = null;

		if (response.IsSuccessStatusCode)
			resBody = await response.Content.ReadFromJsonAsync<GetEmployeeResponse>();

		return resBody;
	}

	public async Task<bool> Update(int id, UpdateEmployeeRequest req)
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

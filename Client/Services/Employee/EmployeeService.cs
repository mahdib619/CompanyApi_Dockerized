using System.Net.Http.Json;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Services;

public class EmployeeService : IEmployeeService
{
	private const string ROUTE = "employees";
	private readonly HttpClient http;

	public EmployeeService(HttpClient http)
	{
		this.http = http;
	}

	public async Task<IEnumerable<GetEmployeeResponse>> GetAll()
	{
		var response = await http.GetFromJsonAsync<GetAllEmployeesResponse>(ROUTE);
		return response.Employees;
	}

	public async Task<GetEmployeeResponse> Get(int id)
	{
		var response = await http.GetFromJsonAsync<GetEmployeeResponse>($"{ROUTE}/{id}");
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

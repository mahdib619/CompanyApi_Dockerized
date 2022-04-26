﻿using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Employee;

public class AddEmployeeEndpoint : Endpoint<AddEmployeeRequest, GetEmployeeResponse, EmployeeEndpointMapper<AddEmployeeRequest>>
{
	private readonly IEmployeeService employeeService;

	public AddEmployeeEndpoint(IEmployeeService employeeService)
	{
		this.employeeService = employeeService;
	}
	public override void Configure()
	{
		Post();
		Routes("/employees");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddEmployeeRequest req, CancellationToken ct)
	{
		try
		{
			var newEmployee = Map.FromEntity(await employeeService.Add(Map.ToEntity(req)));
			await SendCreatedAtAsync<GetEmployeeEndpoint>(new { newEmployee.Id }, newEmployee, generateAbsoluteUrl: true, cancellation: ct);
		}
		catch (ArgumentException)
		{
			AddError(e => e.CompanyId, "is invalid!");
			await SendErrorsAsync(cancellation: ct);
		}
	}
}

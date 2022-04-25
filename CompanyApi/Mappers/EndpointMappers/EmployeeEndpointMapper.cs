using AutoMapper;
using CompanyApi.Models.Contracts;

namespace CompanyApi.Mappers.EndpointMappers;

public class EmployeeEndpointMapper<TRequest> : Mapper<TRequest, GetEmployeeResponse, Employee> where TRequest : new()
{
	private readonly IMapper autoMapper;
	public EmployeeEndpointMapper()
	{
		autoMapper = RegisterServices.ServiceProvider.GetService<IMapper>();
	}

	public override GetEmployeeResponse FromEntity(Employee e)
	{
		return autoMapper.Map<GetEmployeeResponse>(e);
	}

	public override Employee ToEntity(TRequest r)
	{
		return autoMapper.Map<Employee>(r);
	}
}

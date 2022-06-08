using AutoMapper;
using CompanyApp.Server.Models.Entities;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Server.Mappers.Profiles;

public class EmployeeMapProfile : Profile
{
	public EmployeeMapProfile()
	{
		CreateMap<AddEmployeeRequest, Employee>();
		CreateMap<UpdateEmployeeRequest, Employee>();
		CreateMap<Employee, GetEmployeeResponse>();

		CreateMap<Employee, Employee>()
			.ForMember(a => a.CompanyId, (conf) => conf.Condition(es => es.CompanyId != 0));
	}
}

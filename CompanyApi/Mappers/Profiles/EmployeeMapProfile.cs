using AutoMapper;
using CompanyApi.Models.Contracts;

namespace CompanyApi.Mappers.Profiles;

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

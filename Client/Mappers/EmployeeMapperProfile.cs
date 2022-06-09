using AutoMapper;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Mappers;

public class EmployeeMapperProfile : Profile
{
	public EmployeeMapperProfile()
	{
		CreateMap<GetEmployeeResponse, UpdateEmployeeRequest>();
		CreateMap<GetEmployeeResponse, GetEmployeeResponse>();
	}
}

using AutoMapper;
using CompanyApp.Server.Models.Entities;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Server.Mappers.Profiles;

public class CompanyMapProfile : Profile
{
	public CompanyMapProfile()
	{
		CreateMap<AddUpdateCompanyRequest, Company>();
		CreateMap<Company, GetCompanyResponse>();
		CreateMap<Company, Company>();
	}
}

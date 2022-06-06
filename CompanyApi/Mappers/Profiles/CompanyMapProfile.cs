using AutoMapper;
using CompanyApi.Models.Contracts;

namespace CompanyApi.Mappers.Profiles;

public class CompanyMapProfile : Profile
{
	public CompanyMapProfile()
	{
		CreateMap<AddUpdateCompanyRequest, Company>();
		CreateMap<Company, GetCompanyResponse>();
		CreateMap<Company, Company>();
	}
}
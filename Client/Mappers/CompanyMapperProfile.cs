using AutoMapper;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Mappers;

public class CompanyMapperProfile : Profile
{
	public CompanyMapperProfile()
	{
		CreateMap<GetCompanyResponse, AddUpdateCompanyRequest>();
	}
}

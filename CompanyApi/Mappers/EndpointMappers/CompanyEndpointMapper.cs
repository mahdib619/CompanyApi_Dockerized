using AutoMapper;
using CompanyApi.Models.Contracts;

namespace CompanyApi.Mappers.EndpointMappers;

public class CompanyEndpointMapper : Mapper<AddUpdateCompanyRequest, GetCompanyResponse, Company>
{
    private readonly IMapper autoMapper;
	public CompanyEndpointMapper()
	{
		autoMapper = RegisterServices.ServiceProvider.GetService<IMapper>();
	}
	public override GetCompanyResponse FromEntity(Company company)
	{
		return autoMapper.Map<GetCompanyResponse>(company);
	}
	public override Company ToEntity(AddUpdateCompanyRequest request)
	{
		return autoMapper.Map<Company>(request);
	}
}
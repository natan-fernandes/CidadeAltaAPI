using AutoMapper;

namespace CidadeAlta.Application.Application;

public class BaseAppService
{
    public readonly IMapper Mapper;
    public BaseAppService(IMapper mapper)
    {
        Mapper = mapper;
    }
}
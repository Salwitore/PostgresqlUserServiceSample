using AutoMapper;

namespace Business.MapperProfiles
{
    public class AutoProfile<T,Th> : Profile where T : class where Th : class
    {
        public AutoProfile()
        {
            CreateMap<T,Th>();
            CreateMap<Th, T>();

        }
    }
}

using AutoMapper;
using TolkienApi.Models;

namespace TolkienApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CharacterNew, Character>();
            // CreateMap<CharacterUpdate, Character>()
            //     .ForAllMembers(x => x.Condition(
            //         (src, dest, prop) =>
            //         {
            //             // ignore empty fields
            //             if (prop == null) return false;
            //             if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

            //             return true;
            //         }
            //     ));
        }
    }
}
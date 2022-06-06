using AutoMapper;
using MoviesAPI.Data.Dtos.Manager;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class ManagerProfile : Profile
    {

        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>();
        }
    }
}

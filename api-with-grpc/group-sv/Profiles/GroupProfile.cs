using AutoMapper;
using group_sv.Models;

namespace group_sv.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GrpcGroupModel>()
                .ReverseMap();
        }
    }
}
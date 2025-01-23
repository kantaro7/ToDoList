namespace ToDoList.Api.AutoMapper;

using global::AutoMapper;
using ToDoList.Api.DTOs;
using Models;
using SQLEntities;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TaskDTO, Task>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<TaskEntity, Task>().ReverseMap();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}


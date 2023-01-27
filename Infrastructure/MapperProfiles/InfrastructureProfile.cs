using AutoMapper;
using Domain.Entities;
using Domain.Dto;
namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
   public InfrastructureProfile()
   {
     CreateMap<Category, GetCategoryDto>().ReverseMap();
        CreateMap<AddCategoryDto, Category>().ReverseMap();

     CreateMap<Comment, GetCommentDto>().ReverseMap();
        CreateMap<AddCommentDto, Comment>().ReverseMap();

     CreateMap<ToDo, GetToDoDto>().ReverseMap();
        CreateMap<AddTodoDto, ToDo>().ReverseMap();

     CreateMap<User, UserLoginDto>().ReverseMap();
        CreateMap<UserRegisterDto, User>().ReverseMap();
   }
}

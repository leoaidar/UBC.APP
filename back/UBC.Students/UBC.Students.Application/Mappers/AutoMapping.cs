using AutoMapper;
using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Queries;

namespace UBC.Students.Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<StudentViewModel, Student>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<LoginUserViewModel, UserViewModel>();
            CreateMap<UserViewModel, LoginUserViewModel>();
            CreateMap<LoginUserViewModel, UserGetByLoginQuery>();
            CreateMap<UserGetByLoginQuery, LoginUserViewModel>();
            CreateMap<CreateStudentViewModel, CreateStudentCommand>();
            CreateMap<CreateStudentCommand, CreateStudentViewModel>();
            CreateMap<CreateStudentViewModel, UpdateStudentCommand>();
            CreateMap<UpdateStudentCommand, CreateStudentViewModel>();
            CreateMap<Student, CreateStudentCommand>();
            CreateMap<CreateStudentCommand, Student>();
            CreateMap<Student, UpdateStudentCommand>();
            CreateMap<UpdateStudentCommand, Student>();
            CreateMap<Student, Student>();
        }
    }
}

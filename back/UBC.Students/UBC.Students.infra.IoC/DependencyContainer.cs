using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UBC.Students.Application.Interfaces;
using UBC.Students.Application.Services;
using UBC.Students.Domain.Commands;
using UBC.Students.Domain.Commands.Contracts;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Handlers;
using UBC.Students.Domain.Queries;
using UBC.Students.Domain.Queries.Contracts;
using UBC.Students.Domain.Repositories;
using UBC.Students.Infra.Data.Repositories;
using UBC.Users.Application.Interfaces;
using UBC.Users.Application.Services;
using UBC.Users.Infra.Data.Repositories;

namespace UBC.Students.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Mappers            
            services.AddSingleton<IMapper, Mapper>();

            //Services
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IUserService, UserService>();

            //Repositories
            services.AddTransient<IRepository<Student>, StudentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            //Handlers
            services.AddTransient<IRequestHandler<StudentGetAllQuery, IQueryResult>, StudentQueryHandler>();
            services.AddTransient<IRequestHandler<StudentGetQuery, IQueryResult>, StudentQueryHandler>();
            services.AddTransient<IRequestHandler<UserGetByLoginQuery, IQueryResult>, UserQueryHandler>();
            services.AddTransient<IRequestHandler<CreateStudentCommand, ICommandResult>, StudentCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteStudentCommand, ICommandResult>, StudentCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateStudentCommand, ICommandResult>, StudentCommandHandler>();
        }
    }
}

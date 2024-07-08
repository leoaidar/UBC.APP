using AutoMapper;
using MediatR;
using UBC.Students.Application.ViewModels;
using UBC.Students.Domain.Entities;
using UBC.Students.Domain.Queries;
using UBC.Users.Application.Interfaces;

namespace UBC.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetByLogin(LoginUserViewModel request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<UserGetByLoginQuery>(request);

            var handler = (QueryResult<User>) await _mediator.Send(query, cancellationToken);

            var collection = _mapper.Map<UserViewModel>(handler.Entity);

            return collection;
        }
    }

}

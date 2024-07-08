using UBC.Students.Domain.Commands.Contracts;

namespace UBC.Students.Domain.Handlers.Contracts
{
    public interface IHandlerCommand<C> : IHandler<C,ICommandResult>  
                        where C : ICommand  
    {
        ICommandResult Handle(C command);
    }
}
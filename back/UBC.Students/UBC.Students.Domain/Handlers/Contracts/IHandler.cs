namespace UBC.Students.Domain.Handlers.Contracts
{
    public interface IHandler<T,R>
    {
        R Handle(T args);
    }
}
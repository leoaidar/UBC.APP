using UBC.Students.Domain.Commands.Contracts;
using System;
using System.Threading.Tasks;

namespace UBC.Students.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public static explicit operator CommandResult(Task<ICommandResult> v)
        {
            throw new NotImplementedException();
        }
    }
}
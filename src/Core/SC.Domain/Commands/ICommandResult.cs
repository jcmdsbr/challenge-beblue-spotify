using System;

namespace SC.Domain.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}
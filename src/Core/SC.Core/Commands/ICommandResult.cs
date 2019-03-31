using System;

namespace SC.Core.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}
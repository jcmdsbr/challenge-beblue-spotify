using System;

namespace SC.Domain.Models
{
    public interface IEntity<out T> : IEntity where T : struct
    {
        T Id { get; }
    }

    public interface IEntity { }
}

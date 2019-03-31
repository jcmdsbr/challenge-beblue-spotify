namespace SC.Core.Models
{
    public interface IEntity<out T> : IEntity where T : struct
    {
        T Id { get; }
    }

    public interface IEntity
    {
    }
}
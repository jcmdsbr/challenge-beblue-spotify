namespace SC.Domain.Models
{
    public class Category : IEntity<int>
    {
        protected Category()
        {
        }

        public Category(int id, string description)
        {
            Id = id;
            Description = description;
        }

        public string Description { get; }
        public int Id { get; }
    }
}
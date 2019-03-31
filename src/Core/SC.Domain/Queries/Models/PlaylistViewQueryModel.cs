using System;
using SC.Core.Queries;
using SC.Domain.Entities;

namespace SC.Domain.Queries.Models
{
    public class PlaylistViewQueryModel : IQueryModel
    {
        public PlaylistViewQueryModel(Guid id, decimal price, string name, int categoryId, string categoryName)
        {
            Id = id;
            Price = price;
            Name = name;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public Guid Id { get;  set; }
        public decimal Price { get;  set; }
        public string Name { get;  set; }
        public int CategoryId { get; set; }
        public string CategoryName { get;  set; }
    
    }
}
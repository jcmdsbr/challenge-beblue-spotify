using System;
using System.Collections.Generic;
using SC.Core.Models;
using SC.Domain.ValueObjects;

namespace SC.Domain.Entities
{
    public class Playlist : IEntity
    {
        protected Playlist()
        {
        }

        private Playlist(Guid id, int categoryId, decimal price, string name)
        {
            Id = id;
            CategoryId = categoryId;
            Price = price;
            Name = name;
        }

        public Guid Id { get; private set; }
        public int CategoryId { get; private set; }
        public Amount Price { get; private set; }
        public Name Name { get; private set; }
        public Category Category { get; private set; }
        public List<SaleDetail> SaleDetails { get; private set; }

        public static Playlist CreateNewPlaylist(int categoryId, string name)
        {
            return new Playlist
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = name,
                Price = CreateRandomPrice()
            };
        }

        private static decimal CreateRandomPrice()
        {
            var random = new Random();

            return random.Next(100);
        }
    }
}
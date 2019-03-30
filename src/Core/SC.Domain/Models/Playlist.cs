using System;
using System.Collections.Generic;
using SC.Domain.ValueObjects;

namespace SC.Domain.Models {
    public class Playlist : IEntity {

        public Guid Id { get; private set; }
        public int CategoryId { get; private set; }
        public Amount Price { get; private set; }
        public Name Name { get; private set; }
        public Category Category { get; private set; }
        public List<SaleDetail> SaleDetails { get; private set; }
        protected Playlist () {

        }
        private Playlist (Guid id, int categoryId, decimal price, string name) {
            this.Id = id;
            this.CategoryId = categoryId;
            this.Price = price;
            this.Name = name;

        }

        public static Playlist CreateNewPlaylist (int categoryId, string name) => new Playlist {
            Id = Guid.NewGuid (),
            CategoryId = categoryId,
            Name = name,
            Price = CreateRandomPrice ()
        };

        private static decimal CreateRandomPrice () {
            var random = new Random ();

            return random.Next (100);
        }

    }
}
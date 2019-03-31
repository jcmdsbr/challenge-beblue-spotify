using System;
using SC.Core.Models;
using SC.Domain.ValueObjects;

namespace SC.Domain.Models
{
    public class SaleDetail : IEntity
    {
        protected SaleDetail()
        {

        }

        public SaleDetail(Guid saleId, Guid playlistId, Amount cashback)
        {
            SaleId = saleId;
            PlaylistId = playlistId;
            Cashback = cashback;
        }

        public Guid SaleId { get; private set; }
        public Guid PlaylistId { get; private set; }
        public Amount Cashback { get; private set; }
        public Playlist Playlist { get; private set; }
        public Sale Sale { get; private set; }
    }
}
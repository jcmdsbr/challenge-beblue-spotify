using System;
using SC.Core.Entities;
using SC.Domain.Fixed;
using SC.Domain.Services;
using SC.Domain.ValueObjects;

namespace SC.Domain.Entities
{
    public class SaleDetail : IEntity
    {
        protected SaleDetail()
        {

        }
        public Guid SaleId { get; private set; }
        public Guid PlaylistId { get; private set; }
        public Amount Cashback { get; private set; }
        public Playlist Playlist { get; private set; }
        public Sale Sale { get; private set; }

        public static SaleDetail CreateByPlaylist(Playlist playlist)
        {
            var cashback = CalculateCashback(playlist.Price, (EnmCategory) playlist.CategoryId);

            return new SaleDetail
            {
                PlaylistId = playlist.Id,
                Cashback = cashback,
                Playlist = playlist
            };

        }

        private static decimal CalculateCashback(Amount price, EnmCategory categoryId)
        {
            switch (categoryId)
            {
                case EnmCategory.POP: return new PopCategoryCashbackService().CalculateAmountCashback(price);
                case EnmCategory.MPB: return new MpbCategoryCashbackService().CalculateAmountCashback(price);
                case EnmCategory.CLASSIC: return new ClassicCategoryCashbackService().CalculateAmountCashback(price);
                case EnmCategory.ROCK: return new RockCategoryCashbackService().CalculateAmountCashback(price);
                default: return default;
            }

        }

    }
}
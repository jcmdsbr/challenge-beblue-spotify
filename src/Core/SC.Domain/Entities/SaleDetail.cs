using System;
using SC.Core.Models;
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

        public static SaleDetail Create(Guid playlistId, Amount price, int categoryId)
        {
            var cashback = CalculateCashback(price, (EnmCategory) categoryId);

            return new SaleDetail
            {
                PlaylistId = playlistId,
                Cashback = cashback
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
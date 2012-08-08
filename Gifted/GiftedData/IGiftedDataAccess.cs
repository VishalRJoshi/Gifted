using System;
namespace GiftedData
{
    interface IGiftedDataAccess
    {
        GiftedEntities.Gift AddNewGift(GiftedEntities.Gift gift);
        void Connect(string connectionString);
        bool DeleteGift(Guid id);
        void Disconnect();
        System.Collections.Generic.IEnumerable<GiftedEntities.Gift> GetAllGifts();
        GiftedEntities.Gift GetGift(Guid id);
        System.Collections.Generic.List<GiftedEntities.Gift> GetGiftList(string userId);
        bool UpdateGift(Guid id, GiftedEntities.Gift gift);
    }
}

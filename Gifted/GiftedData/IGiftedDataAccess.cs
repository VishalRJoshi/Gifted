using System;
namespace Gifted.Data
{
    public  interface IGiftedDataAccess
    {
        Gifted.Entities.Gift AddNewGift(Gifted.Entities.Gift gift);
        void Connect(string connectionString);
        bool DeleteGift(Guid id);
        void Disconnect();
        System.Collections.Generic.IEnumerable<Gifted.Entities.Gift> GetAllGifts();
        Gifted.Entities.Gift GetGift(Guid id);
        System.Collections.Generic.List<Gifted.Entities.Gift> GetGiftList(string userId);
        bool UpdateGift(Guid id, Gifted.Entities.Gift gift);
    }
}

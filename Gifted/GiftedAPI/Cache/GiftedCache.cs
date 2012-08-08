using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gifted.Data;

namespace Gifted.API.Cache
{
    public class GiftedCache : IGiftedDataAccess
    {
        Entities.Gift IGiftedDataAccess.AddNewGift(Entities.Gift gift)
        {
            throw new NotImplementedException();
        }

        void IGiftedDataAccess.Connect(string connectionString)
        {
            throw new NotImplementedException();
        }

        bool IGiftedDataAccess.DeleteGift(Guid id)
        {
            throw new NotImplementedException();
        }

        void IGiftedDataAccess.Disconnect()
        {
            throw new NotImplementedException();
        }

        IEnumerable<Entities.Gift> IGiftedDataAccess.GetAllGifts()
        {
            throw new NotImplementedException();
        }

        Entities.Gift IGiftedDataAccess.GetGift(Guid id)
        {
            throw new NotImplementedException();
        }

        List<Entities.Gift> IGiftedDataAccess.GetGiftList(string userId)
        {
            throw new NotImplementedException();
        }

        bool IGiftedDataAccess.UpdateGift(Guid id, Entities.Gift gift)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Gifted.Entities;
using MongoDB.Driver.Builders;


namespace Gifted.Data.MongoDB
{
    public class MongoDataAccess :IGiftedDataAccess 
    {
        #region MongoConnections
        MongoServer mongoServer;
        MongoDatabase giftedDB;
        MongoCollection giftCollection;
        Process mongoD = new Process();

        /// <summary>
        /// Use Mongolab.com 
        /// mongodb://gifted:gifted@ds035787.mongolab.com:35787/gifted
        /// </summary>
        /// <param name="connectionString"></param>
        public void Connect(string connectionString)
        {
            mongoD.StartInfo.FileName = "C:\\MongoDB\\bin\\Mongod.exe";
            mongoD.StartInfo.Arguments = "--logpath='C:\\MongoDB\\Log\\Mongo.log' --dbpath 'C:\\MongoDB\\Data\\DB";
            mongoD.Start();
            if (String.IsNullOrEmpty(connectionString))
                connectionString = "mongodb://localhost";
            mongoServer = MongoServer.Create(connectionString);
            giftedDB = mongoServer.GetDatabase("Gifted");
        }

        /// <summary>
        /// Brutal Brutal, fix me...
        public void Disconnect()
        {
            mongoServer.Shutdown();
            mongoD.Kill();
        }
        #endregion

        public Gift AddNewGift(Gifted.Entities.Gift gift)
        {
            if (mongoServer != null && giftedDB != null)
            {
                giftCollection = giftedDB.GetCollection<Gift>("Gift");
                gift.Id = Guid.NewGuid();
                gift.ModifiedDate = DateTime.UtcNow;
                gift.CreateDate = DateTime.UtcNow;
                giftCollection.Insert(gift);
                return gift;
            }
            else
                return null;
        }

        public bool DeleteGift(Guid id)
        {
            if (mongoServer != null && giftedDB != null)
            {
                giftCollection = giftedDB.GetCollection<Gift>("Gift");
                IMongoQuery query = Query.EQ("_id", id);
                SafeModeResult result = giftCollection.Remove(query);
                return result.DocumentsAffected == 1;
            }
            else
                return false;
        }

        public IEnumerable<Gift> GetAllGifts()
        {
            return giftCollection.FindAllAs<Gift>();
        }

        public bool UpdateGift(Guid id, Gifted.Entities.Gift gift)
        {
            if (mongoServer != null && giftedDB != null)
            {
                IMongoQuery query = Query.EQ("_id", id);
                gift.ModifiedDate = DateTime.UtcNow;
                IMongoUpdate update = Update
                    .Set("Name", gift.Name)
                    .Set("Cost", gift.Cost)
                    .Set("Rank", gift.Rank)
                    .Set("ModifiedDate", gift.ModifiedDate);
                SafeModeResult result = giftCollection.Update(query, update);
                return result.UpdatedExisting;
            }
            else
                return false;
        }

        public Gifted.Entities.Gift GetGift(Guid id)
        {
            IMongoQuery query = Query.EQ("_id", id);
            return giftCollection.FindAs<Gift>(query).FirstOrDefault();
        }

        public List<Gifted.Entities.Gift> GetGiftList(string userId)
        {
            IMongoQuery query = Query.EQ("UserId", userId);
            return giftCollection.FindAs<Gift>(query).ToList();
        }
    }
}

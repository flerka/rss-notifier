using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.DataAccess
{
    public class RssFeed
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string RssUrl { get; set; }
        
        [BsonIgnoreIfNull]
        public List<User> Users { get; set; }
    }
}

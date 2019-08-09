using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.DataAccess
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string UserId { get; set; }
    }
}

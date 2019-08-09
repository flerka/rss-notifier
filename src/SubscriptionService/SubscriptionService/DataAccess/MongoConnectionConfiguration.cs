using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionService.DataAccess
{
    public class MongoConnectionConfiguration
    {
        /// <summary>
        /// The connection string to the database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// DB name where data is stored
        /// </summary>
        public string DatabaseName { get; set; }
    }
}

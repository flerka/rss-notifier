using MediatR;
using System.Threading.Tasks;
using SubscriptionService.Api.Commands;
using SubscriptionService.DataAccess;
using System.Threading;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SubscriptionService.Commands
{
    public class CreateUserRssHandler : IRequestHandler<CreateUserRssCommand, CreateUserRssResult>
    {
        private readonly IMongoCollection<RssFeed> _db;

        public CreateUserRssHandler(IMongoCollection<RssFeed> db) => _db = db;

        public async Task<CreateUserRssResult> Handle(CreateUserRssCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<RssFeed>.Filter.Eq(x => x.RssUrl, request.Url);
            var rssFeed =
                await (await _db.FindAsync(filter, new FindOptions<RssFeed> { Limit = 1 }, cancellationToken)).FirstOrDefaultAsync(cancellationToken);
            if (rssFeed == null)
            {
                rssFeed = new RssFeed { RssUrl = request.Url };
                await _db.InsertOneAsync(rssFeed, cancellationToken: cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
            }

            var user = new User
            {
                Id = ObjectId.GenerateNewId(),
                UserId = request.UserId
            };

            var update = Builders<RssFeed>.Update.Push(x => x.Users, user);
            await _db.UpdateOneAsync(filter, update);

            return new CreateUserRssResult { RssFeedId = rssFeed.Id.ToString() };
        }
    }
}

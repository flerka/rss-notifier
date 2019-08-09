using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionService.Api.Commands
{
    // TODO add validation here
    public class CreateUserRssCommand : IRequest<CreateUserRssResult>
    {
        public string UserId { get; set; }

        public string Url { get; set; }
    }
}

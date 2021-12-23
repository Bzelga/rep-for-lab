using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;


namespace SevenLab
{
    public class Subscription
    {
        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Games>> OnGamesCreate([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Games>("GameCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Genre>> OnGenreCreate([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Genre>("GenreCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Developers>> OnDevCreate([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Developers>("DeveloperCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Games>> OnGamesChange([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Games>("ChangeGame", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Genre>> OnGenreChange([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Genre>("ChangeGenre", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Developers>> OnDevChange([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Developers>("ChangeDev", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Games>> OnGamesDel([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Games>("DeleteGenre", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Genre>> OnGenreDel([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Genre>("GenreCreated", cancellationToken);
        }

        [SubscribeAndResolve]
        public async ValueTask<ISourceStream<Developers>> OnDevDel([Service] ITopicEventReceiver eventReceiver,
               CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<string, Developers>("DeleteDev", cancellationToken);
        }
    }
}

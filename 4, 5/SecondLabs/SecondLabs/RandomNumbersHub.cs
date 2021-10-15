using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace SecondLabs
{
    public class RandomNumbersHub : Hub
    {
        private readonly Random rand = new Random();
        private readonly ILogger<RandomNumbersHub> _logger;

        public RandomNumbersHub(ILogger<RandomNumbersHub> logger)
        {
            _logger = logger;
        }

        public async Task Send(IAsyncEnumerable<int> stream)
        {
            List<int> ResultingNumbers = new List<int>();

            await foreach (var item in stream)
            {
                _logger.LogInformation($"client sent {item}");
                ResultingNumbers.Add(item);
            }

            await Clients.All.SendAsync("Receive", ResultingNumbers);
        }

        public async IAsyncEnumerable<int> ReceiveHub(
            List<int> resultingNumbers,
            int delay,
            [EnumeratorCancellation]
            CancellationToken cancellationToken)
        {
            for (var i = 0; i < resultingNumbers.Count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return resultingNumbers[i]+5;

                await Task.Delay(delay, cancellationToken);
            }
        }
    }
}

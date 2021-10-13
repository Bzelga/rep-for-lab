using Microsoft.AspNetCore.SignalR;
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

        public async Task Send(IAsyncEnumerable<ParametersRandCount> stream)
        {
            ParametersRandCount parametersRandCount = null;
            await foreach (var item in stream)
            {
                parametersRandCount = item;
            }

            await Clients.All.SendAsync("Receive", parametersRandCount);
        }

        public async IAsyncEnumerable<int> ReceiveHub(
            ParametersRandCount parametersRandCount,
            int delay,
            [EnumeratorCancellation]
            CancellationToken cancellationToken)
        {
            for (var i = 0; i < parametersRandCount.Quantity; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                yield return rand.Next(parametersRandCount.FromNumber, parametersRandCount.ToNumber);

                await Task.Delay(delay, cancellationToken);
            }
        }
    }
}

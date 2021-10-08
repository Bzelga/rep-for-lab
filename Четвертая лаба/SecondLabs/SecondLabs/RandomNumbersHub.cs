using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SecondLabs
{
    public class RandomNumbersHub : Hub
    {
        private readonly Random rand = new Random();

        public async Task Send(ParametersRandCount parametersRandCout)
        {
            int[] randArray = new int[parametersRandCout.Quantity];

            for(int i = 0; i < parametersRandCout.Quantity; i++)
            {
                randArray[i] = rand.Next(parametersRandCout.FromNumber, parametersRandCout.ToNumber);
            }

            await Clients.All.SendAsync("Receive", randArray);
        }
    }
}

using Circles.Contracts.Hub;
using Nethereum.Web3;

namespace Circles.Contracts.Tests
{
    public class HubTests
    {
        /*
         v1HubAddress: "0x29b9a7fBb8995b2423a71cC17cf9810798F6C543",
         v2HubAddress: "0xFFfbD3E62203B888bb8E09c1fcAcE58242674964",
        */

        string v2HubAddress = "0xFFfbD3E62203B888bb8E09c1fcAcE58242674964";

        [Fact]
        public void ShouldDoSomething()
        {
            var web3 = new Web3("https://rpc.gnosis.gateway.fm");
            var hubService = new HubService(web3, v2HubAddress);
            hubService.RegisterHumanRequestAsync

        }
    }
}

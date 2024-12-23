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
        string humanAddress1 = "0xed1067bc2a09dd6a146eccd3577f27eb5be93646";

        [Fact]
        public async Task ShouldCalculateIssuance()
        {
            //var web3 = new Web3("https://rpc.gnosis.gateway.fm");
            var web3 = new Web3("https://rpc.aboutcircles.com/");
            var hubService = new HubService(web3, v2HubAddress);
            var issuance = await hubService.CalculateIssuanceQueryAsync("0xed1067bc2a09dd6a146eccd3577f27eb5be93646");
            

        }
    }



}

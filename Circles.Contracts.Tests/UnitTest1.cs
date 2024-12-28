using Circles.Contracts.Hub;
using Circles.Contracts.Hub.ContractDefinition;
using Nethereum.GnosisSafe;
using Nethereum.GnosisSafe.ContractDefinition;
using Nethereum.Model;
using Nethereum.Web3;
using System.Net.Mail;

namespace Circles.Contracts.Tests
{
    public class HubTests
    {
        /*
         v1HubAddress: "0x29b9a7fBb8995b2423a71cC17cf9810798F6C543",
         v2HubAddress: "0xFFfbD3E62203B888bb8E09c1fcAcE58242674964",
        */

        string v2HubAddress = "0xc12C1E50ABB450d6205Ea2C3Fa861b3B834d13e8";
        string humanAddress1 = "0xed1067bc2a09dd6a146eccd3577f27eb5be93646";
        int chainId = 100;

        [Fact]
        public async Task ShouldCalculateIssuance()
        {
            var web3 = new Web3("https://rpc.aboutcircles.com/");
            var hubService = new HubService(web3, v2HubAddress);
            var issuance = await hubService.CalculateIssuanceQueryAsync("0xed1067bc2a09dd6a146eccd3577f27eb5be93646");

        }

        [Fact]
        public async Task ShouldPersonalMint()
        {
            var privateKey = "";
            var web3 = new Web3(new Nethereum.Web3.Accounts.Account(privateKey), "https://rpc.aboutcircles.com/");
            var safe = new GnosisSafeService(web3, humanAddress1);
            var personalMintFunction = new PersonalMintFunction();

            var execTransactionFunction = await safe.BuildTransactionAsync(
                new EncodeTransactionDataFunction() { To = v2HubAddress }, personalMintFunction, (int)chainId, false,
                privateKey);

            await safe.ExecTransactionRequestAndWaitForReceiptAsync(execTransactionFunction);
        }
    }



}

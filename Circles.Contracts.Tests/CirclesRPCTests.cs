using Circles.Contracts.Hub;
using Circles.RPC.Requests;
using Circles.RPC.Requests.DTO;
using Circles.RPC.Requests.DTOs;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circles.Contracts.Tests
{
    public class CirclesRPCTests
    {

        
        string humanAddress1 = "0xed1067bc2a09dd6a146eccd3577f27eb5be93646";
        string humanAddress2 = "0x42cEDde51198D1773590311E2A340DC06B24cB37";

        [Fact]
        public async Task ShouldGetBalances()
        {
            
            var client = new RpcClient(new Uri("https://rpc.aboutcircles.com/"));

            // GetTotalBalance
            var getTotalBalance = new GetTotalBalance(client);
            string balance = await getTotalBalance.SendRequestAsync(humanAddress1);
            Debug.WriteLine($"Total Balance: {balance}");

            // GetTotalBalanceV2
            var getTotalBalanceV2 = new GetTotalBalanceV2(client);
            string balanceV2 = await getTotalBalanceV2.SendRequestAsync(humanAddress1);
            Debug.WriteLine($"Total Balance (V2): {balanceV2}");
        }

        [Fact]
        public async Task ShouldGetTransactionHistoryAsync()
        {
            var avatar = "0xc5d6c75087780e0c18820883cf5a580bb3a4d834";
            var client = new RpcClient(new Uri("https://chiado-rpc.aboutcircles.com"));
            var circlesQuery = new CirclesQuery<TransactionHistoryRow>(client);

            var queryDefinition = new QueryDefinition
            {
                Namespace = "V_Crc",
                Table = "Transfers",
              
                Limit = 10,
                Columns = new List<string>
                {
                    "blockNumber", "timestamp", "transactionIndex", "logIndex",
                    "batchIndex", "transactionHash", "version", "operator",
                    "from", "to", "id", "value", "type", "tokenType"
                },
                Filter = new List<Filter>()
                {
                     new Conjunction
                    {
                            ConjunctionType = "Or",
                            Predicates = new List<Filter>
                            {
                                new FilterPredicate
                                {
                                    FilterType = "Equals",
                                    Column = "from",
                                    Value = avatar.ToLower()
                                },
                                new FilterPredicate
                                {
                                    FilterType = "Equals",
                                    Column = "to",
                                    Value = avatar.ToLower()
                                }
                            }
                     }
                },
                Order = new List<Order>
                {
                    new Order { Column = "blockNumber", SortOrder = "DESC" },
                    new Order { Column = "transactionIndex", SortOrder = "DESC" },
                    new Order { Column = "logIndex", SortOrder = "DESC" }
                },
            };

            var transactionHistoryQuery = new TransactionHistoryQuery(client);
            var allTransactions = await transactionHistoryQuery.SendRequestAsync(queryDefinition);

            foreach (var transaction in allTransactions.Rows)
            {
                Debug.WriteLine($"Transaction Hash: {transaction.TransactionHash}, Value: {transaction.Value}");
            }
        }
    }
}

using Circles.RPC.Requests;
using Circles.RPC.Requests.DTO;
using Circles.RPC.Requests.DTOs;
using Nethereum.JsonRpc.Client;

namespace Circles.RPC.Requests
{
    public class TransactionHistoryQuery
    {
        private readonly CirclesQuery<CirclesQueryPage> _circlesQuery;

        public TransactionHistoryQuery(IClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            _circlesQuery = new CirclesQuery<CirclesQueryPage>(client);
        }

        /// <summary>
        /// Sends a transaction history query and maps the response.
        /// </summary>
        /// <param name="queryDefinition">The query definition object.</param>
        /// <param name="id">Optional request identifier.</param>
        /// <returns>A paginated result containing transaction history rows.</returns>
        public async Task<Page<TransactionHistoryRow>> SendRequestAsync(QueryDefinition queryDefinition, object id = null)
        {
            if (queryDefinition == null)
                throw new ArgumentNullException(nameof(queryDefinition));

            // Fetch raw data using CirclesQuery
            var rawResponse = await _circlesQuery.SendRequestAsync(queryDefinition, id);

            // Map rows to TransactionHistoryRow
            var rows = rawResponse.Rows.Select(row => MapRowToTransactionHistory(rawResponse.Columns, row)).ToList();
           
            //TODO add cursor filtering and response to page results
            return new Page<TransactionHistoryRow>
            {
                Rows = rows,
                PageSize = queryDefinition.Limit,
                //TotalRows = rows.Count // Optional: replace with actual total rows if available from the API
            };
        }

        /// <summary>
        /// Maps a single row to a TransactionHistoryRow using the columns.
        /// </summary>
        /// <param name="columns">The column names from the response.</param>
        /// <param name="row">The row data.</param>
        /// <returns>A mapped TransactionHistoryRow object.</returns>
        private TransactionHistoryRow MapRowToTransactionHistory(List<string> columns, string[] row)
        {
            var transaction = new TransactionHistoryRow();

            for (int i = 0; i < columns.Count; i++)
            {
                var column = columns[i];
                var value = row[i];

                switch (column)
                {
                    case "blockNumber":
                        transaction.BlockNumber = Convert.ToInt64(value);
                        break;
                    case "timestamp":
                        transaction.Timestamp = Convert.ToInt64(value);
                        break;
                    case "transactionIndex":
                        transaction.TransactionIndex = Convert.ToInt32(value);
                        break;
                    case "logIndex":
                        transaction.LogIndex = Convert.ToInt32(value);
                        break;
                    case "batchIndex":
                        transaction.BatchIndex = Convert.ToInt32(value);
                        break;
                    case "transactionHash":
                        transaction.TransactionHash = value?.ToString();
                        break;
                    case "version":
                        transaction.Version = Convert.ToInt32(value);
                        break;
                    case "operator":
                        transaction.Operator = value?.ToString();
                        break;
                    case "from":
                        transaction.From = value?.ToString();
                        break;
                    case "to":
                        transaction.To = value?.ToString();
                        break;
                    case "id":
                        transaction.Id = value?.ToString();
                        break;
                    case "value":
                        transaction.Value = value?.ToString();
                        break;
                    case "type":
                        transaction.Type = value?.ToString();
                        break;
                    case "tokenType":
                        transaction.TokenType = value?.ToString();
                        break;
                }
            }

            return transaction;
        }
    }
}

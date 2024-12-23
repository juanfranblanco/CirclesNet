using System;
using System.Threading.Tasks;
using Circles.RPC.Requests.DTOs;
using Nethereum.JsonRpc.Client;

namespace Circles.RPC.Requests
{
    /// <summary>
    /// Executes the Circles `circles_query` RPC method.
    /// </summary>
    public class CirclesQuery<T> : RpcRequestResponseHandler<CirclesQueryPage>
    {
        public CirclesQuery(IClient client) : base(client, "circles_query") { }

        /// <summary>
        /// Sends a paginated query request to Circles.
        /// </summary>
        /// <param name="queryDefinition">The query definition object.</param>
        /// <param name="id">Optional request identifier.</param>
        /// <returns>A paginated query response.</returns>
        public Task<CirclesQueryPage> SendRequestAsync(QueryDefinition queryDefinition, object id = null)
        {
            if (queryDefinition == null)
                throw new ArgumentNullException(nameof(queryDefinition));

            return base.SendRequestAsync(id, queryDefinition);
        }
    }
}

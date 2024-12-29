# Circles .Net SDK / API
.Net SDK / API for https://aboutcircles.com/
WIP (Just for info.. continuous changes, working on core components)

# Progress / TODO
### Circles.RPC
   **Done**
   * Support for RPC methods extending Nethereum RPC interfaces
   * Generic CirclesQuery Request allowing to create QueryDefinitions, Filters, Pagination and mapping to Objects
   * GetTransactionHistoryQuery (Query)
   * GetTrustRelationsQuery (Query)
   * GetAvatarInfoQuery (Query)
   * GetTotalBalance V1 and V2
   **Todo**
   * Common RPC object like Nethereum Web3
   * Generic business logic not implmented in the RPC, like Calculate balances, mappings etc
   * Other queries / rpc methods
   * Websockets examples / simple interface
### Circles.Contracts
  **Done**
  * Generic contract interfaces
  * Simple testing using Gnosis safe to interact with the hub and get data directly from hub
  **TODO**
  * Simple entry point as per RPC
  * Business Logic / simplification for users interaction
### Example
  **Todo**
  Web / mobile wallet / Gaming / Unity?
### Signing adapters / AA
  **Todo**
  Awaiting Nethereum implementation


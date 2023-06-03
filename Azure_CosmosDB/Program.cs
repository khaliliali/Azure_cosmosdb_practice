using Azure_CosmosDB;
using Microsoft.Azure.Cosmos;

string cosmosEndpointUri = "";
string cosmosDBKey = "";
string databaseName = "appdb";
string containerName = "Orders";

/* Create Cosmos DB */

//await CreateDatabase("appdb");

//async Task CreateDatabase(string databaseName)
//{
//    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

//    await cosmosClient.CreateDatabaseAsync(databaseName);
//    System.Console.WriteLine("Database Created. ");
//}

/* Create Container  */
//await CreateContainer("appdb", "Orders","/category");

//async Task CreateContainer(string databaseName, string containerName, string partitionKey)
//{
//    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

//    Database database = cosmosClient.GetDatabase(databaseName);
//    await database.CreateContainerAsync(containerName, partitionKey);

//    Console.WriteLine("Container created...");
//}

/* Adding items in CosmosDB */

// await AddItems("01", "Laptop", 133);
// await AddItems("02", "PC", 532);
// await AddItems("03", "Mobile", 1300);
// await AddItems("04", "Laptop", 13);

// async Task AddItems(string orderId, string category, int quantity)
// {
//     CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

//     Database database = cosmosClient.GetDatabase(databaseName);
//     Container container = database.GetContainer(containerName);

//     Order order = new Order()
//     {
//         id = Guid.NewGuid().ToString(), // important
//         orderId = orderId,
//         category = category,
//         quantity = quantity
//     };

//     ItemResponse<Order> response = await container.CreateItemAsync<Order>(order, new PartitionKey(category));
//     Console.WriteLine("Added item with Order Id {0}", orderId);
//     Console.WriteLine("Request Unit (Ru) {0}", response.RequestCharge);

// }
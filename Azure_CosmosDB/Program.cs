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
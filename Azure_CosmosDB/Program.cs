using Azure_CosmosDB;
using Microsoft.Azure.Cosmos;

string cosmosEndpointUri = "";
string cosmosDBKey = "";
string databaseName = "";
string containerName = "";

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


/* Reading Items from CosmosDB */

//await ReadItems();

//async Task ReadItems()
//{
//    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

//    Database database = cosmosClient.GetDatabase(databaseName);
//    Container container = database.GetContainer(containerName);

//    string sqlQuery = "SELECT o.orderId,o.category,o.quantity FROM Orders o";

//    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

//    FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

//    while (feedIterator.HasMoreResults)
//    {
//        FeedResponse<Order> feedResponse = await feedIterator.ReadNextAsync();
//        foreach (Order order in feedResponse)
//        {
//            Console.WriteLine("Order Id {0}", order.orderId);
//            Console.WriteLine("category {0}", order.category);
//            Console.WriteLine("Quantity {0}", order.quantity);
//        }
//    }

//}

/* Replace/Update Items in CosmosDB */

//await ReplaceItem();

//async Task ReplaceItem()
//{
//    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

//    Database database = cosmosClient.GetDatabase(databaseName);
//    Container container = database.GetContainer(containerName);

//    string orderId = "01";
//    string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

//    string id = "";
//    string category = "";

//    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

//    FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

//    while (feedIterator.HasMoreResults)
//    {
//        FeedResponse<Order> feedResponse = await feedIterator.ReadNextAsync();
//        foreach (Order order in feedResponse)
//        {
//            id = order.id;
//            category = order.category;
//        }
//    }

//    ItemResponse<Order> response = await container.ReadItemAsync<Order>(id, new PartitionKey(category));
//    var item = response.Resource;

//    item.quantity = 150;

//    await container.ReplaceItemAsync<Order>(item, id, new PartitionKey(category));

//    Console.WriteLine("Item is Updated {0} ");
//}

/* Delete Item in CosmosDB */

await DeleteItem();

async Task DeleteItem()
{
    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(containerName);

    string orderId = "01";
    string sqlQuery = $"SELECT o.id,o.category FROM Orders o WHERE o.orderId='{orderId}'";

    string id = "";
    string category = "";

    QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);

    FeedIterator<Order> feedIterator = container.GetItemQueryIterator<Order>(queryDefinition);

    while (feedIterator.HasMoreResults)
    {
        FeedResponse<Order> feedResponse = await feedIterator.ReadNextAsync();
        foreach (Order order in feedResponse)
        {
            id = order.id;
            category = order.category;
        }
    }

    ItemResponse<Order> response = await container.DeleteItemAsync<Order>(id, new PartitionKey(category));

    Console.WriteLine("Item is Deleted {0} ");

}
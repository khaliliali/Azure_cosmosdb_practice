using Azure_CosmosDB;
using Microsoft.Azure.Cosmos;

string cosmosEndpointUri = "";
string cosmosDBKey = "";
string databaseName = "";

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

//string containerName = "Orders";
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

//string containerName = "Orders";
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

//string containerName = "Orders";
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

//string containerName = "Orders";
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

//await DeleteItem();

//string containerName = "Orders";
//async Task DeleteItem()
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

//    ItemResponse<Order> response = await container.DeleteItemAsync<Order>(id, new PartitionKey(category));

//    Console.WriteLine("Item is Deleted {0} ");

//}

/* Add customers - Array of objects to the cosmosDB */
string containerName = "Customers";

await AddCustomer("C1", "Customer A", "Sydney",
    new List<Order>()
    {
        new Order
        {
            orderId = "01",
            category = "Laptop",
            quantity = 100
        },
        new Order
        {
            orderId = "03",
            category = "Desktop",
            quantity = 74
        }
    });

await AddCustomer("C2", "Customer B", "Shiraz",
    new List<Order>()
    {
        new Order
        {
            orderId = "04",
            category = "Laptop",
            quantity = 13
        }
    });

await AddCustomer("C3", "Customer C", "Tehran",
    new List<Order>()
    {
        new Order
        {
            orderId = "02",
            category = "PC",
            quantity = 13
        }
    });


async Task AddCustomer(string customerId, string customerName, string customerCity, List<Order> orders)
{
    CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosDBKey);

    Database database = cosmosClient.GetDatabase(databaseName);
    Container container = database.GetContainer(containerName);

    Customer customer = new Customer()
    {
        customerId = customerId,
        customerName = customerName,
        customerCity = customerCity,
        orders = orders
    };

    await container.CreateItemAsync<Customer>(customer, new PartitionKey(customerCity));

    Console.WriteLine("Added customer with Id {0}", customer.customerId);

}


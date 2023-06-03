using System;
using Newtonsoft.Json;

namespace Azure_CosmosDB
{
	public class Customer
	{
        [JsonProperty("id")]
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string customerCity { get; set; }
	}
}


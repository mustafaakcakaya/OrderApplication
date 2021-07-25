using Shopping.Aggregator.Extentions;
using Shopping.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<bool> ChangeStatus(ChangeStatusRequest request)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(request), UnicodeEncoding.UTF8, "application/json");
            var response = await _client.PostAsync($"/api/v1/Order/ChangeStatus", stringContent);
            return await response.ReadContentAs<bool>();
        }
    }
}

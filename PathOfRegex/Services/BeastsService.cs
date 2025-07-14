using Newtonsoft.Json;
using PathOfRegex.Models.Item;

namespace PathOfRegex.Services
{
    public class BeastsService
    {
        private readonly POENinjaClient _client;

        public BeastsService(POENinjaClient client)
        {
            _client = client;
        }

        public async Task<ItemResponse> GetBeastsAsync()
        {
            return JsonConvert.DeserializeObject<ItemResponse>(await _client.GetBeastsAsync());
        }
    }
}

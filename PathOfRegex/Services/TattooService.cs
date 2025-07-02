using Newtonsoft.Json;
using PathOfRegex.Models.Item;

namespace PathOfRegex.Services
{
    public class TattooService
    {
        private readonly POENinjaClient _client;

        public TattooService(POENinjaClient client)
        {
            _client = client;
        }

        public async Task<ItemResponse> GetTattoosAsync()
        {
            return JsonConvert.DeserializeObject<ItemResponse>(await _client.GetTattosAsync());
        }
    }
}

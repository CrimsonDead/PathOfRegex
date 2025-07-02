using Newtonsoft.Json;
using PathOfRegex.Models.Item;

namespace PathOfRegex.Services
{
    public class EsseneceService
    {
        private readonly POENinjaClient _client;

        public EsseneceService(POENinjaClient client)
        {
            _client = client;
        }

        public async Task<ItemResponse> GetEssencesAsync()
        {
            return JsonConvert.DeserializeObject<ItemResponse>(await _client.GetEssencesAsync());
        }
    }
}

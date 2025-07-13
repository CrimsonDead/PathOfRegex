namespace PathOfRegex
{
    public class POENinjaClient
    {
        private readonly HttpClient _httpClient;

        public POENinjaClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://poe.ninja/api/");

            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetEssencesAsync()
        {
            return await GetItemAsync("Essence");
        }

        internal async Task<string> GetTattosAsync()
        {
            return await GetItemAsync("Tattoo");
        }

        internal async Task<string> GetItemAsync(string type)
        {
            return await GetAsync($"data/itemoverview?league=Mercenaries&type={type}");
        }

        internal async Task<string> GetCurrencyAsync()
        {
            return await GetAsync("data/currencyoverview?league=Mercenaries&type=Currency");
        }

        internal async Task<string> GetBeastsAsync()
        {
            return await GetItemAsync("Beast");
        }
    }
}

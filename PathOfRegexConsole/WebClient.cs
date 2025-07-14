using PathOfRegex;
using PathOfRegex.Models.Item;
using PathOfRegex.Services;
using PathOfRegexConsole.ViewModels;

namespace PathOfRegexConsole
{
    internal class WebClient
    {
        private static readonly Lazy<POENinjaClient> _lazyClient = new Lazy<POENinjaClient>(() =>
        {
            var client = new POENinjaClient(new HttpClient());

            return client;
        });
        private static POENinjaClient POENinjaClient => _lazyClient.Value;

        public static async Task<List<ViewDataModel>> GetEssenceList()
        {
            EsseneceService esseneceService = new EsseneceService(POENinjaClient);
            ItemResponse essenceResponse = await esseneceService.GetEssencesAsync();

            return essenceResponse.Lines.OrderByDescending(e => e.ChaosValue).Select(e => new ViewDataModel { Name = e.Name, ChaosValue = e.ChaosValue, DivineValue = e.DivineValue, Selected = false }).ToList();
        }

        public static async Task<List<ViewDataModel>> GetTattoosList()
        {
            TattooService tattooService = new TattooService(POENinjaClient);
            ItemResponse itemResponse = await tattooService.GetTattoosAsync();

            return itemResponse.Lines.OrderByDescending(e => e.ChaosValue).Select(e => new ViewDataModel { Name = e.Name, ChaosValue = e.ChaosValue, DivineValue = e.DivineValue, Selected = false }).ToList();
        }

        internal static async Task<List<ViewDataModel>> GetBeastList()
        {
            BeastsService beastsService = new BeastsService(POENinjaClient);
            ItemResponse itemResponse = await beastsService.GetBeastsAsync();

            return itemResponse.Lines.OrderByDescending(e => e.ChaosValue).Select(e => new ViewDataModel { Name = e.Name, ChaosValue = e.ChaosValue, DivineValue = e.DivineValue, Selected = false }).ToList();
        }
    }
}

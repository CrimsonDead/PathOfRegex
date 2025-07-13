using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole.Menues
{
    internal class NewRegexMenu : IMenu
    {
        public List<IMenuItem> Items { get; set; }

        public NewRegexMenu()
        {
            Items =
                [
                    new ActionMenuItem(1, "Essences", ProcessEssencesAction),
                    new ActionMenuItem(2, "Tattoos", ProcessTattoosAction),
                ];
        }

        private void ProcessEssencesAction()
        {
            Console.Clear();

            var essences = WebClient.GetEssenceList();

            essences.Wait();

            ActionManager actionManager = new ActionManager(essences.Result);

            actionManager.Run();
        }

        private void ProcessTattoosAction()
        {
            Console.Clear();

            var tattoos = WebClient.GetTattoosList();

            tattoos.Wait();

            ActionManager actionManager = new ActionManager(tattoos.Result);

            actionManager.Run();
        }
    }
}

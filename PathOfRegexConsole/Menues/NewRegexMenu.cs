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

        private async void ProcessEssencesAction()
        {
            Console.Clear();

            var essences = await WebClient.GetEssenceList();

            ActionManager actionManager = new ActionManager(new ActionMenu(), essences);

            actionManager.Run();
        }

        private async void ProcessTattoosAction()
        {
            Console.Clear();

            var tattoos = await WebClient.GetTattoosList();

            ActionManager actionManager = new ActionManager(new ActionMenu(), tattoos);

            actionManager.Run();
        }
    }
}

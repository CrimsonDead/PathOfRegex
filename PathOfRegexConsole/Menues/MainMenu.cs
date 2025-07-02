using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole.Menues
{
    internal class MainMenu : IMenu
    {
        public List<IMenuItem> Items { get; set; }

        public MainMenu() 
        {
            Items =
                [
                    new SubMenuItem(1, "New Regex", OpenRegexMenu),
                    new ExitMenuItem(2, "Exit")
                ];
        }

        private IMenu OpenRegexMenu()
        {
            return new NewRegexMenu();
        }
    }
}

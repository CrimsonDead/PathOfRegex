using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole.Menues
{
    internal class MainMenu : IMenu
    {
        public List<MenuItem> Items { get; set; }

        public MainMenu() 
        {
            Items =
            [
                new MenuItem(1, "New Regex", OpenRegexMenu),
                new MenuItem(2, "Exit", Exit)
            ];
        }

        private void OpenRegexMenu()
        {
            Console.WriteLine("Открыто новое меню regex");
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}

using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.Menues;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole
{
    internal class MenuManager : Manager
    {
        public Stack<IMenu> History { get; set; } = new Stack<IMenu>();

        public MenuManager()
        {
            Menu = new MainMenu();
        }

        protected override void InvokeSubMenuItem(SubMenuItem subMenuItem)
        {
            History.Push(Menu);

            base.InvokeSubMenuItem(subMenuItem);
        }

        protected override IMenuItem? GetSelectedItem(ConsoleKeyInfo input)
        {            
            if (input.Key == ConsoleKey.Backspace)
            {
                if (History.Count > 0)
                    Menu = History.Pop();

                Show();

                return null;
            }
            else
            {
                return base.GetSelectedItem(input);
            }
        }

        protected override void Show()
        {
            Console.Clear();

            base.Show();
        }
    }
}

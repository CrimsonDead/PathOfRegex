using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole
{
    internal class MenuManager : Manager
    {
        public Stack<IMenu> History { get; set; } = new Stack<IMenu>();

        public MenuManager(IMenu menu) : base(menu) { }

        public override void Run()
        {
            ShowMenu();

            base.Run();
        }

        protected override void InvokeSubMenuItem(SubMenuItem subMenuItem)
        {
            History.Push(Menu);

            base.InvokeSubMenuItem(subMenuItem);
        }

        protected virtual void InvokeActionMenuItem(ActionMenuItem actionMenuItem)
        {
            base.InvokeActionMenuItem(actionMenuItem);

            ShowMenu();
        }

        protected override IMenuItem? GetSelectedItem(ConsoleKeyInfo input)
        {            
            if (input.Key == ConsoleKey.Backspace)
            {
                if (History.Count > 0)
                    Menu = History.Pop();

                ShowMenu();

                return null;
            }
            else
            {
                return base.GetSelectedItem(input);
            }
        }

        protected override void ShowMenu()
        {
            Console.Clear();

            base.ShowMenu();
        }
    }
}

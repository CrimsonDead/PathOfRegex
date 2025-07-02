using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole.MenuItems
{
    internal abstract class Manager
    {
        public IMenu Menu { get; set; }

        public Manager(IMenu menu)
        {
            Menu = menu;
        }

        public virtual void Run()
        {
            while (true)
            {
                var selectedItem = GetSelectedItem(Console.ReadKey(true));

                if (!Validate(selectedItem))
                {
                    break;
                }

                switch (selectedItem)
                {
                    case SubMenuItem subMenuItem:
                        InvokeSubMenuItem(subMenuItem);

                        break;

                    case ActionMenuItem actionMenuItem:
                        InvokeActionMenuItem(actionMenuItem);

                        break;

                    case ExitMenuItem exitMenuItem:
                        InvokeExitMenuItem(exitMenuItem);

                        break;
                }
            }
        }

        protected virtual bool Validate(IMenuItem? selectedItem) => true;

        protected virtual void InvokeSubMenuItem(SubMenuItem subMenuItem)
        {
            Menu = subMenuItem.Invoke();

            ShowMenu();
        }

        protected virtual void InvokeActionMenuItem(ActionMenuItem actionMenuItem) => actionMenuItem.Invoke();

        protected virtual void InvokeExitMenuItem(ExitMenuItem exitMenuItem) => exitMenuItem.Invoke();

        protected virtual IMenuItem? GetSelectedItem(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);

                return null;
            }
            else if (int.TryParse(input.KeyChar.ToString(), out int choice))
            {
                return Menu.Items.Find(item => item.Id == choice);
            }
            else
            {
                Console.WriteLine("Неправильный ввод. Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();

                ShowMenu();

                return null;
            }
        }

        protected virtual void ShowMenu()
        {
            foreach (IMenuItem item in Menu.Items)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}

﻿using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole.MenuItems
{
    internal abstract class Manager
    {
        public IMenu Menu { get; set; }

        public virtual void Run()
        {
            Show();

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

            Show();
        }

        protected virtual void InvokeActionMenuItem(ActionMenuItem actionMenuItem)
        {
            actionMenuItem.Invoke();

            Show();
        }

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

                Show();

                return null;
            }
        }

        protected virtual void Show()
        {
            foreach (IMenuItem item in Menu.Items.OrderBy(i => i.Id))
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}

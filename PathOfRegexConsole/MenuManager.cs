using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole
{
    internal class MenuManager
    {
        public IMenu Menu { get; set; }

        public MenuManager(IMenu menu)
        {
            Menu = menu;
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();

                var selectedItem = GetSelectedItem();

                if (selectedItem != null)
                {
                    selectedItem.Invoke();
                }
            }
        }

        public IMenuItem GetSelectedItem()
        {
            string input = string.Empty;

            if (char.IsDigit(Console.ReadKey().KeyChar) )
            {
                input = 
            }

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                return Menu.Items.Find(item => item.Id == choice);
            }
            else
            {
                Console.WriteLine("Неправильный ввод. Нажмите любую клавишу для продолжения...");
                Console.ReadKey();

                return null;
            }
        }

        public void ShowMenu()
        {
            Console.Clear();

            foreach (IMenuItem item in Menu.Items)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}

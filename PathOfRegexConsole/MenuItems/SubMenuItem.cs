using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole.MenuItems
{
    internal class SubMenuItem(int id, string name, Func<IMenu> action) : IMenuItem
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Func<IMenu> Action { get; set; } = action;

        public IMenu Invoke()
        {
            return Action.Invoke();
        }
    }
}

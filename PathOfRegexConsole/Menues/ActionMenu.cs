using PathOfRegexConsole.Enums;
using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole.Menues
{
    internal class ActionMenu : IMenu
    {
        public List<IMenuItem> Items { get; set; }

        public ActionMenu(List<IMenuItem> items)
        {
            Items = items;
        }
    }
}

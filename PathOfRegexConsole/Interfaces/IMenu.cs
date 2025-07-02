using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole.Interfaces
{
    internal interface IMenu
    {
        List<IMenuItem> Items { get; }
    }
}

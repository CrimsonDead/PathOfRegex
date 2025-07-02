using PathOfRegexConsole.Interfaces;
using System;

namespace PathOfRegexConsole.MenuItems
{
    internal class ActionMenuItem(int id, string name, Action action) : IMenuItem
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public Action Action { get; set; } = action;

        public void Invoke()
        {
            Action.Invoke();
        }

    }
}

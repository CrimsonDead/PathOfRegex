using PathOfRegexConsole.Interfaces;

namespace PathOfRegexConsole.MenuItems
{
    internal class ExitMenuItem(int id, string name) : IMenuItem
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;

        public void Invoke()
        {
            Environment.Exit(0);
        }
    }
}

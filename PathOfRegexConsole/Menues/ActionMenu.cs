using PathOfRegexConsole.Enums;
using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;

namespace PathOfRegexConsole.Menues
{
    internal class ActionMenu : IMenu
    {
        public List<IMenuItem> Items { get; set; }
        public TableState TableState { get; set; }

        public ActionMenu()
        {
            TableState = TableState.Less;

            Items =
                [
                    GetMoreLessMenuItem(),
                    new ActionMenuItem(2, "", OpenRegexMenu)
                ];
        }

        private void OpenRegexMenu()
        {
            Items.Remove(Items.First(i => i.Id == 1));
            Items.Add(GetMoreLessMenuItem());

            TableState = TableState == TableState.Less ? TableState.More : TableState.Less;
        }
        
        private ActionMenuItem GetMoreLessMenuItem()
        {
            return new ActionMenuItem(1,  TableState == TableState.More ? "Show more" : "Show less", OpenRegexMenu);
        }
    }
}

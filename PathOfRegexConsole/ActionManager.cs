using Newtonsoft.Json.Linq;
using PathOfRegexConsole.Enums;
using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.Menues;
using PathOfRegexConsole.MenuItems;
using PathOfRegexConsole.ViewModels;

namespace PathOfRegexConsole
{
    internal class ActionManager : Manager
    {
        private readonly IEnumerable<ViewDataModel> _data;
        private readonly int partCount = 5;
        private readonly int showLessCount = 15;
        private readonly int defaultSelectionSize = 10;
        private readonly double defaultMinDivinePrice = 1.0;
        private readonly double defaultMinChaosPrice = 10;

        public TableState TableState { get; set; }
        public List<IMenuItem> Items { get { return Menu.Items; } }

        public ActionManager(IEnumerable<ViewDataModel> data)
        {
            _data = data;
            Menu = CreateListMenu();
        }

        private IMenu CreateListMenu()
        {
            return new ActionMenu(
                [
                    new ActionMenuItem(1, "Create Regex", () => Menu = CreateRegexCreatorMenu()),
                    GetMoreLessMenuItem()
                ]);
        }

        private IMenu CreateRegexCreatorMenu()
        {
            return new ActionMenu(
                [
                    new ActionMenuItem(1, $"Get {defaultSelectionSize} most expensive", CreateRegexFirstN),
                    new ActionMenuItem(1, $"Get more than {defaultMinDivinePrice} divine", CreateRegexMoreThanDivine),
                    new ActionMenuItem(1, $"Get more than {defaultMinChaosPrice} chaos", CreateRegexMoreThanChaos),
                ]);
        }

        private void CreateRegexFirstN()
        {

        }

        private void CreateRegexMoreThanDivine()
        {

        }

        private void CreateRegexMoreThanChaos()
        {

        }

        private void OpenRegexMenu()
        {
            Items.Remove(Items.First(i => i.Id == 1));
            Items.Add(GetMoreLessMenuItem());

            TableState = TableState == TableState.Less ? TableState.More : TableState.Less;
        }

        private ActionMenuItem GetMoreLessMenuItem()
        {
            return new ActionMenuItem(2, TableState == TableState.More ? "Show more" : "Show less", OpenRegexMenu);
        }

        protected override bool Validate(IMenuItem? item)
        {
            if (item == null)
            {
                return false;
            }

            return true;
        }

        protected override IMenuItem? GetSelectedItem(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Backspace)
            {
                return null;
            }
            else 
            {
                return base.GetSelectedItem(input);
            }
        }

        private void ShowPartData()
        {
            List<string> headers = _data.ElementAt(0).GetType().GetProperties().Select(p => p.Name).ToList(); 
            List<int> columnLength = headers.Select(h => GetMaxColumnLeangh(h)).ToList();
            
            PrintRow(headers, columnLength);

            Console.WriteLine(new string('-', columnLength.Sum() + (columnLength.Count) * 3));

            foreach (var row in _data)
            {
                PrintRow(new List<string>{ row.Name, row.ChaosValue.ToString(), row.DivineValue.ToString() }, columnLength);
                
                if (_data.ToList().IndexOf(row) % partCount == 0 && _data.ToList().IndexOf(row) != 0)
                {
                    Console.WriteLine(new string('-', columnLength.Sum() + (columnLength.Count) * 3));
                }

                if (_data.ToList().IndexOf(row) >= showLessCount && TableState == TableState.Less)
                    break;
            }

            Console.WriteLine();
        }

        private void PrintRow(List<string> values, List<int> columnLength)
        {
            foreach (var header in values)
            {
                Console.Write(header.PadRight(columnLength[values.IndexOf(header)]));

                if (values.IndexOf(header) < values.Count - 1)
                {
                    Console.Write("   ");
                }
            }

            Console.WriteLine();
        }

        private int GetMaxColumnLeangh(string name)
        {
            return Math.Max(_data.Max(d => d.GetType().GetProperties().First(p => p.Name == name).GetValue(d).ToString().Length), name.Length);
        }

        protected override void Show()
        {
            Console.Clear();

            ShowPartData();

            base.Show();
        }
    }
}

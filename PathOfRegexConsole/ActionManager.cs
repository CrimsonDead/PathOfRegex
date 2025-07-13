using Newtonsoft.Json.Linq;
using PathOfRegex;
using PathOfRegexConsole.Enums;
using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.Menues;
using PathOfRegexConsole.MenuItems;
using PathOfRegexConsole.ViewModels;
using System.Data;

namespace PathOfRegexConsole
{
    internal class ActionManager : Manager
    {
        private readonly IEnumerable<ViewDataModel> _data;
        private readonly int partCount = 5;
        private readonly int showLessCount = 15;
        private readonly int defaultSelectionSize = 10;
        private readonly double defaultMinDivinePrice = 1.0;
        private readonly double defaultMinChaosPrice = 15;

        public string ResultRegex { get; private set; }

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
                    new ActionMenuItem(2, $"Get more than {defaultMinDivinePrice} divine", CreateRegexMoreThanDivine),
                    new ActionMenuItem(3, $"Get more than {defaultMinChaosPrice} chaos", CreateRegexMoreThanChaos),
                ]);
        }

        private void CreateRegexFirstN()
        {
            RegexCalculator calculator = new RegexCalculator(_data.Select(d => d.Name).ToList());

            ResultRegex = calculator.FewFrom(_data.Take(defaultSelectionSize).Select(d => d.Name).ToList());

            foreach (var item in _data.Take(defaultSelectionSize))
            {
                item.Selected = true;
            }
        }

        private void CreateRegexMoreThanDivine()
        {
            RegexCalculator calculator = new RegexCalculator(_data.Where(d => d.DivineValue > defaultMinDivinePrice).Select(d => d.Name).ToList());

            ResultRegex = calculator.FewFrom(_data.Take(defaultSelectionSize).Select(d => d.Name).ToList());
        }

        private void CreateRegexMoreThanChaos()
        {
            RegexCalculator calculator = new RegexCalculator(_data.Where(d => d.ChaosValue > defaultMinChaosPrice).Select(d => d.Name).ToList());

            ResultRegex = calculator.FewFrom(_data.Take(defaultSelectionSize).Select(d => d.Name).ToList());
        }

        private void OpenRegexMenu()
        {
            Items.Remove(Items.First(i => i.Id == 2));
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
                if (row.Selected)
                    Console.ForegroundColor = ConsoleColor.Red;

                PrintRow(new List<string> { row.Name, row.ChaosValue.ToString(), row.DivineValue.ToString() }, columnLength);

                Console.ForegroundColor = ConsoleColor.White;

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
            foreach (var value in values)
            {
                Console.Write(value.PadRight(columnLength[values.IndexOf(value)]));

                if (values.IndexOf(value) < values.Count - 1)
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

            if (!string.IsNullOrEmpty(ResultRegex))
                ShowRegex();

            base.Show();
        }

        private void ShowRegex()
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(ResultRegex);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }
    }
}

using Newtonsoft.Json.Linq;
using PathOfRegexConsole.Interfaces;
using PathOfRegexConsole.MenuItems;
using PathOfRegexConsole.ViewModels;

namespace PathOfRegexConsole
{
    internal class ActionManager : Manager
    {
        private readonly IEnumerable<ViewDataModel> _data;
        private readonly int partCount = 5;
        private readonly int showLessCount = 15;

        public ActionManager(IMenu menu, IEnumerable<ViewDataModel> data) : base(menu)
        {
            _data = data;
        }

        public override void Run()
        {
            ShowPartData();
            ShowMenu();

            base.Run();
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

                if (_data.ToList().IndexOf(row) >= showLessCount)
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
    }
}

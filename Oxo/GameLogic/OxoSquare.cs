using System.Windows.Forms;

namespace Oxo.GameLogic
{
    public class OxoSquare
    {
        // Properties
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public string Value { get; set; } = string.Empty;

        // Constructors
        public OxoSquare(int x, int y, string val)
        {
            X = (x-1);
            Y = (y-1);
            Value = val;
        }
        public OxoSquare(TextBox tb)
        {
            Value = tb.Text;
            string tempString = tb.Name;
            X = int.Parse(tempString.Substring(8, 1)) - 1;
            Y = int.Parse(tempString.Substring(10, 1)) - 1;
        }
        // Functions
    }
}

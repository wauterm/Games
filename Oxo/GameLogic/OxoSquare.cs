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
            X = (x);
            Y = (y);
            Value = val;
        }
        public OxoSquare(TextBox tb)
        {
            Value = tb.Text;
            string tempString = tb.Name;
            X = int.Parse(tempString.Substring(8, 1));
            Y = int.Parse(tempString.Substring(10, 1));
        }
        // Functions
    }
}

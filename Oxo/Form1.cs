using System.Windows.Forms;
using static Oxo.GameRules;

namespace Oxo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            

            InitializeComponent();

            
            
            // Global variables
            Player startingPlayer = DetermineStartingPlayer();

        }
    }
}

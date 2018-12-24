using System.Windows.Forms;

namespace Oxo
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
        }

        private void PlayGameButton_Click(object sender, System.EventArgs e)
        {
            if(Player1NameInput.Text != "" && Player2NameInput.Text != "")
            {
                GameRules.Players.Add(new Player(Player1NameInput.Text));
                GameRules.Players.Add(new Player(Player2NameInput.Text));
                // Todo - Memory leak?
                Hide();
                Form mainform = new MainForm();
                mainform.Show();
            }
            else
            {
                MessageBox.Show("Gelieve voor beide spelers een naam in te vullen.", "Inputfout", MessageBoxButtons.OK);
               
            }
        }
    }
}

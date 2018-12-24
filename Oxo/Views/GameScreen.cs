using Oxo.GameLogic;
using System.Windows.Forms;
using static Oxo.GameRules;

namespace Oxo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // Initialise player objects
            Player player1 = Players[0];
            Player player2 = Players[1];
            // Connect UI labels to player variables
            ConnectPlayerVariables();
            // Determine the starting player and display it.
            DetermineStartingPlayer(player1,player2);
            ShowTurnArrow();

            // Global functions
            void ConnectPlayerVariables()
            {
                Player1Label.Text = player1.PlayerName;
                labelScoreP1.Text = player1.Score.ToString();

                Player2Label.Text = player2.PlayerName;
                labelScoreP2.Text = player2.Score.ToString();
            }
        }
        private void btnRestartGame_Click(object sender, System.EventArgs e)
        {
            NewGame();
            Form welcomeForm = new WelcomeScreen();
            welcomeForm.Show();
            Close();
        }
        public void ShowTurnArrow()
        {
            if(Players[0].IsOnTurn == true)
            {
                LabelTurnArrowP1.Visible = true;
                labelTurnArrowP2.Visible = false;
            }
            else if (Players[1].IsOnTurn == true)
            {
                labelTurnArrowP2.Visible = true;
                LabelTurnArrowP1.Visible = false;
            }
        }
        public bool IsXorO(KeyEventArgs keyDown)
        {
            if ((keyDown.KeyData != Keys.X) && (keyDown.KeyData != Keys.O))
            {
                return false;
            }
            else
                return true;
        }
        private void AnyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (IsXorO(e))
            {
                ((TextBox)sender).Text = e.KeyCode.ToString().ToLower();
                OxoSquare square = new OxoSquare((TextBox)sender);

                Grid[square.X, square.Y] = square.Value;
                e.SuppressKeyPress = true;
                if (CheckForWinningSequence())
                {
                    ((TextBox)sender).Text = "";
                    MessageBox.Show("Je hebt gewonnen.");
                }
                else
                {
                    SwitchTurn();
                    ShowTurnArrow();
                    e.SuppressKeyPress = true;
                }
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
        private void AnyTextBox_Click(object sender, System.EventArgs e)
        {
            if((((TextBox)sender).Text.ToLower() != "x") && (((TextBox)sender).Text.ToLower() != "o"))
                ((TextBox)sender).Text = "";
        }
    }
}

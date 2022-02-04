using System.Windows.Forms;

namespace Card_Game_Simulator
{
    public partial class GetSpeed : Form //Form that allows player to select how fast the game will run.
    {
        public int speed = 4;
        public GetSpeed()
        {
            InitializeComponent();
        }

        private void btnSlow_Click(object sender, System.EventArgs e)
        {
            speed = 13;
            Close();
        }

        private void btnNormal_Click(object sender, System.EventArgs e)
        {
            speed = 7;
            Close();
        }

        private void btnFast_Click(object sender, System.EventArgs e)
        {
            speed = 4;
            Close();
        }

        private void btnHardcore_Click(object sender, System.EventArgs e)
        {
            speed = 2;
            Close();
        }
    }
}
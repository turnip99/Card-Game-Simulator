using Card_Game_Simulator.Properties;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    public partial class Instructions : Form
    {
        public Instructions(char instructionType)
        {
            InitializeComponent();
            switch (instructionType) //Goes to a method to get a form background depending on which instructions were requested.
            {
                case 'G': GeneralGuide(); break;
                case 'C': CheatRules(); break;
                case 'F': FLRules(); break;
                default: break;
            }
        }

        private void GeneralGuide()
        {
            BackgroundImage = Resources.General_Game_Guide;
        }

        private void CheatRules()
        {
            BackgroundImage = Resources.Cheat_Rules;
        }

        private void FLRules()
        {
            BackgroundImage = Resources.Five_Leaves_Rules;
        }
    }
}
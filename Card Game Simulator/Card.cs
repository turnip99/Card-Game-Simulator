using Card_Game_Simulator.Properties;
using System.Drawing;

namespace Card_Game_Simulator
{
    enum Symbol {_2 = 2, _3, _4, _5, _6, _7, _8, _9, _10, Jack, Queen, King, Ace} //This enum links the associated numbers with their symbols.
    enum Suit { Clubs = 1, Diamonds, Hearts, Spades}; //This enum links the associated numbers with their suits.
    class Card
    {
        private Symbol symbol;
        public Symbol Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        private Suit suit;
        public Suit Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        public Card(int suN, int syN)
        {
            Suit = (Suit)suN;
            Symbol = (Symbol)syN;
            Name = Symbol + "Of" + Suit;
            Image = (Image)Resources.ResourceManager.GetObject(Name); //Gets image from resources with name equal to 'Name'.
        }
    }
}
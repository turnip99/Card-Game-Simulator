namespace Card_Game_Simulator
{
    class Player
    {
        private int playerNum;
        public int PlayerNum
        {
            get { return playerNum; }
            set { playerNum = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int startPosition; //Contains the position of the array shown on the first spot on the UI.
        public int StartPosition
        {
            get { return startPosition; }
            set { startPosition = value; }
        }

        public Hand hand = new Hand();

        public Player(int num)
        {
            PlayerNum = num;
        }
    }
}
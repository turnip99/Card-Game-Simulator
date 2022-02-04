using System;

namespace Card_Game_Simulator
{
    class NPCAI
    {
        public Random rnd = new Random();

        protected int Exponential(int num, int pow) //Calculates an exponential with an int (the Math class only accepts doubles).
        {
            if (num == 1)
            {
                return 1;
            }
            if (pow == 1)
            {
                return num;
            }
            for (int i = 0; i < pow; i++)
            {
                num *= num;
            }
            return num;
        }
    }
}
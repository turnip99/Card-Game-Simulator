using System;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    class Queue
    {
        Random rnd = new Random();
        private int size;
        public Player[] items;
        private int head;
        private int tail;
        public int counter;
        public Queue(int theSize, char gameType)
        {
            size = theSize;
            head = 0;
            tail = 0;
            items = new Player[size];
            push(new Player(1));
            push(new Player(2));
            if (size == 4) //player 3 is excluded in a 3 player game (player 1/2/4 only).
            {
                push(new Player(3));
            }
            push(new Player(4));
            counter = size - 1;
            RandomiseStart();
        }

        public void push(Player item) //Push function.
        {
            if (head == tail && items[head] != null)
            {
                MessageBox.Show("Error: Queue is full.");
            }
            else
            {
                items[tail] = item;
                counter++;
                tail++;
                if (tail == size)
                {
                    tail = 0;
                }
            }
        }

        public Player pop() //Pop function.
        {
            if (counter == 0)
            {
                return null;
            }
            else
            {
                Player temp = items[head];
                items[head] = null;
                head++;
                counter--;
                if (head == size)
                {
                    head = 0;
                }
                return temp;
            }
        }

        public void RandomiseStart() //Pops/pushes items until a randomly chosen players is at the start of the queue.
        {
            int firstNum = rnd.Next(1, size + 1);
            if (size == 3 && firstNum == 3)
            {
                firstNum = 4;
            }
            Player x = items[head];
            while (x.PlayerNum != firstNum)
            {
                push(pop());
                x = items[head];
            }
        }

        public int CheckLength() //Checks if all values in array = null.
        {
            int Num = 0;
            foreach (Player slot in items)
            {
                if (slot != null)
                {
                    Num++;
                }
            }
            return Num;
        }

        public Player GetTopItem() //Returns current player.
        {
            return items[head];
        }

        public Player GetNextPlayer() //Returns player who has their turn next.
        {
            if (head >= counter && items[0] != null)
            {
                return items[0];
            }
            else if (items[head + 1] != null)
	        {
                return items[head + 1];
            }
            return null;
        }

        public Player GetPlayer(int num)
        {
            foreach (Player player in items)
            {
                if (player != null && player.PlayerNum == num)
                {
                    return player;
                }
            }
            return null;
        }
    }
}
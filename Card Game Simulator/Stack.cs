using Card_Game_Simulator.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Card_Game_Simulator
{
    class Stack
    {
        Random rnd = new Random();
        private int size;
        public Card[] items;
        public int pointer;

        public Stack(int theSize)
        {
            size = theSize;
            pointer = 0;
            items = new Card[size];
        }

        public void push(Card newValue) //Push function.
        {
            if (pointer != size)
            {
                items[pointer] = newValue;
                pointer++;
            }
            else
            {
                MessageBox.Show("Error: Stack is full!");
            }
        }

        public Card pop() //Pop function.
        {
            if (pointer > 0)
            {
                Card temp = items[pointer - 1];
                items[pointer - 1] = null;
                pointer--;
                return temp;
            }
            else
            {
                MessageBox.Show("Error: Stack is empty...");
                return null;
            }
        }

        public Card[] MergeShuffleInitial(bool soundBool) //Starts the merge-shuffle, used to access 'items' array since MergeShuffle method requires a parameter.
        {
            if (soundBool)
            {
                SoundPlayer sndShuffleSort = new SoundPlayer(Resources.Shuffle);
                sndShuffleSort.Play();
            }
            items = MergeShuffle(items);
            return items;
        }

        public Card[] MergeShuffle(Card[] data) //Main method for merge shuffle.
        {
            if (data.Length <= 1)
            {
                return data;
            }
            int mid;
            mid = data.Length / 2;
            Card[] leftList = new Card[mid];
            for (int i = 0; i < leftList.Length; i++)
            {
                leftList[i] = data[i];
            }
            Card[] rightList = new Card[data.Length - mid];
            for (int i = 0; i < rightList.Length; i++)
            {
                rightList[i] = data[i + mid];
            }
            leftList = MergeShuffle(leftList);
            rightList = MergeShuffle(rightList);
            return Merge(leftList, rightList);
        }

        public Card[] Merge(Card[] left, Card[] right) //Performs merge, randomly swapping items.
        {
            List<Card> leftList = left.OfType<Card>().ToList();
            List<Card> rightList = right.OfType<Card>().ToList();
            List<Card> resultList = new List<Card>();
            while ((leftList.Count > 0) || (rightList.Count > 0))
            {
                if ((leftList.Count > 0) && (rightList.Count > 0))
                {
                    int rndNum = rnd.Next(1, 3);
                    if (rndNum == 1) //50% chance to swap items.
                    {

                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }
                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }
            Card[] resultArray = resultList.ToArray(); //turns to array and returns shuffled section.
            return resultArray;
        }

        public Card GetCardByDistanceFromTop(int distance) //Retrieves the value of the top card on the stack.
        {
            if (GetHowMany() == 0)
            {
                return null;
            }
            return items[pointer - distance];
        }

        public int GetHowMany()
        {
            int result = 0;
            foreach (Card card in items)
            {
                if (card != null)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
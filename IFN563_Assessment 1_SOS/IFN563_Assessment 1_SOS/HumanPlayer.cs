using static System.Console;
using System;
namespace IFN563_Assessment_1_SOS
{
    public class HumanPlayer : Player
    {
        protected string input;
        protected int row, column;

        public HumanPlayer()
        {
            type = 1;
        }

        public override int[] MakeMove()
        {
            Write("Please enter your choice>> ");
            input = ReadLine();
            while (!IsValidInput())
            {
                Write("Invalid Input!please enter the row and column numbers separated by a white space (e.g 1 1).>> ");
                input = ReadLine();
            }
            int[] move = new int[2];
            move[0] = row - 1;
            move[1] = column - 1;
            return move;
        }

        private bool IsValidInput()
        {
            var temp = input.Split(" ");

            if (temp.Length != 2)
            {
                return false;
            }

            if (int.TryParse(temp[0], out row) && int.TryParse(temp[1], out column))
            {
                return true;
            }

            return false;
        }
    }
}


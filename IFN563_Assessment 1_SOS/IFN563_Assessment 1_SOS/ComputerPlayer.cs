using System;
namespace IFN563_Assessment_1_SOS
{
    public class ComputerPlayer : Player
    {

        public ComputerPlayer()
        {
            type = 0;
        }

        public override int[] MakeMove()
        {
            Random r = new Random();
            int[] move = new int[2];
            move[0] = r.Next(0, 3);
            move[1] = r.Next(0, 3);
            return move;
        }
    }
}


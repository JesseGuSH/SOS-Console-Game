using static System.Console;
using System;

namespace IFN563_Assessment_1_SOS
{
	public abstract class Player
	{
		protected int type;
		protected string symbol;
		protected List<int[]> historyOfMoves = new List<int[]>();

        public Player()
		{ 
		}

		public int Type
		{
			get
			{
				return type;
			}
		}

		public List<int[]> HistoryOfMoves
		{
			get { return historyOfMoves; }
		}



        public string Symbol
		{
			set {
				symbol = value;
			}

				get
			{
				return symbol;
			}
		}

		public abstract int[] MakeMove();

    }

}

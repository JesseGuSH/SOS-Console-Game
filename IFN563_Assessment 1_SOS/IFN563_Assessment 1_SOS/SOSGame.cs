using static System.Console;
using System.IO;
using System;
using System.Data.Common;

namespace IFN563_Assessment_1_SOS
{
	public class SOSGame:Game
	{
		protected int currentRoundScore = 0;
		protected int player1Score = 0, player2Score = 0;


		public SOSGame()
		{
			gameOver = false;
            board = new SOSBoard();
        }

        public SOSGame(string gameStatus, string mode, string aTurn)
        {
            gameOver = Convert.ToBoolean(gameStatus);
            modeOfPlay = mode;
            currentTurn = Convert.ToInt32(aTurn);
            SetModeAndPlayer();
            board = new SOSBoard();
            board.DisplayBoard();
        }

        public SOSGame(string gameStatus, string mode,string aTurn,string p1Socre,string p2Score, string gridData)
        {
			gameOver = Convert.ToBoolean(gameStatus);
			modeOfPlay = mode;
			currentTurn = Convert.ToInt32(aTurn);
            SetModeAndPlayer();
            player1Score = Convert.ToInt32(p1Socre);
			player2Score = Convert.ToInt32(p2Score);
            board = new SOSBoard();
			board.InitBoard(gridData);
            board.DisplayBoard();
        }

        protected override void GamePlaying()
		{
            if (current_Player.Type != 0)
            {
                string choice = HelpSystem.SelectCommand();

                switch (choice)
                {
					case "1": PlayerMove();break;
					case "2": Undo(); break;
                    case "3": SaveGame(); break;
                }
				}
				else if (current_Player.Type == 0)
				{
					PlayerMove();
				}



            gameOver = board.IsFull();
            SwitchPlayer();
        }


		protected override void PlayerMove()
		{
            WriteLine();

            var input = current_Player.MakeMove();

            while (!CheckValidMove(input))
            {
                input = current_Player.MakeMove();
            }

            board.GetSymbol(current_Player.Symbol, input[0], input[1]);

            current_Player.HistoryOfMoves.Add(input);

            board.DisplayBoard();

            if (current_Player.Type == 0)
            {
                WriteLine("");
                WriteLine("The computer has placed its letter at {0} {1}", input[0] + 1, input[1] + 1);
            }

            if (currentTurn > 3) { CheckScore(input); } else { currentTurn++; }
        }

		protected override bool CheckValidMove(int[] input)
		{
            int row = input[0];
            int column = input[1];

            if ((row < 0 || row > board.GridRow-1) || (column < 0 || column > board.GridColumn-1))
			{
				if (current_Player.Type == 1) WriteLine("Invalid Input!The choice is out of the board.The row and column should be within 1-3.");
				return false;
			}

			if ((board.Grid[row, column] != null))
			{
				if (current_Player.Type == 1) WriteLine("This spot is occupied");
				return false;
			}

			return true;
		}

		protected void CheckScore(int[] input)
		{
			int aRow = input[0];
			int aColumn = input[1];
			int sum = aColumn + aRow;
			int rowCheck = 0;
			int columnCheck = 0;
			int diagonalCheck = 0;
			int reverseDiagonalCheck = 0;
			int score;

			if (board.CheckRow(current_Player.Symbol,aRow)) rowCheck++;
			if (board.CheckColumn(current_Player.Symbol, aColumn)) columnCheck++;
			if ((aRow==aColumn)&&board.CheckDiagonal(current_Player.Symbol)) diagonalCheck++;
			if ((sum == 2) && board.CheckReverseDiagonal(current_Player.Symbol)) reverseDiagonalCheck++;
			score = rowCheck + columnCheck + diagonalCheck+reverseDiagonalCheck;

			if (score != 0)
			{	
				GrantPlayerPoint(score);
				if (!board.IsFull())
				{
                    Write("Congrats!You won {0} score(s) and you could take {0} more move(s)!", score);
                    WriteLine("");
                    currentRoundScore = score;
                    OneMoreMoves();
                }
			}

            currentTurn++;
        }

		protected void OneMoreMoves()
		{
			while (currentRoundScore != 0 && !gameOver)
			{
				PlayerMove();
				gameOver = board.IsFull();
				currentRoundScore--;
			}

            currentTurn++;
        }

		protected override void SwitchPlayer()
		{
			if (current_Player == player1)
			{
				current_Player = player2;
			}
			else if (current_Player == player2)
			{
				current_Player = player1;
			}
		}


		protected void GrantPlayerPoint(int score)
		{
			if (current_Player == player1) player1Score += score;
			else if (current_Player == player2) player2Score += score;
		}


		protected override void DeclareResult()
		{

			WriteLine("");

			if (player1Score > player2Score)
			{
				WriteLine("Congratulation!Player-1 is the winner with {0} socres.", player1Score);
			}
			else if (player1Score < player2Score)
			{
				WriteLine("Congratulation!Player-2 is the winner with {0} socres.", player2Score);
			}
			else if (player1Score == player2Score)
			{
				WriteLine("It's a draw.");
			}
			WriteLine("Press any Key to Quit.");
            ReadKey();
            Clear();
			Environment.Exit(0);
		}

		protected override void Undo()
		{
			if (current_Player.HistoryOfMoves.Count == 0)
			{
				WriteLine("No moves are available to be undone");
				SwitchPlayer();
				return;
			}

			int lastIndex = current_Player.HistoryOfMoves.Count - 1;
			int[] indicesToNull = current_Player.HistoryOfMoves[lastIndex];
			board.ClearSymbol(indicesToNull);
			current_Player.HistoryOfMoves.RemoveAt(lastIndex);
			board.DisplayBoard();
			PlayerMove();
		}

		protected override void SaveGame()
		{
			string directoryPath = Path.Combine(Environment.CurrentDirectory, "SOSGAME");
			Write("Please enter the file name>> ");
			string fileName = ReadLine();
			if (fileName.ToUpper() == "Q") Environment.Exit(0);
			string userInputUpper = fileName.ToUpper();
			string path = directoryPath +"_"+ fileName +".txt";

			if (!File.Exists(path))
			{
				// Create a file to write to.
				using (StreamWriter sw = File.CreateText(path))
				{
					sw.WriteLine(gameOver);
					sw.WriteLine(modeOfPlay);
					sw.WriteLine(currentTurn);
					sw.WriteLine(player1Score);
					sw.WriteLine(player2Score);
					var m = player1.HistoryOfMoves;
					foreach (var x in m) { sw.Write("{0}{1}{2};", player1.Symbol, x[0], x[1]); }
					sw.Write("");
					var n = player2.HistoryOfMoves;
					foreach (var y in n) { sw.Write("{0}{1}{2};", player2.Symbol, y[0], y[1]); }
				}

				WriteLine("Your game has been successfully saved!");
				WriteLine("Thanks for playinig");
				Environment.Exit(0);
            }

		}
	}

}
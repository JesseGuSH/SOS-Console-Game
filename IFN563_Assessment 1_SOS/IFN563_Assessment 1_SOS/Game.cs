using static System.Console;
using System;
namespace IFN563_Assessment_1_SOS
{
	public abstract class Game
	{
        protected Board board;
        protected bool gameOver;
        protected int currentTurn = 0;
        protected string modeOfPlay;
        protected const string mode0 = "1";
        protected const string mode1 = "2";
        protected Player player1, player2, current_Player;

        public Game()
		{
		}

        public void StartGame()
        {
            modeOfPlay = HelpSystem.SelectMode();
            Clear();
            SetModeAndPlayer();
            WriteLine("Here's the board to start: ");
            board.DisplayBoard();

            while (!gameOver)
            {

                PromptForSubsequentInput();
                GamePlaying();
            }

            DeclareResult();
        }

        public void ResumeGame()
        {
            while (!gameOver)
            {
                PromptForSubsequentInput();

                GamePlaying();
            }

            DeclareResult();
        }

        protected abstract void GamePlaying();

        protected virtual void SetModeAndPlayer()
        {
            if (modeOfPlay == mode0)
            {
                player1 = new HumanPlayer();
                player2 = new HumanPlayer();

            }
            else if (modeOfPlay == mode1)
            {
                player1 = new ComputerPlayer();
                player2 = new HumanPlayer();

            }

            player1.Symbol = "X";
            player2.Symbol = "O";

            if (currentTurn % 2 == 0)
            {
                current_Player = player1;
            }
            else if (currentTurn % 2 != 0)
            {
                current_Player = player2;
            }
        }

        protected virtual void PromptForSubsequentInput()
        {
            if (currentTurn % 2 == 0)
            {
                WriteLine("");
                WriteLine("Player-1's Turn (Player's Symbol:X): ");
            }
            else if (currentTurn % 2 != 0)
            {
                WriteLine("");
                WriteLine("Player-2's Turn (Player's Symbol:O): ");
            }
        }

        protected abstract void PlayerMove();

        protected virtual bool CheckValidMove(int[] input)
        {
            int row = input[0];
            int column = input[1];

            if ((row < 0 || row > board.GridRow) || (column < 0 || column > board.GridColumn))
            {
                if (current_Player.Type == 1) WriteLine("Invalid Input");
                return false;
            }

            if ((board.Grid[row, column] != null))
            {
                if (current_Player.Type == 1) WriteLine("This spot is occupied");
                return false;
            }

            return true;
        }

        protected virtual void SwitchPlayer()
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

        protected abstract void DeclareResult();

        protected virtual void Undo()
        {
            int lastIndex = current_Player.HistoryOfMoves.Count - 1;
            int[] indicesToNull = current_Player.HistoryOfMoves[lastIndex];
            board.ClearSymbol(indicesToNull);
            current_Player.HistoryOfMoves.RemoveAt(lastIndex);
            board.DisplayBoard();
            PlayerMove();
        }

        protected abstract void SaveGame();

    }
}


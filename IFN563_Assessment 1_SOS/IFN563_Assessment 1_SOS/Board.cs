using static System.Console;
using System;

namespace IFN563_Assessment_1_SOS
{
    public abstract class Board:IChainInspector
    {
        protected int type;
        protected int gridRow,gridColumn;
        protected string[,] grid;

        public Board()
        {
        }

        public abstract void DisplayBoard();

        public abstract void InitBoard(string data);

        public string[,] Grid
        {
            set { grid = value; }
            get { return grid; }
        }

        public int GridRow
        {

            get { return gridRow; }
        }

        public int GridColumn
        {

            get { return gridColumn; }
        }

        public void GetSymbol(string symbol, int aRow,int aColumn)
        {
            int row = Convert.ToInt32(aRow);
            int column = Convert.ToInt32(aColumn);
            grid[row, column] = symbol;
        }

        public void ClearSymbol(int[] indices)
        {
            int row = indices[0];
            int column = indices[1];
            grid[row,column] = null;
        }

        public abstract bool CheckRow(string symbol, int aRow);
        public abstract bool CheckColumn(string symbol, int aColumn);
        public abstract bool CheckDiagonal(string symbol);
        public abstract bool CheckReverseDiagonal(string symobl);
        public abstract bool IsFull();

    }

}
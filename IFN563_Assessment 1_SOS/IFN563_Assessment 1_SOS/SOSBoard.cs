using System;
namespace IFN563_Assessment_1_SOS
{
    public class SOSBoard : Board
    {

        public SOSBoard()
        {
            gridRow = 3;
            gridColumn = 3;
            grid = new string[gridRow, gridColumn];
            
        }

        public override void InitBoard(string data)
        {
            string[] d = data.Split(";");

            for (int i = 0; i < d.Length - 1; i++)
            {
                var x = d[i];
                string s = x[0].ToString();
                int m = Convert.ToInt32(x[1]) - 48;
                int n = Convert.ToInt32(x[2]) - 48;
                GetSymbol(s, m, n);
            }
        }

        public override void DisplayBoard()
        {
            Console.WriteLine();
            for (int i = 0; i < gridRow; i++)
            {
                if (i >= 1)
                {
                    Console.WriteLine("       |       |       ");
                    Console.WriteLine("-------+-------+-------");
                }
                Console.WriteLine("       |       |       ");
                for (int j = 0; j < gridColumn; j++)
                {
                    if (j >= 1) Console.Write("  |");
                    Console.Write(" {0,3} ", grid[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("       |       |       ");
        }

        public override bool CheckRow(string symbol, int aRow)
        {
            if (grid[aRow, 0] == symbol && grid[aRow, 1] == symbol && grid[aRow, 2] == symbol)
            {
                return true;
            }

            return false;
        }

        public override bool CheckColumn(string symbol, int aColumn)
        {

            if (grid[0, aColumn] == symbol && grid[1, aColumn] == symbol && grid[2, aColumn] == symbol)
            {
                return true;
            }

            return false;
        }

        public override bool CheckDiagonal(string symbol)
        {

            if (grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol)
            {
                return true;
            }

            return false;

        }

        public override bool CheckReverseDiagonal(string symbol)
        {

            if (grid[0, 2] == symbol && grid[1, 1] == symbol && grid[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }

        public override bool IsFull()
        {
            for (int i = 0; i < gridRow; i++)
            {
                for (int j = 0; j < gridColumn; j++)
                {
                    if (Equals(grid[i, j], null))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}


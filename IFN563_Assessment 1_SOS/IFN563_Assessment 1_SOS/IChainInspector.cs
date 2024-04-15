using System;
namespace IFN563_Assessment_1_SOS
{
	public interface IChainInspector
	{
		public abstract bool CheckRow(string symbol,int aRow);
        public abstract bool CheckColumn(string symbol,int aColumn);
        public abstract bool CheckDiagonal(string symbol);
		public abstract bool CheckReverseDiagonal(string symbol);
	}
}


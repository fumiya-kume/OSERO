using System;
using Milkcha.Model.Type;
using MilkCha.Model;
namespace Milkcha
{
	public class ReversiBoard : Model.IReversiBoard
	{
		private StoneInfo[,] board = new StoneInfo[,]
		{
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
			{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() }
		};

		public ReversiBoard()
		{
			Init();
		}

		public Color[] GetEnablePosition()
		{
			throw new NotImplementedException();
		}

		public void Init()
		{
			board = new StoneInfo[,]
			{
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() },
				{ new StoneInfo(),new StoneInfo(), new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo(),new StoneInfo() }
			};
		}

		public Color GetStone(int x, int y)
		{
			if (x < 0 || x > 7 || y < 0 || y > 7)
			{
				throw new IndexOutOfRangeException();
			}
			return board[x, y].stoneColor;
		}

		public void SetStone(StoneInfo stone)
		{
			if (stone.X < 0 || stone.X > 7 || stone.Y < 0 || stone.Y > 7)
			{
				throw new IndexOutOfRangeException();
			}
			board[stone.X, stone.Y] = new StoneInfo(stone.X, stone.Y, stone.stoneColor);
		}
	}
}

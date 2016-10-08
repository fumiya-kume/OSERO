using System;
namespace Milkcha.Model.Type
{
	public class StoneInfo
	{

		public StoneInfo(int x = 0,int y = 0,Color color = Color.None)
		{
			X = x;
			Y = y;
			stoneColor = color;
		}

		public int X
		{
			get;
			set;
		}
		public int Y
		{
			get;
			set;
		}
		public Color stoneColor
		{
			get;
			set;
		}
	}

	public enum Color
	{
		Black,
		White,
		None
	}
}

using System;
namespace Milkcha.Model.Type
{
	public class StoneInfo
	{
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

using System;
using MilkCha.Model;
namespace Milkcha.Model
{
	public interface IReversiBoard
	{
		void SetStone();
		void GetStone();
		Type.Color[] GetEnablePosition();
	}
}

using System;
using Milkcha.Model.Type;
using MilkCha.Model;
namespace Milkcha.Model
{
	public interface IReversiBoard
	{
		void SetStone(StoneInfo stone);
		Color GetStone(int x,int y);
		Type.Color[] GetEnablePosition();
	}
}

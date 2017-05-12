using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
	public static class UtilityFunction
	{
		public static GameState Viewing = GameState.ViewingMainPage;
		public static Stack<GameState> gameStateStack = new Stack<GameState> ();

		public static bool IsMouseInRectangle (int x, int y, int width, int height, Point2D mouse)
		{
			return (mouse.X >= x && mouse.Y >= y && mouse.X <= x + width && mouse.Y <= y + height);
		}

		public static void EndCurrentState ()
		{
			if (gameStateStack.Count != 0)
				gameStateStack.Pop ();
		}
	}
}

using System;
using SwinGameSDK;

namespace MyGame
{
	public class SettingController:Page
	{
		public SettingController () { };

		public override void DrawPage ()
		{
			SwinGame.DrawBitmap ("bg.jpg", 0, 0);
		}

		public override void Execute ()
		{
			DrawPage ();
			HandleInput ();
		}

		public override void HandleInput ()
		{
			if (SwinGame.KeyTyped (KeyCode.vk_ESCAPE))
			{
				UtilityFunction.gameStateStack.Pop ();
			}
		}
	}
}

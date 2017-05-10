using System;
using SwinGameSDK;

namespace MyGame
{
	public class PlayerVehicle
	{
		private double _x, _y;



		public PlayerVehicle(double x,double y)
		{
			_x = x;
			_y = y;
		}




		public void NavigateLeft ()
		{
			if (this.X > 400)
			{
				this.X -= 95;
			}
		}

		public void NavigateRight ()
		{
			if (this.X < 480)
			{
				this.X += 95;
			}
		}
			

		//public void SlowDown ()
		//{
			//this.Y -= 40;
		//}

		public void Draw ()
		{
			SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80); 
			SwinGame.DrawBitmap ("player.png", (float)X, (float)Y);
		}
			

		public double X
		{
			get{ return _x; }
			set{ _x = value; }

		}

		public double Y
		{
			get{ return _y; }
			set{ _y = value; }

		}
	}
}


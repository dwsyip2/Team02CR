using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Car:Obstacle
	{
		private double _speed; 


		public Car (double x,double y):base(x,y)
		{
			_speed = 2.5;
		}
			
		public override void Drop ()
		{
			
			if (this.Y < 610)				
			{
				this.Y += _speed; 			
			}
		}




		public override bool Collision(PlayerVehicle p)
		{
			//return SwinGame.PointInRect
			return SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X, (float)p.Y, 1, 1);
		//	return SwinGame.PointInRect ((float)X, 500, (float)X, (float)Y, 1, 1);
		}

		public override void Draw ()
		{
				SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80); 
				SwinGame.DrawBitmap ("car.png", (float)X, (float)Y);
		}

		public double Speed
		{
			get{ return _speed;}
			set{ _speed = value;}

		}
			
	}
}


using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Lorry:Obstacle
	{
		private double _speed; 
		public Lorry (double x,double y):base(x,y)
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

		public override  bool Collision(PlayerVehicle p)
		{
			return SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X, (float)p.Y, 1, 1);
		}


		public override void Draw ()
		{
			SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80);  
			SwinGame.DrawBitmap ("lorry.png", (float)X, (float)Y);
		}

		public double Speed
		{
			get{ return _speed;}
			set{ _speed = value;}

		}
	}
}


using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Car:Obstacle
	{
		//private double _speed;
		//private double _prevTime;
		//private double _curTime;


		public Car (double x,double y):base(x,y)
		{
			_lifeCount = -1;
		}
			
		//public override void Drop ()
		//{
		//	_curTime = DateTime.Now.Millisecond;
		//	if (_curTime < _prevTime) _curTime += 1000;
		//	if (this.Y < 610)				
		//	{
		//		this.Y -= _speed*(_curTime-_prevTime)/1000; 			
		//	}
		//	_prevTime = _curTime;
		//}




		//public override bool Collision(PlayerVehicle p)
		//{
		//	//return SwinGame.PointInRect
		//	return SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X, (float)p.Y, 1, 1);
		////	return SwinGame.PointInRect ((float)X, 500, (float)X, (float)Y, 1, 1);
		//}

		public override void Draw ()
		{
				//SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80); 
				SwinGame.DrawBitmap ("car.png", (float)X, (float)Y);
		}

		//public double Speed
		//{
		//	get{ return _speed;}
		//	set{ _speed = value;}
		//}

		public ObstacleType getType {
			get { return ObstacleType.Car; }
		}
	}
}


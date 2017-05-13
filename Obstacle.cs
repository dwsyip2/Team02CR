using System;
using SwinGameSDK;

namespace MyGame
{
	public class Obstacle
	{
		private double _x, _y;
		public DateTime _prevTime;
		public DateTime _curTime;
		protected double _speed;
		protected double _lifeCount;
		const int END = 610;

		public Obstacle ()
		{
			_y = 20;
            _prevTime = DateTime.Now;
		}

		public Obstacle(double x,double y)
		{
			_x = x;
			_y = y;
		}


		public double X{
			get{ return _x; }
			set{ _x = value; }

		}

		public double Y{
			get{ return _y; }
			set{ _y = value; }

		}


		public virtual bool Collision (PlayerVehicle p) { 
			return SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X, (float)p.Y,1, 1);
		}

		public virtual void Drop (PlayerVehicle p) {
            _curTime = DateTime.Now;
			double prevY = Y;
			if (Y < END) {
               //Error command - generated unexpected Y
               Y += _curTime.Subtract(_prevTime).TotalMilliseconds/1000*Speed;
			}
			_prevTime = _curTime;
		}

		public virtual void Draw () { 
			SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80);
		}

		public double Speed {
			get { return _speed; }
			set { _speed = value; }
		}
		public int LifeCount {
			get;
		}
	}
}


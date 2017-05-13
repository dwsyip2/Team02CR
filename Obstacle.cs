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
		protected int _lifeCount;
		const int END = 610;

		public Obstacle ()
		{
			_y = 20;
            _prevTime = DateTime.Now;
			_curTime = DateTime.Now;
		}

		public Obstacle(double x,double y)
		{
			_x = x;
			_y = y;
			_prevTime = DateTime.Now;
			_curTime = DateTime.Now;
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
			bool cond = SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X - 80, (float)p.Y - 80, 80, 80);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X-80, (float)Y), (float)p.X - 80, (float)p.Y - 80, 80, 80);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y-80), (float)p.X - 80, (float)p.Y - 80, 80, 80);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X-80, (float)Y-80), (float)p.X - 80, (float)p.Y - 80, 80, 80);
			return cond;
		}

		public virtual void Drop (PlayerVehicle p) {
            _curTime = DateTime.Now;
			double prevY = Y;
			if (Y < END) {
               //Error command - generated unexpected Y :SOLVED
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
		public int LifeReward {
			get { return _lifeCount;}
		}
	}
}


using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Obstacle
	{
		protected double _x, _y, _acc, _speedY, _speedX;
		protected Queue<Pattern> _patternQueue;
		const int WIDTH = 60, HEIGHT = 60;
		public DateTime _prevTime;
		public DateTime _curTime;
		protected int _lifeCount;
		const int END = 610;

		public Obstacle ()
		{
			_y = 20;
			ConstructorBaseAction ();
		}

		public Obstacle(double x,double y)
		{
			_x = x;
			_y = y;
			ConstructorBaseAction ();
		}


		public void ConstructorBaseAction ()
		{
			_acc = 0;
			_speedX = 0;
			_patternQueue = new Queue<Pattern> ();
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
			bool cond = SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y), (float)p.X - WIDTH, (float)p.Y - HEIGHT, WIDTH, HEIGHT);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X-WIDTH, (float)Y), (float)p.X - WIDTH, (float)p.Y - HEIGHT, WIDTH, HEIGHT);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X, (float)Y-HEIGHT), (float)p.X - WIDTH, (float)p.Y - HEIGHT, WIDTH, HEIGHT);
			cond |= SwinGame.PointInRect (SwinGame.PointAt ((float)X-WIDTH, (float)Y-HEIGHT), (float)p.X - WIDTH, (float)p.Y - HEIGHT, WIDTH, HEIGHT);
			return cond;
		}

		public virtual void Drop (PlayerVehicle p) {
            _curTime = DateTime.Now;
			double prevY = Y;
			if (Y < END) {
				_speedY += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
				Y += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedY;
			}
			if (PatternQueue.Count > 0) {
				if (Y >= PatternQueue.Peek ().Y) {
					int xDirection = Math.Sign (_patternQueue.Peek ().X - _x);
					SpeedX = 200 * xDirection;
					X += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * SpeedX;
				}
				if (Math.Abs(X-_patternQueue.Peek().X)<0.0000001) _patternQueue.Dequeue ();
			}
			_prevTime = _curTime;
		}

		public virtual void Draw () { 
			SwinGame.DrawRectangle (Color.Transparent, (float)X, (float)Y, 80, 80);
		}

		public double SpeedY {
			get { return _speedY; }
			set { _speedY = value; }
		}

		public double SpeedX {
			get { return _speedX; }
			set { _speedX = value; }
		}

		public int LifeReward {
			get { return _lifeCount;}
		}
		public double Acceleration {
			get { return _acc; }
			set { _acc = value; }
		}
		public Queue<Pattern> PatternQueue {
			get { return _patternQueue; }
			set { _patternQueue = value; }
		}
	}
}


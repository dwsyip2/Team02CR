using System;
using SwinGameSDK;

namespace MyGame
{
	public class PlayerVehicle
	{
		double _x, _y, _acc, _spd;

		public DateTime _prevTime;
		public DateTime _curTime;

		public PlayerVehicle(double x,double y)
		{
			_x = x;
			_y = y;
			_spd = 500;
			_acc = 1000;
			_prevTime = DateTime.Now;
			_curTime = DateTime.Now;
		}

		public void UpdateTime ()
		{
			_prevTime = _curTime;
			_curTime = DateTime.Now;
			_spd = 500;
		}
		public void UpdateSpeed ()
		{
			Speed += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * _acc;
		}
		//Move up
		public void NavigateUp ()
		{
			if (Y > 90) {
				UpdateSpeed ();
				Y -= _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * Speed;
			}
		}

		//Move Down
		public void NavigateDown ()
		{
			if (Y < 480) {
				UpdateSpeed ();
				Y += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * Speed;
			}
		}
		public void NavigateLeft ()
		{
			if (X > 280)
			{
				UpdateSpeed ();
				X -= _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * Speed;
			}
		}

		public void NavigateRight ()
		{
			if (X < 530)
			{
				UpdateSpeed ();
				X += _curTime.Subtract (_prevTime).TotalMilliseconds / 1000 * Speed;
			}
		}
			

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

		public double Speed {
			get { return _spd; }
			set { _spd = value; }
		}

		public double Acceleration {
			get { return _acc; }
			set { _acc = value; }
		}

}
}


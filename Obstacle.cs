using System;

namespace MyGame
{
	public abstract class Obstacle
	{
		//http://stackoverflow.com/questions/34475079/how-to-spawn-two-different-objects-randomly-in-two-specified-positions-in-unity

		private double _x, _y;

		public Obstacle ()
		{
			_y = 20;
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


		public abstract bool Collision(PlayerVehicle p);

		public abstract void Drop ();
		//if (this.Y < 610)				
		//{
		//	this.Y +=2.5;			
		//}
		public abstract void Draw ();
	}
}


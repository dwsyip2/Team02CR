using System;
using SwinGameSDK;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyGame
{
	public class GameBoard
	{
		//==========FIELD============
		private Color _background;
		private readonly List<Obstacle> _obstacles;

		private bool _spawned;

		private static Random _random = new Random ();
		private int _spawnpoints;
		private static Stopwatch s1 = Stopwatch.StartNew(); 


		//==========CONSTRUCTOR==============
		public GameBoard (Color background)
		{
			_obstacles = new List<Obstacle> ();
			_background = background; 

			s1.Reset ();
			s1.Start ();

		}

		public GameBoard(): this (Color.DimGray)
		{}

		//==========METHODS===========
		public void Draw()
		{
			//SwinGame.FillRectangleOnScreen (Color.LightGray, 0, 0, 300, 800);
			//SwinGame.FillRectangleOnScreen (Color.LightGray, 600, 0, 300, 800);
			SwinGame.DrawBitmap ("bg.jpg", 0, 0);
			SwinGame.DrawText ("" + s1.Elapsed.Seconds, Color.White, 300, 300);
		}

		public void GetScore(ScoreBoard s)
		{
			
			foreach (Obstacle c in _obstacles)
			{
				s.Score += 1;
			}
		}

		public bool RandomSpawnVehicle (Car c, ScoreBoard s, PlayerVehicle p)
		{
			while (_spawnpoints == 4)
			{
				_spawnpoints = _random.Next (0, 3);
				if (_spawnpoints == 0)
				{
					c.X = 320;
				}
				else if (_spawnpoints == 1)
				{
					c.X = 415; 
				}
				else if (_spawnpoints == 2)
				{
					c.X = 510; 
				}
			}
				

			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				c.Speed = 5;
				s.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				s.Stage = 3; 
			}else {
				c.Speed = 11;
				s.Stage = 4;
			}


			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				s.Decrement ();
			}
			else if (c.Y >= 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
				return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Lorry c, ScoreBoard s, PlayerVehicle p)
		{
			while (_spawnpoints == 4)
			{
				_spawnpoints = _random.Next (0, 3);
				if (_spawnpoints == 0)
				{
					c.X = 320;
				}
				else if (_spawnpoints == 1)
				{
					c.X = 415; 
				}
				else if (_spawnpoints == 2)
				{
					c.X = 510; 
				}
			}


			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				c.Speed = 5;
				s.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				s.Stage = 3; 
			}
			else {
				c.Speed = 11;
				s.Stage = 4;
			}

			//if (s1.Elapsed.TotalSeconds > 5) 
			//{
			//	c.Speed = 10;
			//	s.Stage = 3;
			//}

			c.Drop ();
			c.Draw ();

			if (c.Collision (p) == true)
			{
				s.Decrement ();
			}
			else if (c.Y >= 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
				return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Motorcycle c, ScoreBoard s, PlayerVehicle p)
		{
			while (_spawnpoints == 4)
			{
				_spawnpoints = _random.Next (0, 3);
				if (_spawnpoints == 0)
				{
					c.X = 320;
				}
				else if (_spawnpoints == 1)
				{
					c.X = 415; 
				}
				else if (_spawnpoints == 2)
				{
					c.X = 510; 
				}
			}


			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40) {
				c.Speed = 5;
				s.Stage = 2;

			} else if (s1.Elapsed.TotalSeconds >= 40 && s1.Elapsed.TotalSeconds <= 60) {
				c.Speed = 10;
				s.Stage = 3;
			} else {
				c.Speed = 11;
				s.Stage = 4;
			}

			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				s.Decrement ();
			}
			else if (c.Y >= 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
				return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Fuel c, ScoreBoard s, PlayerVehicle p)
		{
			while (_spawnpoints == 4)
			{
				_spawnpoints = _random.Next (0, 3);
				if (_spawnpoints == 0)
				{
					c.X = 320;
				}
				else if (_spawnpoints == 1)
				{
					c.X = 415; 
				}
				else if (_spawnpoints == 2)
				{
					c.X = 510; 
				}
			}


			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				c.Speed = 5;
				s.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				s.Stage = 3; 
			}
			else {
				c.Speed = 11;
				s.Stage = 4;
			}

			//if (s1.Elapsed.TotalSeconds > 5) {
			//	c.Speed = 10;
			//	s.Stage = 3;
			//}

			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				s.Increment ();
			}

			if (c.Y >= 600)
			{
				Spawnpoints = 4;
				return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}
			
		public void DisplaySpeed(ScoreBoard s)
		{
			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				s.Traffic = "Mid-Day";
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				s.Traffic = "Night Life";
			}
			else
			{
				s.Traffic = "Peak Hours";
			}
		}
				



		public void ClearScreen()
		{
			_obstacles.Clear();
		}

		public bool GameOver(ScoreBoard s){
			if (s.Life == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void RestartTimer()
		{
			s1.Reset ();
			s1.Start ();
		}

		//===============PROPERTIES======================
		public Color BackgroundColor
		{
			get { return _background; }
			set{_background = value; }
		}

		public List<Obstacle> Obstacles
		{
			get{ return _obstacles;}
		}

		public bool Spawned
		{
			get{ return _spawned;}
			set{ _spawned = value;}
		}

		public int Spawnpoints
		{
			get{return _spawnpoints; }
			set{_spawnpoints = value; }
		}
			

	}
}


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
		public static int numberOfObstacles = 1;
		private static Stopwatch s1 = Stopwatch.StartNew ();


		//==========CONSTRUCTOR==============
		public GameBoard (Color background)
		{
			_obstacles = new List<Obstacle> ();
			_background = background;

			s1.Reset ();
			s1.Start ();
		}

		public GameBoard () : this (Color.DimGray)
		{ }

		//==========METHODS===========
		public void Draw ()
		{
			//SwinGame.FillRectangleOnScreen (Color.LightGray, 0, 0, 300, 800);
			//SwinGame.FillRectangleOnScreen (Color.LightGray, 600, 0, 300, 800);
			SwinGame.DrawBitmap ("bg.jpg", 0, 0);
			SwinGame.DrawText ("" + s1.Elapsed.Seconds, Color.White, 300, 300);
		}
		public void GetScore ()
		{
			foreach (Obstacle c in _obstacles) {
				ScoreBoard.Score += 1;
			}
		}

		public bool RandomSpawnVehicle (Car c, PlayerVehicle p)
		{
			_spawnpoints = _random.Next (0, 3);
			while (_spawnpoints == 4) {
				if (_spawnpoints == 0) {
					c.X = 320;
				} else if (_spawnpoints == 1) {
					c.X = 415;
				} else if (_spawnpoints == 2) {
					c.X = 510;
				}
			}
			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				c.Speed = 5;
				ScoreBoard.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				ScoreBoard.Stage = 3;
			}else {
				c.Speed = 11;
				ScoreBoard.Stage = 4;
			}


			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				ScoreBoard.Decrement ();
			}
			else if (c.Y >= 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
                Obstacles.RemoveAt(Obstacles.Count - 1);
				return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Lorry c, PlayerVehicle p)
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
				ScoreBoard.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				ScoreBoard.Stage = 3; 
			}

			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				ScoreBoard.Decrement ();
			}
			else if (c.Y >= 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
                Obstacles.RemoveAt(Obstacles.Count - 1);
                return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Motorcycle c, PlayerVehicle p)
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
				ScoreBoard.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				ScoreBoard.Stage = 3; 
			} else {
					c.Speed = 11;
					ScoreBoard.Stage = 4;
			}

			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				ScoreBoard.Decrement ();
			}
			else if (c.Y == 570 && c.Collision (p) != true)
			{
				_obstacles.Add (c);
			}


			if (c.Y >= 600)
			{
				Spawnpoints = 4;
                Obstacles.RemoveAt(Obstacles.Count - 1);
                return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}

		public bool RandomSpawnVehicle (Fuel c, PlayerVehicle p)
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
				ScoreBoard.Stage = 2;
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				c.Speed = 10;
				ScoreBoard.Stage = 3; 
			}
			else {
				c.Speed = 11;
				ScoreBoard.Stage = 4;
			}

			//if (s1.Elapsed.TotalSeconds > 5) {
			//	c.Speed = 10;
			//	s.Stage = 3;
			//}

			c.Drop ();
			c.Draw ();


			if (c.Collision (p) == true)
			{
				ScoreBoard.Increment ();
			}

			if (c.Y >= 600)
			{
				Spawnpoints = 4;
                Obstacles.RemoveAt(Obstacles.Count - 1);
                return _spawned = true;
			}
			else
			{
				return _spawned = false;
			}


		}
			
		public void DisplaySpeed()
		{
			if (s1.Elapsed.TotalSeconds > 20 && s1.Elapsed.TotalSeconds <= 40)
			{
				ScoreBoard.Traffic = "Mid-Day";
			}
			else if (s1.Elapsed.TotalSeconds > 40 && s1.Elapsed.TotalSeconds <= 60)
			{
				ScoreBoard.Traffic = "Night Life";
			}
			else
			{
				ScoreBoard.Traffic = "Peak Hours";
			}
		}

		public void ClearScreen()
		{
			_obstacles.Clear();
		}

		public bool GameOver(){
			if (ScoreBoard.Life == 0)
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


		internal void Check ()
		{
			if (GameOver () == true) {
				do {
					SwinGame.ProcessEvents ();
					SwinGame.DrawBitmapOnScreen (new Bitmap ("gameover.jpg"), 0, 0);
					SwinGame.RefreshScreen (60);
					SwinGame.ReleaseBitmap ("gameover.jpg");
				} while (SwinGame.AnyKeyPressed () == false);

				if (SwinGame.KeyTyped (KeyCode.vk_y)) {
					ScoreBoard.Life = 3;
					ScoreBoard.Score = 0;
					RestartTimer ();
				} else if (SwinGame.KeyTyped (KeyCode.vk_n)) {
					do {
						SwinGame.DrawBitmapOnScreen (new Bitmap ("thankyou.jpg"), 0, 0);
						SwinGame.RefreshScreen (60);
						SwinGame.ReleaseBitmap ("thankyou.jpg");
					} while (false == SwinGame.WindowCloseRequested ());
				}
			}
		}

		public bool ObstacleCondition ()
		{
			if (_obstacles.Count <= 1)
				return true;
			else
				return false;
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


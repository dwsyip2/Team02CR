using System;
using SwinGameSDK;
using System.Collections.Generic;
namespace MyGame
{
	public class GameController: Page
	{
		GameBoard gameBoard;
		PlayerVehicle p;
		//List<Obstacle> obstacles = new List<Obstacle>();

		public const int startLane1X = 320;
		public const int startLane2X = 415;
		public const int startLane3X = 510;
		public const int startLaneY = 20;

		public GameController ()
		{
			gameBoard = new GameBoard ();
			ScoreBoard.Initialize (0, 3, 1, "Peak Hours");
			gameBoard.Draw ();
			p = new PlayerVehicle (415, 570);
		}

		public override void DrawPage ()
		{
			gameBoard.Draw ();
			p.Draw ();
			foreach (Obstacle o in gameBoard.Obstacles) {
				o.Draw ();
			}
		}

		void AddObstacle ()
		{
			if (!gameBoard.ObstacleCondition ())
				return;
			Random _random = new Random ();
			int _chance = _random.Next (0, 10);

			if (_chance == 0 || _chance == 1 || _chance == 2) {
				gameBoard.RandomSpawnVehicle (new Car (startLane2X, startLaneY));
			} else if (_chance == 3 || _chance == 4 || _chance == 5) {
				gameBoard.RandomSpawnVehicle (new Lorry (startLane2X, startLaneY));
			} else if (_chance == 6 || _chance == 7 || _chance == 8) {
				gameBoard.RandomSpawnVehicle (new Motorcycle (startLane2X, startLaneY));
			} else if (_chance == 9) {
				gameBoard.RandomSpawnVehicle (new Fuel (startLane2X, startLaneY));
			}
		}

		void UpdateList ()
		{
			SwinGame.DrawText ("Score:" + ScoreBoard.Score.ToString (), Color.Black, 10, 100);
			SwinGame.DrawText ("Life:" + ScoreBoard.Life.ToString (), Color.Black, 10, 150);
			SwinGame.DrawText ("Stage:" + ScoreBoard.Stage.ToString (), Color.Black, 10, 200);
			SwinGame.DrawText ("Speed:" + ScoreBoard.Traffic.ToString (), Color.Black, 10, 350);
			SwinGame.DrawText ("Right Arrow key to move right", Color.Black, 10, 250);
			SwinGame.DrawText ("Left Arrow key to move left", Color.Black, 10, 300);
			SwinGame.DrawText ("PosY:" + gameBoard.Obstacles[0].Y.ToString (), Color.Black, 10, 400);
		}

		public override void Execute ()
		{
			DrawPage ();
			AddObstacle ();
			gameBoard.MoveObstacle (p);
			UpdateList ();
			gameBoard.GetScore ();
			HandleInput ();
			gameBoard.DisplaySpeed ();
			gameBoard.Check ();
		}

		public override void HandleInput ()
		{
			if (SwinGame.KeyTyped (KeyCode.vk_LEFT))
				p.NavigateLeft ();
			else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT))
				p.NavigateRight ();
			else if (SwinGame.KeyTyped (KeyCode.vk_UP))
				p.NavigateUp ();
			else if (SwinGame.KeyTyped (KeyCode.vk_DOWN))
				p.NavigateDown ();
            else if (SwinGame.KeyTyped(KeyCode.vk_ESCAPE))
                UtilityFunction.gameStateStack.Pop();
		}
	}
}

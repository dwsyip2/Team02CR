using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 900, 650);
			GameResources.LoadResources ();
			MainMenuController myMenu = new MainMenuController ();
            GameController myGame = new GameController();
			UtilityFunction.gameStateStack.Push (GameState.ViewingMainPage);
			Page page = myMenu;
			//GameBoard gb = new GameBoard ();
			//ObstacleType obstacleToAdd = ObstacleType.Car;
			//PlayerVehicle p = new PlayerVehicle (415, 570);
			//ScoreBoard.Initialize(0, 3, 1, "Peak Hours");

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				SwinGame.ProcessEvents ();
				SwinGame.ClearScreen (Color.White);
				GameState curPage = UtilityFunction.gameStateStack.Peek();
				switch (curPage) {
					case GameState.ViewingMainPage:
						page = myMenu;
                        myGame = new GameController();//clear game status
						break;
					case GameState.ViewingGamePage:
                        page = myGame;
						break;
					default:
						page = new MainMenuController();
						break;
				}
				page.Execute ();
				SwinGame.RefreshScreen (60);

				//Random _random = new Random();
				//int _chance= _random.Next(0,10);
				//Car c = new Car (415, 20);
				//Lorry l = new Lorry (415, 20);
				//Motorcycle m = new Motorcycle (415, 20);
				//Fuel f = new Fuel (415, 20);

    //            SwinGame.ProcessEvents();
    //            SwinGame.ClearScreen(Color.White);

				//gb.Draw ();
				//gb.Spawned = false;

				//while (gb.Spawned == false)
				//{
				//	//Fetch the next batch of UI interaction
				//	SwinGame.ProcessEvents();

				//	//Clear the screen and draw the framerate
				//	//SwinGame.ClearScreen(Color.White);
				//	gb.Draw ();

				//	if (obstacleToAdd == ObstacleType.Car)
				//	{
				//		gb.RandomSpawnVehicle (c, p);
				//	}
				//	else if (obstacleToAdd == ObstacleType.Lorry)
				//	{
				//		gb.RandomSpawnVehicle (l, p);
				//	}
				//	else if (obstacleToAdd == ObstacleType.Motorcycle)
				//	{
				//		gb.RandomSpawnVehicle (m, p);
				//	}
				//	else if (obstacleToAdd == ObstacleType.Fuel)
				//	{
				//		gb.RandomSpawnVehicle (f, p);
				//	}

				//	if (SwinGame.KeyTyped (KeyCode.vk_LEFT))
				//		p.NavigateLeft ();
				//	else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT))
				//		p.NavigateRight ();	
				//	p.Draw ();

				//	SwinGame.DrawText ("Score:"+ ScoreBoard.Score.ToString(), Color.Black, 10, 100);
				//	SwinGame.DrawText ("Life:"+ScoreBoard.Life.ToString(), Color.Black, 10, 150);
				//	SwinGame.DrawText ("Stage:" +ScoreBoard.Stage.ToString(), Color.Black, 10, 200);
				//	SwinGame.DrawText ("Speed:" +ScoreBoard.Traffic.ToString(), Color.Black, 10, 350);
				//	SwinGame.DrawText ("Right Arrow key to move right", Color.Black, 10, 250);
				//	SwinGame.DrawText ("Left Arrow key to move left", Color.Black, 10, 300);
				//	SwinGame.DrawFramerate(0,0);
				//}

				//SwinGame.RefreshScreen (60);

				//gb.GetScore ();
				//gb.ClearScreen ();
				//gb.DisplaySpeed ();
				//if (gb.GameOver () == true)
				//{
				//	do
				//	{
				//		SwinGame.ProcessEvents();
				//		SwinGame.DrawBitmapOnScreen (new Bitmap ("gameover.jpg"), 0, 0);
				//		SwinGame.RefreshScreen (60); 
				//		SwinGame.ReleaseBitmap ("gameover.jpg");
				//	} while (SwinGame.AnyKeyPressed () == false);
				//	//}while (!(SwinGame.KeyTyped (KeyCode.vk_y)) || !(SwinGame.KeyTyped (KeyCode.vk_n)) );

				//	if (SwinGame.KeyTyped (KeyCode.vk_y))
				//	{
				//		ScoreBoard.Life = 3; 
				//		ScoreBoard.Score = 0;
				//		gb.RestartTimer ();
				//	}
				//	else if (SwinGame.KeyTyped (KeyCode.vk_n))
				//	{
				//		do
				//		{
				//			SwinGame.DrawBitmapOnScreen(new Bitmap("thankyou.jpg"), 0, 0);
				//			SwinGame.RefreshScreen (60);
				//			SwinGame.ReleaseBitmap("thankyou.jpg");
				//		} while (false == SwinGame.WindowCloseRequested());
				//	}


				}

				SwinGame.DrawFramerate(0,0);

				//Draw onto the screen
				SwinGame.RefreshScreen(60);
        }
    }
}
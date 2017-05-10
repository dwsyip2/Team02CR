using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
		private enum ObstacleType
		{
			Car,
			Lorry,
			Motorcycle,
			Fuel
		}
        public static void Main()
        {
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 900, 650);
            

			GameBoard gb = new GameBoard ();
			gb.BackgroundColor = SwinGame.RandomRGBColor (255);
			ObstacleType obstacleToAdd = ObstacleType.Car;
			PlayerVehicle p = new PlayerVehicle (415, 570);
			ScoreBoard s = new ScoreBoard (0, 3, 1, "Peak Hours");

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
				Random _random = new Random();
				int _chance= _random.Next(0,10);
				Car c = new Car (415, 20);
				Lorry l = new Lorry (415, 20);
				Motorcycle m = new Motorcycle (415, 20);
				Fuel f = new Fuel (415, 20);



				if (_chance == 0 || _chance == 1 || _chance == 2)
				{

					obstacleToAdd = ObstacleType.Car;

				}
				else if (_chance == 3 || _chance == 4 || _chance == 5)
				{
					obstacleToAdd = ObstacleType.Lorry;

				}
				else if (_chance == 6 || _chance == 7 || _chance == 8)
				{
					obstacleToAdd = ObstacleType.Motorcycle;

				}
				else if (_chance == 9)
				{
					obstacleToAdd = ObstacleType.Fuel;
				}
                SwinGame.ProcessEvents();
                SwinGame.ClearScreen(Color.White);

				gb.Draw ();
				gb.Spawned = false;


				while (gb.Spawned == false)
				{
					//Fetch the next batch of UI interaction
					SwinGame.ProcessEvents();

					//Clear the screen and draw the framerate
					SwinGame.ClearScreen(Color.White);
					gb.Draw ();

					if (obstacleToAdd == ObstacleType.Car)
					{
						gb.RandomSpawnVehicle (c, s, p);
					}
					else if (obstacleToAdd == ObstacleType.Lorry)
					{
						gb.RandomSpawnVehicle (l, s, p);
					}
					else if (obstacleToAdd == ObstacleType.Motorcycle)
					{
						gb.RandomSpawnVehicle (m, s, p);
					}
					else if (obstacleToAdd == ObstacleType.Fuel)
					{
						gb.RandomSpawnVehicle (f, s, p);
					}

					if (SwinGame.KeyTyped (KeyCode.vk_LEFT))
						p.NavigateLeft ();
					else if (SwinGame.KeyTyped (KeyCode.vk_RIGHT))
						p.NavigateRight ();	
					p.Draw ();

					SwinGame.DrawText ("Score:"+ s.Score.ToString(), Color.Black, 10, 100);
					SwinGame.DrawText ("Life:"+s.Life.ToString(), Color.Black, 10, 150);
					SwinGame.DrawText ("Stage:" +s.Stage.ToString(), Color.Black, 10, 200);
					SwinGame.DrawText ("Speed:" +s.Traffic.ToString(), Color.Black, 10, 350);
					SwinGame.DrawText ("Right Arrow key to move right", Color.Black, 10, 250);
					SwinGame.DrawText ("Left Arrow key to move left", Color.Black, 10, 300);
					SwinGame.DrawFramerate(0,0);

					//Draw onto the screen
					SwinGame.RefreshScreen(60);
				}

				gb.GetScore (s);
				gb.ClearScreen ();
				gb.DisplaySpeed (s);
				if (gb.GameOver (s) == true)
				{
//					
//					if (SwinGame.KeyTyped (KeyCode.vk_y))
//					{
//						SwinGame.ClearScreen();
//						s.Life = 3; 
//						s.Score = 0;
//					}
//					else if (SwinGame.KeyTyped (KeyCode.vk_n))
//					{
//						do
//						{
//							SwinGame.DrawBitmapOnScreen (new Bitmap("thankyou.jpg"), 0, 0);
//							SwinGame.RefreshScreen (60);
//							SwinGame.ReleaseBitmap("thankyou.jpg");
//						} while (false == SwinGame.WindowCloseRequested ());
//					}
//					else
//					{
//							do
//							{
//							SwinGame.DrawBitmapOnScreen(new Bitmap("gameover.jpg"), 0, 0);
//								SwinGame.RefreshScreen (25);
//							SwinGame.ReleaseBitmap("gameover.jpg");
//							} while (false == SwinGame.WindowCloseRequested());
//					}

					do
					{
						SwinGame.ProcessEvents();
						SwinGame.DrawBitmapOnScreen (new Bitmap ("gameover.jpg"), 0, 0);
						SwinGame.RefreshScreen (60); 
						SwinGame.ReleaseBitmap ("gameover.jpg");
					} while (SwinGame.AnyKeyPressed () == false);
					//}while (!(SwinGame.KeyTyped (KeyCode.vk_y)) || !(SwinGame.KeyTyped (KeyCode.vk_n)) );

					if (SwinGame.KeyTyped (KeyCode.vk_y))
					{
						s.Life = 3; 
						s.Score = 0;
						gb.RestartTimer ();
					}
					else if (SwinGame.KeyTyped (KeyCode.vk_n))
					{
						do
						{
							SwinGame.DrawBitmapOnScreen(new Bitmap("thankyou.jpg"), 0, 0);
							SwinGame.RefreshScreen (60);
							SwinGame.ReleaseBitmap("thankyou.jpg");
						} while (false == SwinGame.WindowCloseRequested());
					}


				}

				SwinGame.DrawFramerate(0,0);

				//Draw onto the screen
				SwinGame.RefreshScreen(60);
                
            }

        }
    }
}
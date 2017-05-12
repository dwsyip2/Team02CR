using System;
namespace MyGame
{
	public abstract class Page
	{
		public abstract void DrawPage ();
		public abstract void HandleInput ();
		public abstract void Execute ();
	}
}

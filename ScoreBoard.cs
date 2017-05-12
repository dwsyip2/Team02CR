using System;
using SwinGameSDK;
using System.Diagnostics;

namespace MyGame
{
	public class ScoreBoard
	{
		private int _score, _stage;
		private int _life;
		private string _traffic;


		public ScoreBoard (int score, int life, int stage, string traffic)
		{
			_score = score;
			_life = life;
			_stage = stage;
			_traffic = traffic;
		}

		public void Increment()
		{
			_life++;
		}

		public void Decrement()
		{
			_life--;
		}

		public void NextStage()
		{
			_stage++;
		}
			
		public string Traffic
		{
			get{ return _traffic;}
			set{ _traffic = value;}
		}

		public int Score
		{
			get{ return _score;}
			set{ _score = value;}
		}

		public int Life
		{
			get{ return _life;}
			set{ _life = value;}
		}

		public int Stage
		{
			get{ return _stage;}
			set{ _stage = value;}
		}
	}
}


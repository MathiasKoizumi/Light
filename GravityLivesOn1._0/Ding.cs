using System;
using System.Drawing;
using System.Reflection;

namespace GravityLivesOn1._0
{
	internal class Ding
	{
		public double størrelse = 45.0;

		public int masse;

		public float particles;

		public Color farve;

		public float positionX;

		public float positionY;

		public float positionZ;

		public float hastighedX = 5f;

		public float hastighedY = 5f;

		public float hastighedZ = 5f;

		public int alder;

		public int vinkel;

		public Random rand = new Random();

		public Ding(int speed, int massen, int color, int size, Form1 form1, Affector a)
		{
			størrelse = size;
			hastighedX = rand.Next(speed);
			hastighedY = rand.Next(speed);
			hastighedZ = rand.Next(speed);
			positionX = rand.Next(1920);
			positionY = rand.Next(1080);
			positionZ = rand.Next(500);
			Assembly.GetExecutingAssembly();
			if (rand.Next(2) == 0)
			{
				masse = massen;
			}
			particles = (float)((double)massen * størrelse + (double)masse * størrelse);
			alder = 0;
			vinkel = rand.Next(1, 360);
			farve = Color.FromArgb(rand.Next(color), rand.Next(color), rand.Next(color), rand.Next(color));
		}

		public Ding()
		{
		}
	}
}

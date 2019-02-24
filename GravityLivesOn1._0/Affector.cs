using System;
using System.Drawing;

namespace GravityLivesOn1._0
{
	internal class Affector
	{
		public Point start;

		public Point end;

		public double speed;

		public Point destination;

		public Affector(Point startpoint, Point endpoint)
		{
			start = startpoint;
			end = endpoint;
			int num = (int)(Math.Pow(startpoint.X - endpoint.X, 2.0) + Math.Pow(startpoint.Y - endpoint.Y, 2.0));
			speed = Math.Sqrt(num) / 4000.0;
			destination = new Point((int)((double)(start.X - end.X) * speed), (int)((double)(start.Y - end.Y) * speed));
		}
	}
}

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;

namespace GravityLivesOn1._0
{
	public class Form1 : Form
	{
		private Random rand;

		private Ding[] objekter;

		private Graphics g;

		private Bitmap bitmap;

		private Affector affector;

		private Graphics graphics;

		private Image image5;

		private IContainer components;

		private Panel panel1;

		public Form1()
		{
			rand = new Random();
			getAffector();
			InitializeComponent();
			designObjekter(200, 25, affector);
			g = panel1.CreateGraphics();
			bitmap = new Bitmap(1920, 1080, PixelFormat.Format32bppArgb);
			graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.FromArgb(rand.Next(255), rand.Next(180, 255), rand.Next(180, 255), rand.Next(180, 255)));
			image5 = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("GravityLivesOn1._0.car.jpg"));
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void DrawPaintMe()
		{
			Bitmap image = new Bitmap(bitmap.Width, bitmap.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics = Graphics.FromImage(image);
			rand.NextDouble();
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(bitmap, 0, 0);
			for (int i = 0; i < objekter.Length; i++)
			{
				graphics.FillEllipse(new SolidBrush(objekter[i].farve), objekter[i].positionX, objekter[i].positionY, (int)objekter[i].størrelse, (int)objekter[i].størrelse);
			}
			graphics.DrawLine(new Pen(Brushes.Gray), affector.start, affector.end);
			Point location = new Point(affector.end.X - 5, affector.end.Y - 5);
			Point location2 = new Point(affector.start.X - 5, affector.start.Y - 5);
			graphics.DrawRectangle(new Pen(Brushes.LightGray), new Rectangle(location, new Size(10, 10)));
			graphics.DrawEllipse(new Pen(Brushes.Gray), new Rectangle(location2, new Size(10, 10)));
			graphics.Save();
			g.DrawImage(image, 0, 0);
			animate();
		}

		private void animate()
		{
			int maxValue = rand.Next(45);
			for (int i = 0; i < objekter.Length; i++)
			{
				objekter[i].positionX = objekter[i].positionX + objekter[i].hastighedX + (float)affector.destination.X;
				objekter[i].positionY = objekter[i].positionY + objekter[i].hastighedY + (float)affector.destination.Y;
				objekter[i].positionZ = objekter[i].positionZ + objekter[i].hastighedZ;
				switch (rand.Next(2))
				{
				case 0:
					objekter[i].hastighedX = rand.Next(maxValue);
					objekter[i].hastighedY = rand.Next(maxValue);
					objekter[i].hastighedZ = rand.Next(maxValue);
					break;
				case 1:
					objekter[i].hastighedX = 0f - (float)rand.Next(maxValue);
					objekter[i].hastighedY = 0f - (float)rand.Next(maxValue);
					objekter[i].hastighedZ = 0f - (float)rand.Next(maxValue);
					break;
				}
				switch (rand.Next(2))
				{
				case 0:
					objekter[i].størrelse = objekter[i].størrelse + (double)rand.Next(10);
					break;
				case 1:
					objekter[i].størrelse = objekter[i].størrelse - (double)rand.Next(10);
					break;
				}
			}
		}

		private void getAffector()
		{
			affector = new Affector(new Point(rand.Next(200, 600), rand.Next(200, 600)), new Point(rand.Next(200, 600), rand.Next(200, 600)));
		}

		private void designObjekter(int number, int speed, Affector aff)
		{
			affector = aff;
			objekter = new Ding[number];
			for (int i = 0; i < number; i++)
			{
				Ding ding = new Ding(rand.Next(speed), rand.Next(100), rand.Next(200), rand.Next(30), this, affector);
				objekter[i] = ding;
			}
		}

		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
			clickMe();
		}

		private void clickMe()
		{
			for (int i = 0; i < 10; i++)
			{
				if (rand.Next(2) == 0)
				{
					designObjekter(rand.Next(5000), rand.Next(55), affector);
				}
				if (rand.Next(2) == 0)
				{
					getAffector();
				}
				for (int j = 0; j < rand.Next(400); j++)
				{
					DrawPaintMe();
				}
				if (rand.Next(2) == 0)
				{
					this.graphics.Clear(Color.FromArgb(rand.Next(255), rand.Next(180, 255), rand.Next(180, 255), rand.Next(180, 255)));
				}
			}
			Bitmap image = new Bitmap(bitmap.Width, bitmap.Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.DrawImage(bitmap, 0, 0);
			graphics.DrawString("Click me!!", new Font("Verdana", 32f, FontStyle.Bold), Brushes.White, new PointF(200f, 900f));
			graphics.Save();
			g.DrawImage(image, 0, 0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			panel1 = new System.Windows.Forms.Panel();
			SuspendLayout();
			panel1.AutoSize = true;
			panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1920, 1080);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(panel1_MouseClick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1920, 1080);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "Form1";
			Text = "Gravity v2.0";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}

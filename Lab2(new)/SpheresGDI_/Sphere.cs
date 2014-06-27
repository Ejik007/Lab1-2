using System;
using System.Drawing;

namespace Spheres
{
	/// <summary>
	/// Sphere.
	/// </summary>
	public class Sphere : Shape
	{

		private double radius;
		private Color color;
		private double leftSquare;
		private double upperSquare;

		/// <summary>
		/// Sphere constructor
		/// </summary>
		/// <param name="g">GridView object to manage conversions</param>
		/// <param name="r">Radius (in logical units)</param>
		/// <param name="cX">X coordinate of center (logical units)</param>
		/// <param name="cY">Y coordinate of center (logical units)</param>
		public Sphere(GridView g, double r, double cX, double cY) : base(g)
		{
			this.radius=r;
			//Squared
			this.leftSquare=cX-r;
			this.upperSquare=cY-r;
			this.color=Color.Yellow; // default
		}

		/// <summary>
		/// Radius
		/// </summary>
		public double Radius
		{
			get
			{
				return this.radius;
			}

			set
			{
				this.radius=value;
			}
		}

		/// <summary>
		/// Color
		/// </summary>
		public Color SphereColor
		{
			get
			{
				return this.color;
			}
			set
			{
				this.color=value;
			}
		}

		/// <summary>
		/// Paint sphere onto the give Graphics object
		/// </summary>
		/// <param name="g">Graphics object onto which painting the sphere</param>
		/// <param name="c">Color</param>
		public void paint(Graphics g)
		{
			Pen color = new Pen(this.color,0.8F);
			int leftPoint = this.gv.getPhysicalX(this.leftSquare);
			int upperPoint = this.gv.getPhysicalY(this.upperSquare);
            //#div 
			int sizeX = this.gv.getPhysicalWidth(this.radius*2);
			int sizeY = this.gv.getPhysicalHeight(this.radius*2);
            //int sizeX = (int)this.radius * 2;
            //int sizeY = (int)this.radius * 2;
            
			Rectangle square = new Rectangle(leftPoint,upperPoint,sizeX,sizeY);
			Console.WriteLine("Painting new sphere: center({0},{1}) - radius:{2}",leftPoint+sizeX/2,upperPoint+sizeY/2,sizeX/2);
			this.drawArcs(g,color,square);
		}

		private void drawArcs(Graphics g, Pen color, Rectangle r)
		{
			
			// axis
			int x1=r.Left+r.Width/2;
			int y1=r.Top;
			int x2=x1;
			int y2=r.Top+r.Height;

			int x3=r.Left;
			int y3=r.Top+r.Height/2;
			int x4=r.Left+r.Width;
			int y4=y3;

			g.DrawLine(color,x1,y1,x2,y2);
			g.DrawLine(color,x3,y3,x4,y4);

			// right-left
			for (int j=r.Width; j>0; j-=10)
			{
				int left = r.Left+(r.Width-j)/2;
				Rectangle rc = new Rectangle(left,r.Top,j,r.Height);
				g.DrawArc(color,rc,0.0F,180.0F);
				g.DrawArc(color,rc,180.0F,360.0F);
			}
			// top-bottom
			for (int j=r.Height; j>0; j-=10)
			{
				int top = r.Top+(r.Height-j)/2;
				Rectangle rc = new Rectangle(r.Left,top,r.Width,j);
				g.DrawArc(color,rc,270.0F,450.0F);
				g.DrawArc(color,rc,90.0F,270.0F);
			}

		}

	}
}

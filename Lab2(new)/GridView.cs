namespace DrawingFigures
{
	/// <summary>
	/// The gridview is a utility class that, given wanted x and y size in 
	/// logical units (ie: size x = 5 units, size y = 3 units), and the physical
	/// size of the viewport in pixel, return all the conversions between the two of them.
	/// </summary>
	public class GridView
	{

		private int pX; // width (x) size in pixels
		private int pY; // height (y) size in pixels

		private double uX; // x size in Units (u)
		private double uY; // y size in Units

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="logicalW">Width in logical units (ie:5)</param>
		/// <param name="physicalW">Width in physical units (ie: 640 pixel)</param>
		/// <param name="physicalH">Height in physical units</param>
		public GridView(double logicalW, int physicalW, int physicalH)
		{
			this.uX=logicalW;
			this.pX=physicalW;
			this.pY=physicalH;
			// The logical height can be obtained:
			this.uY=physicalH*(this.uX/this.pX);
		}

		/// <summary>
		/// Returns the distance of 1 pixel x in logical units
		/// </summary>
		/// <returns>The distance of 1 pixel x in logical units</returns>
		public double stepX
		{
			get
			{
				return (this.uX/this.pX);
			}
		}

		/// <summary>
		/// Returns the distance of 1 pixel y in logical units
		/// </summary>
		/// <returns>The distance of 1 pixel y in logical units</returns>
		public double stepY
		{
			get
			{
				return (this.uY/this.pY);
			}
		}

		/// <summary>
		/// The position (in logical units) of the x coordinate in pixel
		/// </summary>
		/// <param name="physicalX">x coordinate in pixel</param>
		/// <returns>x coordinate in logical units</returns>
		public double getLogicalX(int physicalX)
		{
			double x = ((double)physicalX/(double)this.pX)*this.uX;
			return x;
		}

		/// <summary>
		/// The position (in logical units) of the y coordinate in pixel
		/// </summary>
		/// <param name="physicalY">y coordinate in pixel</param>
		/// <returns>y coordinate in logical units</returns>
		public double getLogicalY(int physicalY)
		{
			double y = ((double)physicalY/(double)this.pY)*this.uY;
			return y;
		}

		/// <summary>
		/// The width in logical units of the whole viewport.
		/// </summary>
		/// <returns>The width in logical units of the whole viewport</returns>
		public double getLogicalWidth()
		{
			return this.uX;
		}

		/// <summary>
		/// Get a width in pixel into the corresponding width in logical units
		/// </summary>
		/// <param name="physicalWidth">width in pixel</param>
		/// <returns>width in logical units</returns>
		public double getLogicalWidth(int physicalWidth)
		{
			return (physicalWidth*this.stepX);
		}

		/// <summary>
		/// Get height of the gridview in logical units 
		/// </summary>
		/// <returns>Height of the gridview in logical units </returns>
		public double getLogicalHeight()
		{
			return this.uY;
		}

		/// <summary>
		/// Given an height in pixel, returns the corresponding height in logical units
		/// </summary>
		/// <param name="physicalHeight">Height in pixel</param>
		/// <returns>Height in logical units</returns>
		public double getLogicalHeight(int physicalHeight)
		{
			return (physicalHeight*this.stepY);
		}

		/// <summary>
		/// Returns the width in pixel of a width in logical units.
		/// </summary>
		/// <param name="logicalWidth">Width in logical units</param>
		/// <returns>Width in pixel</returns>
		public int getPhysicalWidth(double logicalWidth)
		{
			return (int)(logicalWidth/this.stepX);
		}

		/// <summary>
		/// Returns the height in pixel of a height in logical units.
		/// </summary>
		/// <param name="logicalHeight">Height in logical units</param>
		/// <returns>Height in physical units</returns>
		public int getPhysicalHeight(double logicalHeight)
		{
			return (int)(logicalHeight/this.stepY);
		}

		/// <summary>
		/// Get X coordinate in pixel from an X coordinate in logical units
		/// </summary>
		/// <param name="logicalX">X coordinate in logical units</param>
		/// <returns>X coordinate in pixel</returns>
		public int getPhysicalX(double logicalX)
		{
			return (int)((logicalX*this.pX)/this.uX);
		}

		/// <summary>
		/// Get Y coordinate in pixel from an Y coordinate in logical units
		/// </summary>
		/// <param name="logicalX">Y coordinate in logical units</param>
		/// <returns>Y coordinate in pixel</returns>
		public int getPhysicalY(double logicalY)
		{
			return (int)((logicalY*this.pY)/this.uY);
		}


	}
}

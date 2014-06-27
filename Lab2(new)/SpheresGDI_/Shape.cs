using System;

namespace Spheres
{
	/// <summary>
	/// Shape.
	/// </summary>
	public abstract class Shape
	{
		protected GridView gv; // manages conversions between logical units and pixels

		/// <summary>
		/// Shape constructor
		/// </summary>
		/// <param name="v">Gridview object to manage conversions</param>
		public Shape(GridView v)
		{
			this.gv=v;
		}
	}
}

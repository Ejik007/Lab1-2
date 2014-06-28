using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DrawingFigures
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class FrmMain : System.Windows.Forms.Form
	{

		// WinForm Components
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.Button btnDraw;
		private System.Windows.Forms.TextBox txtX;
		private System.Windows.Forms.TextBox txtY;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtColor;
		private System.Windows.Forms.TrackBar trackBar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRadius;
		private System.Windows.Forms.Button btnChooseColor;

		// Business
		private GridView gv;
		private bool centerDecided=false;
		private double centerX, centerY;
		private ArrayList spheres;
		private System.Windows.Forms.Button btnErase;
		private Graphics panelGraphics;


		
		/// <summary>
		/// WinForm constructor
		/// </summary>
		public FrmMain()
		{
			InitializeComponent();
			int lenX = this.panel.Width;
			int lenY = this.panel.Height;
			gv = new GridView(5.0,lenX,lenY);
			spheres = new ArrayList();
			panelGraphics = this.panel.CreateGraphics();
		}
        private double _radius = 1;
        /// <summary>
        /// Радиу в условных единица 1-2, double
        /// </summary>
        /// <param name="radius"></param>
        public FrmMain(double radius)
        {
            _radius = radius;
            InitializeComponent();
            int lenX = this.panel.Width;
            int lenY = this.panel.Height;
            gv = new GridView(5.0, lenX, lenY);
            spheres = new ArrayList();
            panelGraphics = this.panel.CreateGraphics();
            this.centerX = 2;
            this.centerY = 2;
            btnDraw_Click(null, null);
        }

		/// <summary>
		/// WinForm destructor
		/// </summary>
		~FrmMain()
		{
			this.panelGraphics.Dispose();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel = new System.Windows.Forms.Panel();
            this.btnDraw = new System.Windows.Forms.Button();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnErase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Navy;
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel.Location = new System.Drawing.Point(8, 8);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(350, 350);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // btnDraw
            // 
            this.btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDraw.Location = new System.Drawing.Point(368, 288);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(112, 40);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Draw";
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // txtX
            // 
            this.txtX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtX.Location = new System.Drawing.Point(392, 64);
            this.txtX.Name = "txtX";
            this.txtX.ReadOnly = true;
            this.txtX.Size = new System.Drawing.Size(56, 20);
            this.txtX.TabIndex = 2;
            this.txtX.Text = "0";
            this.txtX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtY
            // 
            this.txtY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtY.Location = new System.Drawing.Point(392, 36);
            this.txtY.Name = "txtY";
            this.txtY.ReadOnly = true;
            this.txtY.Size = new System.Drawing.Size(56, 20);
            this.txtY.TabIndex = 3;
            this.txtY.Text = "0";
            this.txtY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(400, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Center";
            // 
            // txtColor
            // 
            this.txtColor.BackColor = System.Drawing.Color.Yellow;
            this.txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColor.Location = new System.Drawing.Point(392, 120);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(28, 20);
            this.txtColor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(400, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Color";
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChooseColor.Location = new System.Drawing.Point(424, 120);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(24, 20);
            this.btnChooseColor.TabIndex = 7;
            this.btnChooseColor.Text = "...";
            this.btnChooseColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(380, 212);
            this.trackBar.Maximum = 20;
            this.trackBar.Minimum = 1;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(80, 45);
            this.trackBar.TabIndex = 8;
            this.trackBar.TabStop = false;
            this.trackBar.TickFrequency = 2;
            this.trackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBar.Value = 10;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // txtRadius
            // 
            this.txtRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRadius.Location = new System.Drawing.Point(392, 184);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.ReadOnly = true;
            this.txtRadius.Size = new System.Drawing.Size(56, 20);
            this.txtRadius.TabIndex = 9;
            this.txtRadius.Text = "1";
            this.txtRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(400, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Radius";
            // 
            // btnErase
            // 
            this.btnErase.Location = new System.Drawing.Point(368, 336);
            this.btnErase.Name = "btnErase";
            this.btnErase.Size = new System.Drawing.Size(112, 20);
            this.btnErase.TabIndex = 11;
            this.btnErase.Text = "Erase";
            this.btnErase.Click += new System.EventHandler(this.btnErase_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(334, 312);
            this.Controls.Add(this.btnErase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.btnChooseColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.panel);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 350);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "FrmMain";
            this.Text = "Spheres";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void panel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!this.centerDecided)
			{
				this.centerX = gv.getLogicalX(e.X);
				this.centerY = gv.getLogicalY(e.Y);
				this.txtX.Text=String.Format("{0:#.####}",this.centerX);
				this.txtY.Text=String.Format("{0:#.####}",this.centerY);
			}
		}

		private void panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.centerDecided=!this.centerDecided;
		}

		private void btnDraw_Click(object sender, System.EventArgs e)
		{
			double r=Double.Parse(_radius.ToString());

			Sphere s1 = new Sphere(gv,r,this.centerX,this.centerY);
			s1.SphereColor=this.txtColor.BackColor;
			s1.paint(panelGraphics);
			this.spheres.Add(s1);

			this.centerDecided=false;
		}

		private void btnColor_Click(object sender, System.EventArgs e)
		{
			if (this.colorDialog1.ShowDialog(this)==DialogResult.OK)
			{
				this.txtColor.BackColor=this.colorDialog1.Color;
			}
		}

		private void trackBar_Scroll(object sender, System.EventArgs e)
		{
			this.txtRadius.Text=String.Format("{0:#.#}",this.trackBar.Value*0.1);
		}

		private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			foreach (Sphere s in this.spheres)
			{
				s.paint(panelGraphics);
			}
		}

		private void btnErase_Click(object sender, System.EventArgs e)
		{
			this.spheres.Clear();
			this.panelGraphics.Clear(this.panel.BackColor);
		}
	}
}

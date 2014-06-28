using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace DrawingFigures
{
    public enum FigureType
    {
        square,
        rectangle, 
        round
    }
    public partial class frmFlat : Form
    {
        private FigureType _figureType;
        private int _side;
        private int _h;
        private int _w;

        public frmFlat()
        {
            InitializeComponent();
        }
        public frmFlat(FigureType type,int side,int w=0,int h=0)
        {
            InitializeComponent();

            _side = side;
            _figureType= type;
            _w = w;
            _h = h;
            switch (_figureType) {
                case FigureType.square: this.Text ="Квадрат"; break;
                case FigureType.round: this.Text ="Круг"; break;
                case FigureType.rectangle: this.Text = "Прямоугольник"; break;
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            if (_figureType == FigureType.square)
            {
                Graphics g = pe.Graphics;
                Rectangle rect = new Rectangle(50, 30, _side, _side);
                LinearGradientBrush lBrush = new LinearGradientBrush(rect, Color.Gray, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(lBrush, rect);
            }
            if (_figureType == FigureType.round)
            {
                Graphics g = pe.Graphics;
                Pen pn = new Pen(Color.Blue, 2* _side);
                Rectangle rect = new Rectangle(50, 50, 2*_side,2*_side);
                g.DrawEllipse(pn, rect); 
            }
            if (_figureType == FigureType.rectangle)
            {
                Graphics g = pe.Graphics;
                Rectangle rect = new Rectangle(50, 30, _w, _h);
                LinearGradientBrush lBrush = new LinearGradientBrush(rect, Color.Gray, Color.Gray, LinearGradientMode.BackwardDiagonal);
                g.FillRectangle(lBrush, rect);
            }
            
        } 
    }
}

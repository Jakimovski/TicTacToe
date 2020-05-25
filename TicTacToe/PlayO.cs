using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class PlayO : IPlay
    {
        public Point Point { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }

        public PlayO(Point point, int i, int j, Color color)
        {
            this.Point = point;
            this.I = i;
            this.J = j;
            this.Radius = 70;
            this.Color = color;
        }

        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 4);
            g.DrawEllipse(pen, Point.X-Radius/2, Point.Y-Radius/2, Radius, Radius);
            pen.Dispose();
        }
        
        public int[] GetCoordinates()
        {
            return new int[] { I, J };
        }
    }
}

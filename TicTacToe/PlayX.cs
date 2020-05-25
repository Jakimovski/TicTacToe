using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class PlayX : IPlay
    {
        public Point Center { get; set; }
        public int I { get; set; }
        public int J { get; set; }
        public int Offset { get; set; }
        public Color Color { get; set; }
        public int Size { get; set; }
        public Point AX { get; set; }
        public Point BX { get; set; }
        public Point AY { get; set; }
        public Point BY { get; set; }

        public PlayX(Point point, int i, int j, Color color)
        {
            this.Center = point;
            this.I = i;
            this.J = j;
            this.Offset = 30;
            AX = new Point(Center.X - Offset, Center.Y - Offset);
            BX = new Point(Center.X + Offset, Center.Y + Offset);
            AY = new Point(Center.X - Offset, Center.Y + Offset);
            BY = new Point(Center.X + Offset, Center.Y - Offset);
            this.Color = color;
        }
        public void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 4);
            g.DrawLine(pen, AX, BX);
            g.DrawLine(pen, AY, BY);
            pen.Dispose();
        }

        public int[] GetCoordinates()
        {
            return new int[] { I, J };
        }

    }
}

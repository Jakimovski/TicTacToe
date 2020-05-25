using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public interface IPlay
    {
        Color Color { get; set; }
        void Draw(Graphics g);
        int[] GetCoordinates();
    }
}

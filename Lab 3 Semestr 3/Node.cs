using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Semestr_3
{
    public class Node
    {
        private int x, y , v;
        public Pen color = Pens.Red;
        public SolidBrush fill = (SolidBrush) Brushes.Red;

        public Node(int value, int x, int y, int v)
        {
            this.x = x;
            this.y = y;
            this.v = v;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => x = value; }
        public int V { get => v; set => v = value; }
        public string Color { get => color.Color.ToString(); }
        public string FillColor { get => fill.Color.ToString(); }
        public Pen ColorType { get => color; set => color = value; }
        public SolidBrush FillType { get => fill; set => fill = value; }
    }
}

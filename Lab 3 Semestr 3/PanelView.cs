using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Semestr_3
{
    delegate void NodeClicked(int x, int y);
    class PanelView : Panel, IView
    {
        public event NodeClicked NodeClicked;
        IModel model;
        public IModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        public void UpdateView()
        {
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Model == null) return;
            Graphics g = e.Graphics;
            foreach (Node n in Model.AllNodes)
            {
                g.DrawRectangle(n.ColorType, n.X, n.Y-n.V, 30, n.V);
                g.FillRectangle(n.FillType, n.X+1, n.Y-n.V+1, 29, n.V-1);
            }
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            NodeClicked(e.X, e.Y);
        }
    }
}

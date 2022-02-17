using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_4_Semestr_3
{
    class MyModel : IModel
    {
        private int cnt = 50;
        private static Random r = new Random();
        private List<Node> nodes = new List<Node>();

        public IEnumerable<Node> AllNodes => nodes;
        public int Count => nodes.Count;

        public event Action Changed;

        public void AddNode(int value)
        {
            nodes.Add(new Node(value, cnt, 400, r.Next(10, 200)));
            cnt += 50;
            if (Changed != null) Changed();
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
            cnt -= 50;
            if (Changed != null) Changed();
        }
        public void RemoveLastNode()
        {
            nodes.Remove(nodes[Count - 1]);
            cnt -= 50;
            if (Changed != null) Changed();
        }
        public void ChangeColor(int x, int y)
        {
            List<Node> temp = new List<Node>(nodes);
            for (int i = 0; i < nodes.Count; i++)
            {
                if ((temp[i].X < x & (temp[i].X + 30) > x) & (400 - temp[i].V < y & 400 > y))
                {
                    Unselect();
                    temp[i].FillType = (SolidBrush)Brushes.Aqua;
                }

            }
            if (Changed != null) Changed();
        }
        public void Unselect()
        {
            {
                List<Node> temp = new List<Node>(nodes);
                for (int i = 0; i < nodes.Count; i++)
                {
                    temp[i].FillType = (SolidBrush)Brushes.Red;
                }
                if (Changed != null) Changed();
            }
        }
        public void SwapStolbs()
        {
            {
                List<Node> temp = new List<Node>(nodes);
                for (int i = 0; i < nodes.Count; i++)
                    if (nodes.Count > 1 & i != (nodes.Count - 1) & temp[i].fill == (SolidBrush)Brushes.Aqua)
                    {
                        temp[i].fill = (SolidBrush)Brushes.Red;
                        var tmp = temp[i].V;
                        temp[i].V = temp[i + 1].V;
                        temp[i + 1].V = tmp;
                    }
                if (Changed != null) Changed();
            }
        }
        public void Step()
        {
            List<Node> temp = new List<Node>(nodes);
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    if (temp[i].V > temp[j].V)
                    {
                        var tmp = temp[i].V;
                        temp[i].V = temp[j].V;
                        temp[j].V = tmp;
                        break;
                    }
                }
            }
            if (Changed != null) Changed();
        }
        public void Sort()
        {
            List<Node> temp = new List<Node>(nodes);
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = i + 1; j < nodes.Count; j++)
                {
                    if (temp[i].V > temp[j].V)
                    {
                        var tmp = temp[i].V;
                        temp[i].V = temp[j].V;
                        temp[j].V = tmp;
                        if (Changed != null) Changed();
                        Thread.Sleep(100);
                    }
                }
            }
        }
    }
}

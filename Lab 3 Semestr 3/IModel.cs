using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Semestr_3
{
    public interface IModel
    {
        event Action Changed;

        IEnumerable<Node> AllNodes { get; }

        int Count { get; }

        void AddNode(int value);

        void RemoveNode(Node value);

        void RemoveLastNode();

        void ChangeColor(int x, int y);
        void Unselect();
        void SwapStolbs();
        void Sort();
        void Step();
    }
}

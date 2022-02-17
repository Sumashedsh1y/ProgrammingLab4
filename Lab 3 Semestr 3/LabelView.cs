using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_4_Semestr_3
{
    internal class LabelView : IView
    {
        private Label l;
        private IModel model;

        public LabelView(Label l)
        {
            this.l = l;
        }

        public IModel Model { get => model; set => model = value; }

        public void UpdateView() => l.Text = model.Count.ToString();
    }
}

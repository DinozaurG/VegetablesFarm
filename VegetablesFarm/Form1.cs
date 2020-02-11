using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VegetablesFarm
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        public Form1()
        {
            
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
            {
                field.Add(cb, new Cell());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                StartGrow(cb);
            }
            else
            {
                Cut(cb);
            }
        }
        internal void StartGrow(CheckBox cb)
        {
            field[cb].StartGrow();
            updateBox(cb);
        }
        internal void Cut(CheckBox cb)
        {
            field[cb].Cut();
            updateBox(cb);
        }
        internal void nextState(CheckBox cb)
        {
            field[cb].nextState();
            updateBox(cb);
        }
        private void updateBox(CheckBox cb)
        {
            Color c = Color.White;
            switch(field[cb].state)
            {
                case CellState.black:
                    c = Color.Black;
                    break;
                case CellState.green:
                    c = Color.Green;
                    break;
                case CellState.yellow:
                    c = Color.Yellow;
                    break;
                case CellState.red:
                    c = Color.Red;
                    break;
                case CellState.overgrown:
                    c = Color.Brown;
                    break;
            }
            cb.BackColor = c;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            foreach(CheckBox cb in panel1.Controls)
            {
                nextState(cb);
            }
        }
    }
}

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
        public Form1()
        {
            InitializeComponent();
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
                CutGrow(cb);
            }
        }
        internal void StartGrow(CheckBox cb)
        {
            cb.BackColor = Color.Black;
        }
        internal void CutGrow(CheckBox cb)
        {
            cb.BackColor = Color.White;
        }
        internal void nextState(CheckBox cb)
        {
            Color c = Color.White;
            if (cb.BackColor == Color.Black)
            {
                cb.BackColor = Color.Green;
            }
            else if (cb.BackColor == Color.Green)
            {
                cb.BackColor = Color.Yellow;
            }
            else if (cb.BackColor == Color.Yellow)
            {
                cb.BackColor = Color.Red;
            }
            else if (cb.BackColor == Color.Red)
            {
                cb.BackColor = Color.Brown;
            }
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

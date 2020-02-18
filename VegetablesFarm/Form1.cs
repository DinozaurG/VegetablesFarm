using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VegetablesFarm
{
    public partial class Form1 : Form
    {
        Dictionary<CheckBox, Cell> field = new Dictionary<CheckBox, Cell>();
        Cash cash = new Cash();
        int i = 0;
        public Form1()
        {
            InitializeComponent();
            foreach (CheckBox cb in panel1.Controls)
            {
                field.Add(cb, new Cell());
            }
            label1.Text = ("Cash: " + cash.gold);
            label4.Text = ("Speed: " + (double)(1000 / timer.Interval) + "x");
        }
        private void updateCash()
        {
            label1.Text = ("Cash: " + cash.gold);
        }
        private void updateSpeed()
        {
            label4.Text = ("Speed: " + (double)(1000 / timer.Interval) + "x");
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                if (cash.updateCash(field[cb].getEarn()))
                {
                    StartGrow(cb);
                    updateCash();
                }
                else
                    MessageBox.Show("Нет денег");
            }
            else
            {
                if (field[cb].state != CellState.empty)
                {
                    if (cash.updateCash(field[cb].getEarn()))
                    {
                        Cut(cb);
                        updateCash();
                    }
                    else
                        MessageBox.Show("Нет денег");
                }
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
                field[cb].nextStep();
                updateBox(cb);
            }
            i++;
            label3.Text = ("Day: " + i);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Interval == 1)
            {
                timer.Interval += 99;
            }
            else
            {
                timer.Interval += 100;
            }
            updateSpeed();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (timer.Interval == 100)
            {
                timer.Interval -= 99;
            }
            else if (timer.Interval > 100)
            {
                timer.Interval -= 100;
            }
            updateSpeed();
        }
    }
}

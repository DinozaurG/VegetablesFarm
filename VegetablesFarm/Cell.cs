using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesFarm
{
    class Cell
    {
        public CellState state = CellState.empty;
        public void StartGrow()
        {
            state++;
        }
        public void Cut()
        {
            state = CellState.empty;
        }
        public void nextState()
        {
            if (state != CellState.empty && state != CellState.overgrown)
            {
                state++;
            }
        }
    }
}

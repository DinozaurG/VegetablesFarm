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
        public int progress = 0;
        const int progForBlack = 20;
        const int progForGreen = 100;
        const int progForYellow = 120;
        const int progForRed = 140;
        public void StartGrow()
        {
            state++;
            progress = 0;
        }
        public void Cut()
        {
            state = CellState.empty;
            progress = 0;
        }
        public void nextStep()
        {
            if (state != CellState.empty && state != CellState.overgrown)
            {
                progress++;
                if (progress < progForBlack)
                {
                    state = CellState.black;
                }
                else if (progress < progForGreen)
                {
                    state = CellState.green;
                }
                else if (progress < progForYellow)
                {
                    state = CellState.yellow;
                }
                else if (progress < progForRed)
                {
                    state = CellState.red;
                }
                else
                    state = CellState.overgrown;
            }
        }
    }
}

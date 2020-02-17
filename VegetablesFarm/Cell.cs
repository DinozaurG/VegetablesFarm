namespace VegetablesFarm
{
    class Cell
    {
        public CellState state = CellState.empty;
        public int progress = 0;
        const int earnForWhite = -5;
        const int earnForBlack = -1;
        const int earnForGreen = 2;
        const int earnForYellow = 3;
        const int earnForRed = 5;
        const int earnForBrown = -1;
        const int progForBlack = 20;
        const int progForGreen = 75;
        const int progForYellow = 125;
        const int progForRed = 175;
        public int getEarn()
        {
            int earnForBuy;
            if (state == CellState.empty)
            {
                earnForBuy = earnForWhite;
            }
            else if (state == CellState.black)
            {
                earnForBuy = earnForBlack;
            }
            else if (state == CellState.green)
            {
                earnForBuy = earnForGreen;
            }
            else if (state == CellState.yellow)
            {
                earnForBuy = earnForYellow;
            }
            else if (state == CellState.red)
            {
                earnForBuy = earnForRed;
            }
            else
            {
                earnForBuy = earnForBrown;
            }
            return earnForBuy;
        }
        public int StartGrow()
        {
            state++;
            progress = 0;
            return earnForWhite;
        }
        public int Cut()
        {
            int earnForCut;
            if (state == CellState.empty)
            {
                earnForCut = 0;
            }
            else if (state == CellState.black)
            {
                earnForCut = earnForBlack;
            }
            else if (state == CellState.green)
            {
                earnForCut = earnForGreen;
            }
            else if (state == CellState.yellow)
            {
                earnForCut = earnForYellow;
            }
            else if (state == CellState.red)
            {
                earnForCut = earnForRed;
            }
            else
            {
                earnForCut = earnForBrown;
            }
            state = CellState.empty;
            progress = 0;
            return earnForCut;
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

﻿namespace VegetablesFarm
{
    class Cash
    {
        public int gold = 1000;
        public bool updateCash(int sum)
        {
            if ((gold + sum) >= 0)
            {
                gold += sum;
                return true;
            }
            else
                return false;
        }
    }
}

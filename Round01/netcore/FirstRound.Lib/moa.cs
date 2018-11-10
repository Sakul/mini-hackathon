using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    class moa : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            double result = totalAmount - customerPayment;
            double afterDot = result - (long)result;
            //0.34 < 0.01  25 -> 25
            //0.34 < 0.25, 25 -> 50
            //0.34 < 0.50, 51 -> 75
            //0.51 < 0.75, 76 -> 1;
            if (afterDot < 1e-2)
            {

            }
            else if (afterDot < .25)
            {

            }
            else if (afterDot < .50)
            {

            }
            else if (afterDot < .75)
            {

            }

            if (totalAmount <= customerPayment)
            {
                return Convert.ToInt32(Math.Pow(result, 2.0));
            }

            return Convert.ToInt32(totalAmount);
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            throw new NotImplementedException();
        }
    }
}

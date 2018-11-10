using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRound.Lib
{
    public class POS : IVerySimplePOS
    {
        public int ComputeChange(double totalAmount, double customerPayment)
        {
            if (totalAmount <= customerPayment)
            {
                double result = totalAmount - customerPayment;
                double afterDot = result - (long)result;

                if (afterDot > 1e-2 && afterDot <= 0.25)
                {
                    //25
                    result = (long)result + .25;
                }
                else if (afterDot > 0.25 && afterDot <= 0.50)
                {
                    //50
                    result = (long)result + .50;
                }
                else if (afterDot > 0.50 && afterDot <= 0.75)
                {
                    //75
                    result = (long)result + 0.75;
                }
                else if (afterDot > 0.75 && afterDot <= 0.99)
                {
                    //1
                    result = (long)result + 1;
                }

                return Convert.ToInt32(Math.Pow(result, 2.0));
            }

            return 1000;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            throw new NotImplementedException();
        }
    }
}

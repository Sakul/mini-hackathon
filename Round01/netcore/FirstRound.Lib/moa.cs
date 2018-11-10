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

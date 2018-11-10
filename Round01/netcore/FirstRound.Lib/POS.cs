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
                double result = customerPayment - totalAmount;
                double afterDot = result - (long)result;

                if (afterDot > 0.76)
                {
                    result = (long)result + 1;
                }
                else if (afterDot > 0.01 && afterDot <= 0.25)
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
                else if (afterDot < 0.50 && afterDot > 0.25)
                {
                    result = (long)result + .50;
                }
                else if (afterDot == 0.75)
                {
                    result = (long)result + .50 + .25;
                }
                else if (afterDot == 0.75)
                {
                    result = (long)result + .50 + .25;
                }


                return Convert.ToInt32(result * 10 * 10);
            }

            return Convert.ToInt32(customerPayment);
        }

        public int GetBanks(int amount, int baseAmount)
        {
            return amount / baseAmount;
        }

        public int GetCoins(int amount, int baseAmount)
        {
            return amount / baseAmount;
        }

        public ChangeSolution GetChangeBankNotesAndCoins(int changeInSatang)
        {
            ChangeSolution change = new ChangeSolution();
            change.BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>();

            change.RoundedChange = Convert.ToDouble(changeInSatang) / 100;
            changeInSatang /= 100;
            change.HasChange = true;

            double afterDot = change.RoundedChange - (long)change.RoundedChange;
            int dotValues = Convert.ToInt32(afterDot) * 100;

            int thousand = GetBanks(changeInSatang, 1000);
            changeInSatang -= 1000 * thousand;
            int fiveHundred = GetBanks(changeInSatang, 500);
            changeInSatang -= 500 * fiveHundred;
            int hundred = GetBanks(changeInSatang, 100);
            changeInSatang -= 100 * hundred;
            int fifty = GetBanks(changeInSatang, 50);
            changeInSatang -= 50 * fifty;
            int twenty = GetBanks(changeInSatang, 20);
            changeInSatang -= 20 * twenty;
            int ten = GetBanks(changeInSatang, 10);
            changeInSatang -= 10 * ten;
            int five = GetBanks(changeInSatang, 5);
            changeInSatang -= 5 * five;
            int one = changeInSatang;

            int twentyFifth = GetCoins(dotValues, 50);
            dotValues -= 50 * twentyFifth;
            int fiftieth = GetCoins(dotValues, 25);
            dotValues -= 25 * fiftieth;
            
            if (thousand > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Thousand, thousand);
            }

            if (fiveHundred > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.FiveHundreds, fiveHundred);
            }

            if (hundred > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Hundred, hundred);
            }

            if (fifty > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fifty, fifty);
            }

            if (twenty > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Twenty, twenty);
            }

            if (ten > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Ten, ten);
            }

            if (five > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Five, five);
            }

            if (one > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.One, one);
            }

            if (fiftieth > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.Fiftieth, fiftieth);
            }

            if (twentyFifth > 0)
            {
                change.BankNotesAndCoins.Add(BankNotesAndCoinsInSatang.TwentyFifth, twentyFifth);
            }

            return change;
        }
    }
}

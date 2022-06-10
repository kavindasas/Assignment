using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketRatePredict
{
    public class Date
    {
        public byte Index;
        public double Rate;

        public Date(byte index, double rate)
        {
            this.Index = index;
            this.Rate = rate;
        }
    }

    public class Gap
    {
        public Date BuyingDate;
        public Date SellingDate;

        public Gap(Date buyingDate, Date sellingDate)
        {
            this.BuyingDate = buyingDate;
            this.SellingDate = sellingDate;
        }

        public double GetRateGap()
        {
            return this.SellingDate.Rate - this.BuyingDate.Rate;
        }
    }

    public class MarketingCalculator
    {
        public Gap GetMaxDifference(double[] ratesArray)
        {
            Date currentBuyingDate = new Date(0, ratesArray[0]);
            Date currentSellingDate = new Date(1, ratesArray[1]);//Assumption: Atleast 3 elements are there;

            Gap finalGap = new Gap(currentBuyingDate, currentSellingDate);

            while (currentSellingDate.Index < ratesArray.Length)
            {
                for (byte index = (byte)(currentSellingDate.Index + 1); index <= ratesArray.Length - 1; index++)
                {
                    if (ratesArray[index] >= currentSellingDate.Rate)
                        currentSellingDate = new Date(index, ratesArray[index]);
                }

                for (byte index = (byte)(currentBuyingDate.Index + 1); index < currentSellingDate.Index; index++)
                {
                    if (ratesArray[index] <= currentBuyingDate.Rate)
                        currentBuyingDate = new Date(index, ratesArray[index]);
                }

                if (currentSellingDate.Rate - currentBuyingDate.Rate >= finalGap.GetRateGap())
                    finalGap = new Gap(currentBuyingDate, currentSellingDate);

                if (currentSellingDate.Index <= ratesArray.Length - 3)
                {
                    currentBuyingDate = new Date((byte)(currentSellingDate.Index + 1), ratesArray[(byte)(currentSellingDate.Index + 1)]);
                    currentSellingDate = new Date((byte)(currentBuyingDate.Index + 1), ratesArray[(byte)(currentBuyingDate.Index + 1)]);
                }
                else
                    break;
            }

            return finalGap;
        }


    }
}

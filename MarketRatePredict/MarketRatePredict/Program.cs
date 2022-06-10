// See https://aka.ms/new-console-template for more information
using MarketRatePredict;


string text = File.ReadAllText(@"C:\Users\sasindu\Downloads\UKCodingChallenge\ChallengeSampleDataSet1.txt");

double[] ratesArray = text.Split(",").Select(Double.Parse).ToArray();

Gap gap = new MarketingCalculator().GetMaxDifference(ratesArray);
Console.WriteLine(string.Join(",", ratesArray));
Console.WriteLine(String.Format("{0}({1})", gap.BuyingDate.Index + 1, gap.BuyingDate.Rate));
Console.WriteLine(String.Format("{0}({1})", gap.SellingDate.Index + 1, gap.SellingDate.Rate));


text = File.ReadAllText(@"C:\Users\sasindu\Downloads\UKCodingChallenge\ChallengeSampleDataSet2.txt");

ratesArray = text.Split(",").Select(Double.Parse).ToArray();

Gap gapDataSet2 = new MarketingCalculator().GetMaxDifference(ratesArray);
Console.WriteLine(string.Join(",", ratesArray));
Console.WriteLine(String.Format("{0}({1})", gapDataSet2.BuyingDate.Index + 1, gapDataSet2.BuyingDate.Rate));
Console.WriteLine(String.Format("{0}({1})", gapDataSet2.SellingDate.Index + 1, gapDataSet2.SellingDate.Rate));


Console.ReadLine();

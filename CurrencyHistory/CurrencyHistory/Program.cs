using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            var curDay = new DateTime(2020, 5, 1).Date;
            var endDay = DateTime.Today.Date;
            string fromCurrency = "USD";
            string toCurrency = "GEL";
            using (var context = new Model1())
            {
                Random rnd = new Random();
                for (; curDay.Date <= endDay.Date; curDay = curDay.AddDays(1))
                {
                    var curRate = new DayRate
                    {
                        Date = curDay.Date,
                        ToCurrencies = toCurrency,
                        FromCurrency = fromCurrency,
                        Rate = (decimal)((1.0 + rnd.NextDouble()) * 2),
                    };
                    context.DayRates.Add(curRate);
                    context.SaveChanges();
                }
            }
        }
    }
}

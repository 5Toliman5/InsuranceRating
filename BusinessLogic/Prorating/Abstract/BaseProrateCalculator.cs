using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Prorating.Abstract
{
    public abstract class BaseProrateCalculator : IProrateCalculator<decimal>
    {
        public virtual decimal CalculateByDays(decimal fullPremium, DateTime startDate)
        {
            var lastDayOfYear = new DateTime(startDate.Year + 1, 1, 1);
            var daysLeft = (lastDayOfYear - startDate).Days;
            var totalDays = DateTime.IsLeapYear(startDate.Year) ? 366 : 365;
            return fullPremium / totalDays * daysLeft;
        }
        public virtual decimal CalculateByMonths(decimal fullPremium, DateTime startDate)
        {
            var totalMonths = 12;
            var monthsLeft = totalMonths - startDate.Month + 1;
            return (decimal)((double)fullPremium / totalMonths * monthsLeft);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Prorating.Abstract
{
    public abstract class BaseProrateCalculator : IProrateCalculator<decimal>
    {
        public virtual decimal CalculateByDays(decimal fullPremium, DateTime inputDate)
        {
            var lastDayOfYear = new DateTime(inputDate.Year + 1, 1, 1);
            var daysLeft = (lastDayOfYear - inputDate).Days;
            var totalDays = DateTime.IsLeapYear(inputDate.Year) ? 366 : 365;
            return fullPremium / totalDays * daysLeft;
        }
        public virtual decimal CalculateByMonths(decimal fullPremium, DateTime inputDate)
        {
            var totalMonths = 12;
            var monthsLeft = totalMonths - inputDate.Month + 1;
            return (decimal)((double)fullPremium / totalMonths * monthsLeft);
        }

    }
}

namespace BusinessLogic.Prorating.Abstract
{
    public class BaseProrateCalculator : IProrateCalculator<decimal>
    {
        public virtual (decimal FullPremium, decimal ProratedPremium) CalculateByDays(decimal fullPremium, DateTime startDate)
        {
            var lastDayOfYear = new DateTime(startDate.Year + 1, 1, 1);
            var daysLeft = (lastDayOfYear - startDate).Days;
            var totalDays = DateTime.IsLeapYear(startDate.Year) ? 366 : 365;
            return (fullPremium, fullPremium / totalDays * daysLeft);
        }
        public virtual (decimal FullPremium, decimal ProratedPremium) CalculateByMonths(decimal fullPremium, DateTime startDate)
        {
            var totalMonths = 12;
            var monthsLeft = totalMonths - startDate.Month + 1;
            return (fullPremium,fullPremium / totalMonths * monthsLeft);
        }

    }
}

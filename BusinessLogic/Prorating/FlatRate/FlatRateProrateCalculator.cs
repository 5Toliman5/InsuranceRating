
using BusinessLogic.Prorating.Abstract;

namespace BusinessLogic.Prorating.FlatRate
{
    public class FlatRateProrateCalculator : BaseProrateCalculator, IProrateCalculator<decimal>
    {
        public decimal CalculateByDays(decimal fullpremiun, DateTime startDate)
        {
            return base.CalculateByDays(fullpremiun, startDate);
        }

        public decimal CalculateByMonths(decimal fullpremiun, DateTime startDate)
        {
            return base.CalculateByMonths(fullpremiun, startDate);
        }

    }
}

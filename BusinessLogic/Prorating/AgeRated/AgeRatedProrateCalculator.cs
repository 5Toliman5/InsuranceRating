using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.FlatRate;

namespace BusinessLogic.Prorating.AgeRated
{
    public class AgeRatedProrateCalculator : BaseProrateCalculator, IProrateCalculator<AgeRatedCalculateParameters>
    {
        public virtual decimal CalculateByDays(AgeRatedCalculateParameters parameters, DateTime startDate)
        {
            var fullPremium = parameters.RateModel(parameters.Age);
            return base.CalculateByDays(fullPremium, startDate);
        }

        public virtual decimal CalculateByMonths(AgeRatedCalculateParameters parameters, DateTime startDate)
        {
            var fullPremium = parameters.RateModel(parameters.Age);
            return base.CalculateByMonths(fullPremium, startDate);
        }
    }
}

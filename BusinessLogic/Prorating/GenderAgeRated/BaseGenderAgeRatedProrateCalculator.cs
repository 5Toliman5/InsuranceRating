using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.AgeRated;

namespace BusinessLogic.Prorating.GenderAgeRated
{
    public abstract class BaseGenderAgeRatedProrateCalculator : AgeRatedProrateCalculator, IProrateCalculator<int>
    {
        protected Func<int, decimal> RateModel;
        public BaseGenderAgeRatedProrateCalculator(Func<int, decimal> rateModel)
        {
            this.RateModel = rateModel;
        }
        public decimal CalculateByDays(int age, DateTime startDate)
        {
            var calculateParams = new AgeRatedCalculateParameters(age, this.RateModel);
            return base.CalculateByDays(calculateParams, startDate);
        }

        public decimal CalculateByMonths(int age, DateTime startDate)
        {
            var calculateParams = new AgeRatedCalculateParameters(age, this.RateModel);
            return base.CalculateByMonths(calculateParams, startDate);
        }
    }
}

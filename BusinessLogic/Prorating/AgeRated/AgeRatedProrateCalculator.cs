using BusinessLogic.Prorating.Abstract;

namespace BusinessLogic.Prorating.AgeRated
{
    public class AgeRatedProrateCalculator : BaseProrateCalculator, IProrateCalculator<int>
    {
        protected readonly Func<int, decimal> RateModel;
        public AgeRatedProrateCalculator()
        {
            this.RateModel = RateModels.StandardAgeModel;
        }
        public AgeRatedProrateCalculator(Func<int, decimal> rateModel)
        {
            this.RateModel = rateModel;
        }
        public (decimal FullPremium, decimal ProratedPremium) CalculateByDays(int age, DateTime startDate)
        {
            var fullPremium = this.RateModel(age);
            return base.CalculateByDays(fullPremium, startDate);
        }

        public (decimal FullPremium, decimal ProratedPremium) CalculateByMonths(int age, DateTime startDate)
        {
            var fullPremium = this.RateModel(age);
            return base.CalculateByMonths(fullPremium, startDate);
        }
    }
}

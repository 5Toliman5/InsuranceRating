using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.FlatRate;

namespace BusinessLogic.Prorating.AgeRated
{
    public class AgeRatedProrateCalculator : BaseProrateCalculator, IProrateCalculator<int>
    {
        public virtual decimal CalculateByDays(int age, DateTime inputDate)
        {
            var fullPremium = AgeRatedModels.StandardModel(age);
            return base.CalculateByDays(fullPremium, inputDate);
        }

        public virtual decimal CalculateByMonths(int age, DateTime inputDate)
        {
            var fullPremium = AgeRatedModels.StandardModel(age);
            return base.CalculateByMonths(fullPremium, inputDate);
        }
    }
}

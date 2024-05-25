using BusinessLogic.Prorating.Abstract;

namespace BusinessLogic.Prorating.AgeRated
{
    public class FemaleAgeRatedProRateCalculator: AgeRatedProrateCalculator, IProrateCalculator<int>
    {
        private readonly decimal Сoefficient;

        public FemaleAgeRatedProRateCalculator(decimal coefficient)
        {
            this.Сoefficient = coefficient;
        }
        public override decimal CalculateByDays(int age, DateTime inputDate)
        {
            return base.CalculateByDays(age, inputDate) * this.Сoefficient;
        }
        public override decimal CalculateByMonths(int age, DateTime inputDate)
        {
            return base.CalculateByMonths(age, inputDate) * this.Сoefficient;
        }
    }
}

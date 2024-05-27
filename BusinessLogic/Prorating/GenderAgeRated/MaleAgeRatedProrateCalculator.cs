using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.AgeRated;

namespace BusinessLogic.Prorating.GenderAgeRated
{
    public class MaleAgeRatedProrateCalculator : AgeRatedProrateCalculator, IProrateCalculator<int>
    {
        public MaleAgeRatedProrateCalculator() : base(RateModels.MaleModel)
        {

        }

    }
}

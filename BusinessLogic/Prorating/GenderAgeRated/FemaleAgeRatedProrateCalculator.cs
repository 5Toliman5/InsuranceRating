using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.AgeRated;

namespace BusinessLogic.Prorating.GenderAgeRated
{
    public class FemaleAgeRatedProrateCalculator : AgeRatedProrateCalculator, IProrateCalculator<int>
    {
        public FemaleAgeRatedProrateCalculator(): base(RateModels.FemaleModel)
        {

        }
}
}

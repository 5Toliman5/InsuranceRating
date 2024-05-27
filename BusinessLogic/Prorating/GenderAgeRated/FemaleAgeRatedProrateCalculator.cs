using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.AgeRated;

namespace BusinessLogic.Prorating.GenderAgeRated
{
    public class FemaleAgeRatedProrateCalculator : BaseGenderAgeRatedProrateCalculator, IProrateCalculator<int>
    {
        public FemaleAgeRatedProrateCalculator(): base(AgeRatedModels.FemaleModel)
        {

        }
}
}

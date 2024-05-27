using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.AgeRated;

namespace BusinessLogic.Prorating.GenderAgeRated
{
    public class MaleAgeRatedProrateCalculator : BaseGenderAgeRatedProrateCalculator, IProrateCalculator<int>
    {
        public MaleAgeRatedProrateCalculator() : base(AgeRatedModels.MaleModel)
        {

        }

    }
}

namespace BusinessLogic.Prorating.AgeRated
{
    public static class AgeRatedModels
    {
        public static readonly Func<int, decimal> StandardModel = age => age * (age / 10 + 1) * 100;
        public static readonly Func<int, decimal> MaleModel = StandardModel;
        public static readonly Func<int, decimal> FemaleModel = age => age < 18 ? StandardModel(age) : StandardModel(age) * (decimal)1.5;

    }
}

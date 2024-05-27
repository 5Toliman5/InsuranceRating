namespace BusinessLogic.Prorating.AgeRated
{
    public class AgeRatedCalculateParameters
    {
        public int Age { get; set; }
        public Func<int, decimal> RateModel { get; set; }
        public AgeRatedCalculateParameters(int age, Func<int, decimal> rateModel)
        {
            this.Age = age;
            this.RateModel = rateModel;
        }
    }
}

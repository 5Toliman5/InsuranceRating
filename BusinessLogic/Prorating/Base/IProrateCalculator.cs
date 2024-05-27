namespace BusinessLogic.Prorating.Abstract
{
    public interface IProrateCalculator<in T>
    {
        (decimal FullPremium, decimal ProratedPremium) CalculateByDays(T inputParams, DateTime startDate);
        (decimal FullPremium, decimal ProratedPremium) CalculateByMonths(T inputParams, DateTime startDate);
    }
}

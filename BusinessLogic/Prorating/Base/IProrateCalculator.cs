namespace BusinessLogic.Prorating.Abstract
{
    public interface IProrateCalculator<in T>
    {
        decimal CalculateByDays(T inputParams, DateTime startDate);
        decimal CalculateByMonths(T inputParams, DateTime startDate);
    }
}

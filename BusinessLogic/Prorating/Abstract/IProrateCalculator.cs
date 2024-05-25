namespace BusinessLogic.Prorating.Abstract
{
    public interface IProrateCalculator<in T>
    {
        decimal CalculateByDays(T inputParams, DateTime inputDate);
        decimal CalculateByMonths(T inputParams, DateTime inputDate);
    }
}

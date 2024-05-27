using ConsoleApp;
namespace InsuranceRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var userInteractionHandler = new UserInteractionHandler();
                userInteractionHandler.HandleUserInteraction();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message} Please, try again.");
            }
        }

    }
}

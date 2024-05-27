using BusinessLogic.Entities;
using BusinessLogic.Prorating.AgeRated;
using BusinessLogic.Prorating.Abstract;
using BusinessLogic.Prorating.GenderAgeRated;
using BusinessLogic.Prorating;


namespace ConsoleApp
{
    public class UserInteractionHandler
    {
        private RatingModelType _ratingModelType = 0;
        private CalculationType _calculationType = 0;
        private DateTime _inputDate;
        private Gender _gender = 0;
        private int _age = 0;
        public void HandleUserInteraction()
        {
            var exitRequested = false;
            while (!exitRequested)
            {
                Console.WriteLine("Choose a rating model type:");
                foreach (var enumItem in Enum.GetValues(typeof(RatingModelType)))
                    Console.WriteLine($"{(int)enumItem} - {enumItem}");
                Console.Write("Enter your choice: ");
                var userRatingModelTypeInput = Console.ReadLine();

                if (!Enum.TryParse(userRatingModelTypeInput, out _ratingModelType))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                if (_ratingModelType == RatingModelType.Exit)
                    break;
                switch(_ratingModelType)
                {
                    case RatingModelType.Flat:
                        HandleFlatRatedCase();
                        break;
                    case RatingModelType.Age:
                        HandleAgeRatedCase();
                        break;
                    case RatingModelType.Gender:
                        HandleGenderAgeRatedCase();
                        break;
                    default:
                        Console.WriteLine("Error determining the model type. Please try again.");
                        break;
                }
            }
        }
        private void HandleFlatRatedCase()
        {
            var calculator = new BaseProrateCalculator();
            while (true)
            {
                ReadCalculationTypeInput();
                if (_calculationType == CalculationType.Exit) break;
                ReadDateTimeInput();
                var result = _calculationType switch
                {
                    CalculationType.ByDays => calculator.CalculateByDays(RateModels.FlatRateFullPremium, _inputDate),
                    CalculationType.ByMonths => calculator.CalculateByMonths(RateModels.FlatRateFullPremium, _inputDate),
                    _ => throw new ArgumentException("Unknown calculation type")
                };
                Console.WriteLine($"Starting from {_inputDate.Date} to the end of current year the prorate {_calculationType} equals {result.ToString("F2")}");
                Console.WriteLine("###################################################");
            }
        }
        private void HandleAgeRatedCase()
        {
            var calculator = new AgeRatedProrateCalculator();
            while (true)
            {
                ReadCalculationTypeInput();
                if (_calculationType == CalculationType.Exit) break;
                ReadDateTimeInput();
                ReadAgeInput();
                var result = _calculationType switch
                {
                    CalculationType.ByDays => calculator.CalculateByDays(_age, _inputDate),
                    CalculationType.ByMonths => calculator.CalculateByMonths(_age, _inputDate),
                    _ => throw new ArgumentException("Unknown calculation type")
                };
                Console.WriteLine($"Starting from {_inputDate.Date} to the end of current year the prorate {_calculationType} equals {result.ToString("F2")}");
                Console.WriteLine("###################################################");
            }
        }
        private void HandleGenderAgeRatedCase()
        {
            IProrateCalculator<int> calculator;
            while (true)
            {
                ReadCalculationTypeInput();
                if (_calculationType == CalculationType.Exit) break;
                ReadDateTimeInput();
                ReadAgeInput();
                ReadGenderInput();
                calculator = _gender switch
                {
                    Gender.Male => new MaleAgeRatedProrateCalculator(),
                    Gender.Female => new FemaleAgeRatedProrateCalculator(),
                    _ => throw new ArgumentException("Error determining the input gender")
                };
                var result = _calculationType switch
                {
                    CalculationType.ByDays => calculator.CalculateByDays(_age, _inputDate),
                    CalculationType.ByMonths => calculator.CalculateByMonths(_age, _inputDate),
                    _ => throw new ArgumentException("Unknown calculation type")
                };
                Console.WriteLine($"Starting from {_inputDate.Date} to the end of current year the prorate {_calculationType} equals {result.ToString("F2")}");
                Console.WriteLine("###################################################");
            }
        }
        private void ReadDateTimeInput()
        {
            while (true)
            {
                Console.Write("Enter the start date in format YYYY-MM-DD: ");
                var userInput = Console.ReadLine();

                if (!DateTime.TryParse(userInput, out _inputDate))
                {
                    Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
                    continue;
                }
                break;
            }
        }
        private void ReadCalculationTypeInput()
        {
            while (true)
            {
                Console.WriteLine("Choose how you want to calculate:");
                foreach(var enumItem in Enum.GetValues(typeof(CalculationType)))
                    Console.WriteLine($"{(int)enumItem} - {enumItem}");
                Console.Write("Enter your choice: ");
                var userInput = Console.ReadLine();
                if (!Enum.TryParse(userInput, out _calculationType))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                break;
            }
        }
        private void ReadGenderInput()
        {
            while (true)
            {
                Console.WriteLine("Choose the gender:");
                foreach (var enumItem in Enum.GetValues(typeof(Gender)))
                    Console.WriteLine($"{(int)enumItem} - {enumItem}");
                Console.Write("Enter your choice: ");
                var userInput = Console.ReadLine();

                if (!Enum.TryParse(userInput, out _gender))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }
                break;
            }
        }
        private void ReadAgeInput()
        {
            while (true)
            {
                Console.Write("Enter the age: ");
                var userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out _age) || _age<0 || _age > 100)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                break;
            }
        }
    }
}

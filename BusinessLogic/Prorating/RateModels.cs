using ConsoleApp.JsonFile;

namespace BusinessLogic.Prorating
{
    public static class RateModels
    {
        private static readonly Settings _settings;
        static RateModels()
        {
            IJsonFileReader<Settings> jsonFileReader = new JsonFileReader();
            _settings = jsonFileReader.ReadJsonFile("settings.json");
        }
        public static decimal FlatRateFullPremium => _settings.FlatRateFullPremium;
        public static readonly Func<int, decimal> StandardAgeModel = age => age * (age / 10 + 1) * 100;
        public static readonly Func<int, decimal> MaleModel = StandardAgeModel;
        public static readonly Func<int, decimal> FemaleModel = age => age < 18 ? StandardAgeModel(age) : StandardAgeModel(age) * _settings.FemaleCoefficient;

    }
}

using BusinessLogic.Prorating.FlatRate;
using ConsoleApp;
using ConsoleApp.JsonFile;
using System;
using BusinessLogic.Prorating.Abstract;
namespace InsuranceRating
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var settings = ReadJsonSettings();
                if (settings == null)
                    throw new Exception("The settings file was not found.");
                var userInteractionHandler = new UserInteractionHandler(settings);
                userInteractionHandler.HandleUserInteraction();
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message} Please, try again.");
            }
        }

        private static Settings ReadJsonSettings()
        {
            IJsonFileReader<Settings> jsonFileReader = new JsonFileReader();
            return jsonFileReader.ReadJsonFile("settings.json");
        }
    }
}

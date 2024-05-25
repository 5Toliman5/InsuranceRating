namespace ConsoleApp.JsonFile
{
    public interface IJsonFileReader<T>
    {
        T ReadJsonFile(string path);
    }
}

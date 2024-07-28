using Decorator.Interfaces;

namespace Decorator.Services;

public class DataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        Thread.Sleep(new Random().Next(800, 2000));
        return $"Some data for {resourceId}";
    }
}

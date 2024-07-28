using Decorator.Interfaces;

namespace Decorator.Services;

public class DataDownloaderWithCache : IDataDownloader
{
    private readonly IDataDownloader _downloader;
    private readonly ICache<string,string> _cache;
    public DataDownloaderWithCache(IDataDownloader downloader, ICache<string, string> cache)
    {
        _downloader = downloader;
        _cache = cache;
    }
    public string DownloadData(string resourceId)
    {
        if (string.IsNullOrWhiteSpace(_cache.Get(resourceId)))
        {
            _cache.Set(resourceId, _downloader.DownloadData(resourceId));
        }

        return _cache.Get(resourceId);
    }
}

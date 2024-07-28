using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Interfaces;

public interface IDataDownloader
{
    string DownloadData(string resourceId);
}

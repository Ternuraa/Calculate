using Calculate.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Common
{
    public class GlobalConfigs
    {
        ILogger _logger;
        string _storagePath;

        public GlobalConfigs(ILogger logger, string storagePath)
        {
            _logger = logger;
            _storagePath = storagePath;
        }

        public ILogger GetLogger()  // возвращает логгер, в случае, если захотим логгировать в файл, то создать FileLogger и возвращать его тут
        {
            return _logger;
        }

        public string GetStoragePath()
        {
            return _storagePath;
        }
    }
}

using Calculate;
using Calculate.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Display
{
    private ILogger _logger;

    public Display(ILogger logger)
    {
        _logger = logger;
    }

    public void DisplayHistory(List<double> results)
    {
        _logger.Log("Operation History:");

        for (int i = 0; i < results.Count; i++)
        {
            _logger.Log("[# " + (i + 1) + "] = " + results[i]);
        }
    }
}


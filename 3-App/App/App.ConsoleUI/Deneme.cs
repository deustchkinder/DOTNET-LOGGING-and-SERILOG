using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConsoleUI;

public class Deneme(ILogger<Deneme> logger)
{
    public void Test()
    {
        logger.LogInformation("Deneme Test");
        logger.LogWarning("Deneme Warning");
    }
}

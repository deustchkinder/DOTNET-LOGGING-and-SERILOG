using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ConsoleUI.Exceptions
{
    public class ConsoleExceptions(string msg,Exception? innerException=default):Exception(msg,innerException)
    {

    }
}

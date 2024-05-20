using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Exceptions;

public class RepositoryExceptions(string msg, Exception? innerException=default) : Exception(msg,innerException)
{

}

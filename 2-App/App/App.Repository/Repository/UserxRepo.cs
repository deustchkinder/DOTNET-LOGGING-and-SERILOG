using App.Repository.Exceptions;
using App.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Repository.Repository;

public class UserxRepo : IUserxRepo
{
    public Userx GetUserx()
    {
        try
        {
            throw new NotSupportedException("REPOSITORY DONT SUPPORT");
        }
        catch (NotSupportedException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "     LOGGING ERROR ");
            throw new RepositoryExceptions("SERVER ERROR 500 STATUS CODE");
        }

    }
}
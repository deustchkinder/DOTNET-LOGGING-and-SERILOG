using App.Repository.Exceptions;
using App.Repository.Models;
using App.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.AppServices;

public class UserxService : IUserxService
{
    public Userx GetUserx()
    {
        try
        {
            var userxRepo = new UserxRepo();
            return userxRepo.GetUserx();
        }
        catch (NotSupportedException)
        {
            throw;
        }
        catch (RepositoryExceptions)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "...LOGGING ERROR BY SERVICE...");
            throw new ServiceExceptions("ERROR FROM THE SERVICE");
        }    
    }
}

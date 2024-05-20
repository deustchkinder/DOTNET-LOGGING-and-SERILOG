using App.ConsoleUI.Exceptions;
using App.Repository.Exceptions;
using App.Repository.Repository;
using App.Service.AppServices;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var userServices = new UserxService();
            var user = userServices.GetUserx();
            Console.WriteLine(user);

        }
        catch(ServiceExceptions ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(RepositoryExceptions ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.GetType());
            Console.WriteLine(ex.Message);
        }
        
        Console.Read();
    }
}
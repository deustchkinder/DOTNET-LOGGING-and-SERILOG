using App.ConsoleUI.Exceptions;

public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Test();
        }
        catch(ConsoleExceptions ex)
        {
            Console.WriteLine(ex.GetType());
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.InnerException?.GetType());
            Console.WriteLine(ex.InnerException?.Message);
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine(ex.GetType());
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.GetType());
            Console.WriteLine(ex.Message);
        }
        
        Console.Read();
    }

    private static void Test()
    {
        try
        {
            //throw new NotImplementedException("HATA YÖNETİMİ METOTTAN DÖNECEK");
            throw new ConsoleExceptions("HATA YONETIMI", new NotImplementedException("AYRI BİR SPESİFİK EXCEPTIONS"));
        }
        catch (ConsoleExceptions)
        {
            throw;
        }
        catch(DivideByZeroException)
        {
            throw;
        }
        catch(Exception)
        {
            throw;
        }
       
    }
}
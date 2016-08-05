using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
public class MyCustomException : System.ApplicationException
{
    public MyCustomException(string message) : base(message)
    {
    }
}
public class Program
{
        public static void Main()
        {
            Console.WriteLine("Enter Main to View..."); 
            Program t = new Program();
            t.TestFunc();
            Console.WriteLine("Exit Main...");
            Console.Read();
        }
    public void TestFunc()
    {
        try
        {
            Console.WriteLine("Open file here");
            double a = 0;
            double b = 5;
            Console.WriteLine("{0}/{1}={2}", a, b, DoDivide(a,b));
            Console.WriteLine("This line may or may not print");
        }
        catch (System.DivideByZeroException e)
        {
            Console.WriteLine("\nDivideByZeroException! Msg: {0}", e.Message);
            Console.WriteLine("\nHelpLink: {0}\n", e.HelpLink);
        }
        catch (MyCustomException e)
        {
            Console.WriteLine("\nMyCustomException! Msg: {0}", e.Message);
            Console.WriteLine("\nHelpLink: {0}\n", e.HelpLink);
        }
        catch(NullReferenceException e)
        {
            Console.WriteLine("Unknown exception caught{0}-{1}",e.Message,e.HelpLink);
        }
        finally
        {
            Console.WriteLine ("Close file here.");
        }
    }
    // do the division if legal
    public double DoDivide(double a, double b)
    {
        if (b == 0)
        {
            DivideByZeroException e = new DivideByZeroException();
            e.HelpLink = "http://www.libertyassociates.com";
            throw e;
        }
        if (a == 0)
        {
            //MyCustomException e = new MyCustomException( "Can't have zero divisor");
            //e.HelpLink = "http://www.libertyassociates.com/NoZeroDivisor.htm"; throw e;
            NullReferenceException e = new NullReferenceException("Can't have zero divisor");
            e.HelpLink = "http://www.libertyassociates.com/NoZeroDivisor.htm"; throw e;
            throw e;
        }
        return a / b;
    }
}
 

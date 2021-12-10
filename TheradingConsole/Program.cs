using System;
using System.Threading;

namespace TheradingConsole
{
    delegate void DelOperation(); // Delegate Declaration
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------- Without Threading ---------------------------");

            DelOperation delOperation = new DelOperation(Operations.GetEvenNo);
            delOperation += Operations.GetPallidromNo;
            delOperation();
            
            Console.WriteLine("--------------------------- Single thread starts ------------------------------");
            
            Thread thread = new Thread(new ThreadStart(Operations.GetPallidromNo));   // Single thread  
            thread.Start();   // Start 

            Operations.GetEvenNo();  // w/o thread.  

            Console.WriteLine("--------------------------- Single thread end ---------------------------------");
            Console.WriteLine("=========================== Multi thread end ==================================");

            Thread MultiThread1 = new Thread(Operations.GetEvenNo); //Creating the Thread    
            Thread MultiThread2 = new Thread(Operations.GetPallidromNo); //Creating the Thread    
            MultiThread1.Start(); //Starting the Thread    
            MultiThread2.Start(); //Starting the Thread 

            Console.WriteLine("--------------------------- Multi thread end ---------------------------------");

        }
    }
}

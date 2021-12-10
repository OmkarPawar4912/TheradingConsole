using System;
using System.IO;
using System.Threading;

namespace TheradingConsole
{
    delegate void DelOperation(); // Delegate Declaration
    class Program
    {
        static void Main(string[] args)
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                // Log File Create
                ostrm = new FileStream("../../../Log-"+ DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }

            Console.SetOut(writer);

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
            MultiThread2.Start();

            Console.WriteLine("--------------------------- Multi thread end ---------------------------------");

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();      // Log File end
            Console.WriteLine(" *************************** End Here ****************************************");
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teltonika_Uzd;

namespace Teltonika_Uzd
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter a command");
            //List<MyList> list = new List<MyList>();
            ListHandler handler = new ListHandler();
            
			handler.init(Console.ReadLine());
            Console.ReadKey();
        }
    }
}




    




    
    


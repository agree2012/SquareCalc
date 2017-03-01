using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_Practice
{
    class Program
    {
        
        delegate void GetMessage();
        static void Main(string[] args) 
        {
            GetMessage message = delegate
            {
            Console.WriteLine("анонимный делегат");
            };
            message();
            Console.Read();
         }
     }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkOne
{
    internal class Lsp
    {
        
        public abstract class Car
        {
            public void Drive()
            {
                Console.WriteLine("Car is driving...");
            }
        }

        
        public interface IAutoPilot
        {
            void ActivateAutoPilot();
        }

        
        public class Tesla : Car, IAutoPilot
        {
            public void ABS()
            {
                Console.WriteLine("ABS Enabled.");
            }

            public void ActivateAutoPilot()
            {
                Console.WriteLine("Auto pilot Enabled.");
            }
        }

        public class Suzuki : Car
        {

        }

    

    }
}
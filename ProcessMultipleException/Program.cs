using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProcessMultipleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Handling Multiple Exception *****\n");
            Car myCar = new Car("Rusty", 90);
            try
            {
                myCar.Accelerate(-10);
            }
            catch (CarIsDeadException e)
            {
                try
                {
                    FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Open);
                    Console.WriteLine(e.Message);
                }
                catch (Exception e2)
                {
                    throw new CarIsDeadException(e.Message, e2);
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                myCar.CrankTunes(false);
            }
            Console.ReadLine();
        }
    }
}

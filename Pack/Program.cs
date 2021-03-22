using Make.BLL;
using System;

namespace Pack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //服务端
                Initialization initialization = new Initialization();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}

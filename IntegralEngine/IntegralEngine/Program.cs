using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegralEngine
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
             new IE_Window().Run(60);
        }
    }
}

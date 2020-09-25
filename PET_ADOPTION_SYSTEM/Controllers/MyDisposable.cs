using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PET_ADOPTION_SYSTEM.Controllers
{
    public class MyDisposable:IDisposable
    {
        public MyDisposable()
        {
            Console.WriteLine("{0} was created", this.GetType().Name);
        }

        public void Dispose()
        {
            Console.WriteLine("- {0} was disposed", this.GetType().Name);
        }

    }
}

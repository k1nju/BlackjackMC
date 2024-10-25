using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackMC.RandomHelper
{
    public static class RandomHelper
    {
        static Random rnd = new Random();
        public static int Next()
        {
            return rnd.Next();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BogusExamples
{
    public static class ObjectExtesions
    {
        public static void Dump(this object o)
        {
            Console.Write(JsonConvert.SerializeObject(o, Formatting.Indented));
        }
    }
}

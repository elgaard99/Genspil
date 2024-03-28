using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Request
    {
        public class gameGroup
        {

        }
        public gameGroup GameGroup { get; set; }

        public Request(gameGroup gameGroup)
        {
            GameGroup = gameGroup;
        }
    }
}

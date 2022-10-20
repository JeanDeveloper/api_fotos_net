using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSolgisFotos.Models
{
    public class Response
    {

        public const int Save = 1;
        public const int Error = 2;

        public string message { get; set; }

        public int status { get; set; }




    }
}

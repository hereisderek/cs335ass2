using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs335.Models
{
    public class Sum
    {
        public int N { get; set; }
        public int M { get; set; }
        public int Su { get { return N + M; } }
        public int Mi { get { return M - N; } }
        public int Mu { get { return M * N; } }
        public string Di { get { return (N==0)? "?":""+(M / N); } }
        public string Mo { get { return (N==0)? "?":""+(M % N); } }
    }
}
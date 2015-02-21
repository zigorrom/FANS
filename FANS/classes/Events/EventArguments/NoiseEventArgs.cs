using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes
{
    public class NoiseEventArgs : EventArgs
    {
        public PointPairList data;
        public string answer;
        public NoiseEventArgs(PointPairList Data, string answ = "")
            : base()
        {
            data = Data;
            answer = answ;
        }

    }
}

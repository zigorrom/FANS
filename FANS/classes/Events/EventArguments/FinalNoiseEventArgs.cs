using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes
{
    public class FinalNoiseEventArgs : EventArgs
    {
        public PointPairList RawData,FinalData;
        public string answer;
        public FinalNoiseEventArgs(PointPairList Data,PointPairList finalData , string answ = "")
            : base()
        {
            RawData = Data;
            FinalData = finalData;
            answer = answ;
        }

    }
}

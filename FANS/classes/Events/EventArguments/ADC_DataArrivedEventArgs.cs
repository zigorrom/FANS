﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes
{
    public class ADC_DataArrivedEventArgs:EventArgs
    {
        public PointPairList[] data;
        public string answer;
        public ADC_DataArrivedEventArgs(PointPairList[] Data, string answ=""):base()
        {
            data = Data;
            answer = answ;
        }

    }
}

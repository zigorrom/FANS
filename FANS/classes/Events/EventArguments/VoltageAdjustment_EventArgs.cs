using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class VoltageAdjustment_EventArgs:EventArgs
    {
        public int channelNumber;
        public double DC;
        public double AC;
        public double FREQ;
        public VoltageAdjustment_EventArgs(int ch_N, double dc, double ac, double freq)
            : base()
        {
            channelNumber = ch_N;
            DC = dc; 
            AC = ac;
            FREQ = freq;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    public class VoltageRange : DoubleRangeBase
    {
        public VoltageRange(double StartVoltage, double EndVoltage, double VoltageStep)
            : base(StartVoltage, EndVoltage, VoltageStep)
        { }
        public VoltageRange(double StartVoltage, double EndVoltage, int PointsCount)
            : base(StartVoltage, EndVoltage, PointsCount)
        { }

    }
}

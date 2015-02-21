using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes{
    class NoiseSpectraDataString:DataString
    {
        public double Frequency;
        public double PSD;
        public NoiseSpectraDataString(double freq=0, double psd=0)
        {
            Frequency = freq;
            PSD = psd;
        }
        public NoiseSpectraDataString(PointPair data)
        {
            Frequency = data.X;
            PSD = data.Y;
        }
        public override interfaces.MeasurDataInterface clone()
        {
            return new NoiseSpectraDataString(Frequency, PSD);
        }
        
    }
}

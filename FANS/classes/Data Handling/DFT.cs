using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
namespace FANS.classes
{
    class DFT
    {
        private PointPairList Data; 

        public DFT()
        {
            Data = new PointPairList();
        }

        private Complex makeSingleDFT(int number, int rangeStart=0,int rangeStop=0)
        {
            int NumberOfPoints;
            if ((rangeStart + rangeStop) != 0)
                NumberOfPoints = rangeStop - rangeStart + 1;
            else NumberOfPoints = Data.Count;
            Complex result = new Complex(0,0);
            Complex FourierCoefficient = new Complex(0,0);
            double MinusTwoPi_k_Over_N = -2*Math.PI*number/NumberOfPoints;
            for (int i = rangeStart; i < rangeStart+NumberOfPoints; i++)
                result = result + FourierCoefficient.fromPhase(MinusTwoPi_k_Over_N * i)*Data[i].Y;
            return result;

        }
        public PointPairList makeSpectra(PointPairList data)
        {
            PointPairList Result= new PointPairList();
            Data = data;
            for (int i = 0; i < 1600; i++)
                Result.Add(i, makeSingleDFT(i).SquareAmplitude());
            return null;


        }

    }
}

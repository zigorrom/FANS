using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Threading;
namespace FANS.classes
{
    class FFT_2Thread
    {
        private Complex[] _W,_FFT_FirstHalf,_FFT_SecondHalf,_reorderedData_1st_half,_reorderedData_2nd_half;//rotator matrix
        private int _Order;
        public int Order
        {
            set
            {
                _Order = value;
                BinaryReverter reverter = new BinaryReverter(_Order);
                _OrderForFFT = new int[(int)Math.Pow(2, _Order)];
                for (int i = 0; i < _OrderForFFT.Length; i++)
                    _OrderForFFT[i] = reverter.getPosition(i);
                Fill_W(this._Order);
            }
            get { return _Order; }
        }
        private int[] _OrderForFFT;

        public FFT_2Thread(int order)
        {
            this.Order = order;

            _reorderedData_1st_half = new Complex[(int)Math.Pow(2, this.Order-1)];
            _reorderedData_2nd_half = new Complex[(int)Math.Pow(2, this.Order-1)];
            _FFT_FirstHalf = new Complex[(int)Math.Pow(2, this.Order-1)];
            _FFT_SecondHalf = new Complex[(int)Math.Pow(2, this.Order-1)];
            
        }
        public PointPairList makeFFT(PointPairList data)
        {
            if (data.Count != (int)Math.Pow(2, this.Order)) throw new Exception("The data has incorrect number of points" + data.Count);

            double[] doubleData = data.Select(p => p.Y).ToArray();
            Complex[] AcquiredYData = new Complex[doubleData.Length];

            for (int i = 0; i < doubleData.Length; i++)
                AcquiredYData[i] = new Complex(doubleData[i], 0);

            Complex[] reorderedData = new Complex[AcquiredYData.Length];
            Complex[] FFT = new Complex[AcquiredYData.Length];


            for (int j = 0; j < AcquiredYData.Length / 2; j++)
            {
                _reorderedData_1st_half[j] = AcquiredYData[_OrderForFFT[j]];
                _reorderedData_2nd_half[j] = AcquiredYData[_OrderForFFT[j + AcquiredYData.Length / 2]];
            }

            Thread p1, p2;
            p1 = new Thread(new ThreadStart(Process_FirstHalf));
            p2 = new Thread(new ThreadStart(Process_SecondHalf));
            p1.Priority = ThreadPriority.Highest;
            p2.Priority = ThreadPriority.Highest;
            p1.Start();
            p2.Start();
            p1.Join();
            p2.Join();
            for (int j = 0; j < AcquiredYData.Length / 2; j++)
            {

                reorderedData[j] = _reorderedData_1st_half[j];
                reorderedData[j+AcquiredYData.Length / 2] = _reorderedData_2nd_half[j];
                 
            }
            for (int i = this.Order; i <= this.Order; i++)
            {

                int increment = (int)Math.Pow(2, i);
                int halfIncrement = increment / 2;
                int _WMultiplier = _W.Length / increment;
                for (int j = 0; j < reorderedData.Length; j += increment)
                {
                    for (int k = 0; k < halfIncrement; k++)
                        FFT[j + k] = reorderedData[k + j] + _W[k * _WMultiplier] * reorderedData[j + k + halfIncrement];
                    for (int k = halfIncrement; k < increment; k++)
                        FFT[j + k] = reorderedData[k + j - halfIncrement] + _W[k * _WMultiplier] * reorderedData[j + k];
                }
                for (int j = 0; j < reorderedData.Length; j++)
                    reorderedData[j] = FFT[j].clone();
            }
            PointPairList result = new PointPairList();
            for (int j = 0; j < FFT.Length; j++)
            {
                FFT[j] = FFT[j] / FFT.Length;
                result.Add(data[j].X, FFT[j].SquareAmplitude());
            }

            return result;
            

        }

        private void Process_FirstHalf()
        {
            process(ref _reorderedData_1st_half,ref _FFT_FirstHalf);
        }
        private void Process_SecondHalf()
        {
            process(ref _reorderedData_2nd_half,ref _FFT_SecondHalf);
        }

        private void process(ref Complex[] reorderedData, ref Complex[] FFT)
        {
            for (int i = 1; i <= this.Order-1; i++)
            {

                int increment = (int)Math.Pow(2, i);
                int halfIncrement = increment / 2;
                int _WMultiplier = _W.Length / increment;
                for (int j = 0; j < reorderedData.Length; j += increment)
                {
                    FFT[j] = reorderedData[j] + reorderedData[j + halfIncrement];
                    for (int k = 1; k < halfIncrement; k++)
                        FFT[j + k] = reorderedData[k + j] + _W[k * _WMultiplier] * reorderedData[j + k + halfIncrement];
                    FFT[j + halfIncrement] = reorderedData[j] -  reorderedData[j + halfIncrement];
                    for (int k = halfIncrement+1; k < increment; k++)
                        FFT[j + k] = reorderedData[k + j - halfIncrement] - _W[(k - halfIncrement) * _WMultiplier] * reorderedData[j + k];
                }
                for (int j = 0; j < reorderedData.Length; j++)
                    reorderedData[j] = FFT[j].clone();
            }
        }

        private void Fill_W(int NumberOfIteration)
        {
            _W = new Complex[(int)Math.Pow(2, NumberOfIteration)];
            int N = (int)Math.Pow(2, NumberOfIteration);
            for (int k = 1; k < _W.Length; k++)
            {

                _W[k] = new Complex(0, 0);
                _W[k].fromExp(1, -2 * Math.PI * k / N);

            }
            _W[0] = new Complex(1, 0);
        }
    }
}

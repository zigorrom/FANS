using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;
using System.Drawing.Drawing2D;
namespace FANS.classes
{
    class NoiseSpectra_Graph
    {
        private ZedGraphControl _zgc;
        private GraphPane _zgcGraphPane;
        private ZedGraphController _zgcController;
        private System.Drawing.Color rawSpectraColor, dividedSpectraColor,previousSpectraColor,ThermalNoiseSpectraColor;
        public NoiseSpectra_Graph(ZedGraphControl zgc)
        {
            this._zgc = zgc;
            this._zgcGraphPane = this._zgc.GraphPane;
            _zgcController = new ZedGraphController(zgc);
            _zgcController.DisableTitle();

            //this._zgcGraphPane.XAxis.Title.Text = "Time (ms)";
            this.SetAxes();
            
            //this._zgcGraphPane.YAxis.Cross = 0;
            rawSpectraColor = System.Drawing.Color.Black;
            dividedSpectraColor = System.Drawing.Color.Green;
            previousSpectraColor = System.Drawing.Color.Violet;
            ThermalNoiseSpectraColor = System.Drawing.Color.Blue;

            //_channelColors = new System.Drawing.Color[4] { System.Drawing.Color.Black, System.Drawing.Color.Green, System.Drawing.Color.Blue, System.Drawing.Color.Red };
        }

        public void SetAxes()
        {

            this._zgcGraphPane.YAxis.Title.Text = "Sv (V)";
            this._zgcGraphPane.XAxis.Title.Text = "Frequency (Hz)";
            this._zgcGraphPane.XAxis.Scale.MinAuto = false;
            this._zgcGraphPane.XAxis.Scale.MaxAuto = false;
            this._zgcGraphPane.YAxis.Scale.MinAuto = false;
            this._zgcGraphPane.YAxis.Scale.MaxAuto = false;

            this._zgcGraphPane.XAxis.Scale.Min = 0.1;
            this._zgcGraphPane.XAxis.Scale.Max = 1e06;
            this._zgcGraphPane.XAxis.Scale.MajorStep = 1;
            this._zgcGraphPane.XAxis.Scale.MinorStep = 10;
            this._zgcGraphPane.XAxis.Type = AxisType.Log;
            this._zgcGraphPane.YAxis.Type = AxisType.Log;
            //this._zgcGraphPane.XAxis.Cross = 0;
            //this._zgcGraphPane.XAxis.Scale.Min = 0;
            this._zgcGraphPane.YAxis.Scale.MajorStep = 1;
            this._zgcGraphPane.YAxis.Scale.MinorStep = 10;
            this.Refresh();

        }
        public void Refresh()
        {
            this._zgcGraphPane.YAxis.Scale.MinAuto = true;
            this._zgcGraphPane.YAxis.Scale.MaxAuto = true;
            
            _zgc.AxisChange();
            _zgc.Invalidate();
        }

        public void Replot()
        {
            _zgc.Invalidate();
        }
        public void Clear(string name = "")
        {
            _zgcController.Clear(name);

        }

        public void SubscribeForNoiseSpectra()
        {
            AllCustomEvents.Instance.NoiseSpectraArrived += NoiseSpectraArrived;
            AllCustomEvents.Instance.LastNoiseSpectraArrived += FinalNoiseSpectraArrived;
        }
        public void UnsubscribeFromNoiseSpectra()
        {
            AllCustomEvents.Instance.LastNoiseSpectraArrived -= FinalNoiseSpectraArrived;
            AllCustomEvents.Instance.NoiseSpectraArrived -= NoiseSpectraArrived;
        }
        private void FinalNoiseSpectraArrived(object sender, FinalNoiseEventArgs data)
        {
            this.Clear("Measured VSD");
            this.Clear("Final VSD");
            this.AddNoise(data.RawData, rawSpectraColor, "Measured VSD");
            this.AddNoise(data.FinalData, dividedSpectraColor, "Final VSD");
            this.Refresh();
        }
        private void NoiseSpectraArrived(object sender, NoiseEventArgs data)
        {
            this.Clear("Measured VSD");
            this.AddNoise(data.data, rawSpectraColor, "Measured VSD");
            this.Refresh();
        }
        public void AddNoise(PointPairList a, System.Drawing.Color c, string name = "Noise1")
        {

            _zgcController.AddCurve(a, c, name);

        }
        public void AddNoiseComponent(PointPairList a, System.Drawing.Color c, string name = "Noise1")
        {

            LineItem curve = this.getCurveByName(name);
            if (curve == null)
                curve = _zgcGraphPane.AddCurve(name, a, c, SymbolType.None);
            else
                curve.Points = a;
            curve.Line.Style = DashStyle.Dot;
            this.Replot();

        }
        public CurveList Curves
        {
            get
            {
                return this._zgcGraphPane.CurveList;
            }
        }
        public LineItem getCurveByName(string name = "")
        {

            return _zgcController.getCurveByName(name);
        }
    }
}

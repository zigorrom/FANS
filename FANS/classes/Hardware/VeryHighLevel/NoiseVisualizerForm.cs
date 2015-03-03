using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FANS.classes
{
    public partial class NoiseVisualizerForm : Form
    {
        NoiseSpectra_Graph GraphController;
        public NoiseVisualizerForm()
        {
            InitializeComponent();
            GraphController = new NoiseSpectra_Graph(zedGraphControl1);
        }
        public void SubscribeForNoiseSpectra()
        {
            GraphController.SubscribeForNoiseSpectra();
        }

        public void SubscribeForStatusMessages()
        {
            AllCustomEvents.Instance.NoiseMeasurementStatusChanged += Instance_NoiseMeasurementStatusChanged;
        }

        public void UnsubscribeFromStatusMessages()
        {
            AllCustomEvents.Instance.NoiseMeasurementStatusChanged -= Instance_NoiseMeasurementStatusChanged;
        }

        void Instance_NoiseMeasurementStatusChanged(object sender, StatusEventArgs e)
        {
            SetStatusBarStateThreadSafe(e);
            if ((e.Status == "Measurement Aborted") || (e.Status == "Measurement Finished Successfully") || (e.Status == "Measurement Stopped"))
                AllCustomEvents.Instance.MeasurementStatusChanged -= Instance_NoiseMeasurementStatusChanged;
        }

        private void SetStatusBarStateThreadSafe(StatusEventArgs e)
        {
            if (toolStripProgressBar1.GetCurrentParent().InvokeRequired)
            {

                Action<StatusEventArgs> deleg = new Action<StatusEventArgs>(SetStatusBarStateThreadSafe);
                toolStripProgressBar1.GetCurrentParent().Invoke(deleg, new object[] { e });
            }
            else
            {
                toolStripProgressBar1.Minimum = e.Min;
                toolStripProgressBar1.Maximum = e.Max;
                toolStripProgressBar1.Value = e.Current;
                toolStripLabel1.Text = e.Status;
            }
        }

        public void UnsubscribeFromNoiseSpectra()
        {
            GraphController.UnsubscribeFromNoiseSpectra();
        }
        public void Clear()
        {
            GraphController.Clear();
        }
        public void Rescale()
        {
            GraphController.SetAxes();
        }

    }
}

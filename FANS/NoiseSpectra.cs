using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FANS.classes;
namespace FANS
{
    public partial class NoiseSpectra : Form
    {
        NoiseSpectra_Graph GraphController;
        NoiseSpectraMeasurement NoiseMeasurement;
        public NoiseSpectra()
        {
            InitializeComponent();
            GraphController = new NoiseSpectra_Graph(zedGraphControl1);
            NoiseMeasurement = new NoiseSpectraMeasurement();
        }

        private void NoiseSpectraClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Height - 22;
        }

        public void Measure(bool OpenFolderBrowser)
        {
            AllCustomEvents.Instance.NoiseMeasurementStatusChanged += StatusMessageArrived;
            GraphController.SubscribeForNoiseSpectra();
            initFileSystem();
            SetAveragingAndScreenUpdate();
            if (OpenFolderBrowser)
                OpenFolder_Click(this, new EventArgs());
            NoiseMeasurement.MakeNoiseMeasurement(false);
            
        }
        
        //make private
        private void Start_Click(object sender, EventArgs e)
        {
            if (MeasurementThread.Instance.MeasurementRunning)
            {
                AllCustomEvents.Instance.MeasurementFinished += Start_Click;
                MeasurementThread.Instance.MeasurementRunning = false; return;
            }
            else
                AllCustomEvents.Instance.MeasurementFinished -= Start_Click;
            //Measure();
            AllCustomEvents.Instance.NoiseMeasurementStatusChanged += StatusMessageArrived;

            GraphController.SubscribeForNoiseSpectra();
            initFileSystem();
            SetAveragingAndScreenUpdate();
            MeasurementThread.Instance.StartThread(NoiseMeasurement.MakeNoiseMeasurement,true);
        }


        // thread problem - need invoke
        private void initFileSystem()
        {
            var func = new Action(() => {
                if (filename_textbox.Text == "") filename_textbox.Text = "RandomFile.dat";
                while (NoiseMeasurementFileManager.Instance.FileExists(filename_textbox.Text))
                {
                    filename_textbox.Text = NoiseMeasurementFileManager.Instance.suggestFileNameWithIncrement(filename_textbox.Text);
                }
                NoiseMeasurementFileManager.Instance.prepareForNoiseMeasurement(filename_textbox.Text, ImportantConstants.Rload, ImportantConstants.K_Ampl_first_Channel);    
            });
            filename_textbox.Invoke(func);

            
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            MeasurementThread.Instance.MeasurementRunning = false;
            
        }
        
        private void OpenFolder_Click(object sender, EventArgs e)
        {
            this.Invoke(new Action<FolderBrowserDialog>(
                (FolderBrowserDialog fbd) =>
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        FolderName.Text = fbd.SelectedPath;
                        NoiseMeasurementFileManager.Instance.workfolder = fbd.SelectedPath;
                    }
                }),folderBrowserDialog1);
            
        }

        private void StatusMessageArrived(object sender, StatusEventArgs e)
        {
            SetStatusBarStateThreadSafe(e);
            if ((e.Status == "Measurement Aborted") || (e.Status == "Measurement Finished Successfully") || (e.Status == "Measurement Stopped"))
                AllCustomEvents.Instance.MeasurementStatusChanged -= StatusMessageArrived;

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
                toolStripStatusLabel1.Text = e.Status;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            GraphController.Clear();
        }

        private void oscilloscope_toolstrip_rescale_Click(object sender, EventArgs e)
        {
            GraphController.SetAxes();
        }

        private void SetAveragingAndScreenUpdate()
        
        {
            try
            {
                NoiseMeasurement.Averaging = Convert.ToInt16(NumberOfSpectra.Text);
                NoiseMeasurement.SpectraPerShow = Convert.ToInt16(SpectraPerShow.Text);
            }
            catch (Exception se) { MessageBox.Show(se.Message); NumberOfSpectra.Text = "100"; SpectraPerShow.Text = "10"; }
        }

        private void NumberOfSpectra_TextChanged(object sender, EventArgs e)
        {
            SetAveragingAndScreenUpdate();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NoiseMeasurement.Calibrate();
        }

        
    }
}

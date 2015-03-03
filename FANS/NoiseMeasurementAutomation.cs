using FANS.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace FANS
{


    public partial class NoiseMeasurementAutomation : Form
    {
        /// <summary>
        /// Explains which parameter changes in outer cycle and which in inner.
        /// </summary>
        internal enum MeasurementPrinciple
        {
            None,
            ScanSample,
            ScanGate
        }
        /// <summary>
        /// Field which holds current Measurement Principle.
        /// </summary>
        private MeasurementPrinciple m_measurementPrinciple;
        
        /// <summary>
        /// Sample voltage applier.
        /// </summary>
        private MotorizedVoltageApplier m_SampleVoltageApplier;
        /// <summary>
        /// Gate voltage applier.
        /// </summary>
        private MotorizedVoltageApplier m_GateVoltageApplier;
        /// <summary>
        /// Indicates whether measurement is in progress
        /// </summary>
        public bool NoiseMeasurementInProgress { get; private set; }
        
        //private VoltageMeasurement m_VoltageMeasurementController;
        
        /// <summary>
        /// Form which implement noise measurement.
        /// </summary>
        private NoiseSpectra m_NoiseSpectraMeasurementForm;

        /// <summary>
        /// Range of voltages to enumerate in outer cycle. Dependent on Measurement Principle.
        /// </summary>
        private DoubleRangeBase m_OuterRange;
        /// <summary>
        /// Range of voltages to enumerate in inner cycle. Dependent on Measurement Principle.
        /// </summary>
        private DoubleRangeBase m_InnerRange;
        /// <summary>
        /// Voltage applier. Depending on Measurement Principle - Gate or Sample Voltage Applier.
        /// </summary>
        private MotorizedVoltageApplier m_InnerMotorizedApplier;
        /// <summary>
        /// Voltage applier. Depending on Measurement Principle - Gate or Sample Voltage Applier.
        /// </summary>
        private MotorizedVoltageApplier m_OuterMotorizedApplier;

        /// <summary>
        /// Event which reises on measurement done.
        /// </summary>
        public event EventHandler<EventArgs> NoiseMeasurementDone;

        ~NoiseMeasurementAutomation()
        {
            /// Insert Code to set 0 on all outputs.
        }

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="NoiseSpectraMeasurementForm">The form which implements noise spectrum measurement.</param>
        public NoiseMeasurementAutomation(NoiseSpectra NoiseSpectraMeasurementForm)
        {

            InitializeComponent();
            
            
            /// Initial state for Measurement in progress and button
            NoiseMeasurementInProgress = false;
            ToggleMeasurementButton();
            ///

            
            /// Event Handlers
            NoiseMeasurementDone += NoiseMeasurementAutomation_NoiseMeasurementDone;
            ///

            /// Noise Spectra form
            m_NoiseSpectraMeasurementForm = NoiseSpectraMeasurementForm;
            ///

            /// Initializing Voltage appliers
            m_SampleVoltageApplier = new MotorizedVoltageApplier(FeedbackChannel1.SelectedIndex + 1, MotorChannel1.SelectedIndex + 1, RelayChannel1.SelectedIndex + 1, Double.Parse(Tolerance1.Text, ImportantConstants.NumberFormat()));
            m_GateVoltageApplier = new MotorizedVoltageApplier(FeedbackChannel2.SelectedIndex + 1, MotorChannel2.SelectedIndex + 1, RelayChannel2.SelectedIndex + 1, Double.Parse(Tolerance2.Text, ImportantConstants.NumberFormat()));
            ///

            /// Initialization Channels
            FeedbackChannel1.SelectedIndex = 0;
            FeedbackChannel2.SelectedIndex = 3;
            MotorChannel1.SelectedIndex = 0;
            MotorChannel2.SelectedIndex = 8;
            RelayChannel1.SelectedIndex = 1;
            RelayChannel2.SelectedIndex = 9;
            SetChannels();
            ///

            /// Measurement Principle
            ChangeMeasurementPrinciple(MeasurementPrinciple.ScanSample);
            ///
            
            /// Range initialization
            m_OuterRange = MeasurementInputControl_1.Range;
            m_InnerRange = MeasurementInputControl_2.Range;
            ///
        }

        /// <summary>
        /// NoiseMeasurementDone event handler
        /// </summary>
        private void NoiseMeasurementAutomation_NoiseMeasurementDone(object sender, EventArgs e)
        {
            NoiseMeasurementInProgress = false;
            ToggleMeasurementButton();
            MessageBox.Show("Measurement done.");
        }

        /// <summary>
        /// NoiseMeasurementDone invoker
        /// </summary>
        private void OnNoiseMeasurementDone()
        {
            if (null != NoiseMeasurementDone)
                NoiseMeasurementDone(this, new EventArgs());
        }

        /// <summary>
        /// Toggles MeasurementButton.Click event to either StartMeasure_Click or StopMeasure_Click handler and changes Text property.
        /// </summary>
        private void ToggleMeasurementButton()
        {
            var func = new Action<bool>((x) =>
                {
                    if (x)
                    {
                        MeasurementButton.Click -= StartMeasure_Click;
                        MeasurementButton.Click += StopMeasure_Click;
                        MeasurementButton.Text = "Stop mea";
                    }
                    else
                    {
                        MeasurementButton.Click -= StopMeasure_Click;
                        MeasurementButton.Click += StartMeasure_Click;
                        MeasurementButton.Text = "Start mea";
                    }
                });
            if (MeasurementButton.InvokeRequired)
                MeasurementButton.Invoke(func, NoiseMeasurementInProgress);
            else
                func(NoiseMeasurementInProgress);
        }
        /// <summary>
        /// StopMeasure handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopMeasure_Click(object sender, EventArgs e)
        {
            if (!NoiseMeasurementInProgress)
                return;

            NoiseMeasurementInProgress = false;
            /// Abort processing in noise measurement form
            MeasurementThread.MeasurementInProgress = false;
            
            ToggleMeasurementButton();
        }
        /// <summary>
        /// StartMeasure handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartMeasure_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (NoiseMeasurementInProgress)
                    return;

                switch (m_measurementPrinciple)
                {
                    case MeasurementPrinciple.ScanSample:
                        {
                            m_OuterMotorizedApplier = m_GateVoltageApplier;
                            m_InnerMotorizedApplier = m_SampleVoltageApplier;
                        }
                        break;
                    case MeasurementPrinciple.ScanGate:
                        {
                            m_OuterMotorizedApplier = m_SampleVoltageApplier;
                            m_InnerMotorizedApplier = m_GateVoltageApplier;
                        }
                        break;
                    case MeasurementPrinciple.None:
                    default:
                        return;
                }
                //ImportantConstants.K_Ampl_first_Channel = 1;
                //ImportantConstants.Rload = 5000;
                m_OuterRange = MeasurementInputControl_1.Range;
                m_InnerRange = MeasurementInputControl_2.Range;


                SetChannels();
                m_GateVoltageApplier.Tolerance = 0.002;
                m_SampleVoltageApplier.Tolerance = 0.002;
                m_NoiseSpectraMeasurementForm.Visible = true;

                PrepareProgressBars();
                NoiseMeasurementInProgress = true;
                ToggleMeasurementButton();
                MakeMeasurementInThread();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        /// <summary>
        /// Enqueue MeasurementCycle method invokation in MeasurementThread. If measurement thread is not busy invokes method directly.
        /// </summary>
        private void MakeMeasurementInThread()
        {
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += Instance_MeasurementFinished;
                return;
            }
            MeasurementThread.Instance.StartThread(MeasurementCycle);
        }
        /// <summary>
        /// Callback for MeasurementFinished event.
        /// </summary>
        private void Instance_MeasurementFinished(object sender, EventArgs e)
        {
            AllCustomEvents.Instance.MeasurementFinished -= Instance_MeasurementFinished;
            MakeMeasurementInThread();
        }
        /// <summary>
        /// Main measurement cycle.
        /// </summary>
        private void MeasurementCycle()
        {
            AI_Channels.Instance.DC_Average = 100;
            var SetVoltageCommandOuter = new SetVoltageCommand(m_OuterMotorizedApplier);
            var SetVoltageCommandInner = new SetVoltageCommand(m_InnerMotorizedApplier);
            
            bool OpenFolderBrowser = true;
            /// PROGRESS VARIABLES
            //var OuterProcessedPointsCounter = 0;
            //var InnerProcessedPointsCounter = 0;
            var ProcessCounter = 0;
            ///

            System.Diagnostics.Debug.WriteLine("Mea start!");
            foreach (var outer_value in m_OuterRange)
            {
                if (!MeasurementThread.MeasurementInProgress)
                    return;
                SetVoltageCommandOuter.VoltageToSet = outer_value;
                SetVoltageCommandOuter.Execute();
                Thread.Sleep(200);
                foreach (var inner_value in m_InnerRange)
                {
                    if (!MeasurementThread.MeasurementInProgress)
                        return;
                    SetVoltageCommandInner.VoltageToSet = inner_value;
                    SetVoltageCommandInner.Execute();
                    Thread.Sleep(500);
                    System.Diagnostics.Debug.WriteLine(String.Format("Outer:{0}, Inner{1}", outer_value, inner_value));
                    m_NoiseSpectraMeasurementForm.Measure(OpenFolderBrowser);
                    OpenFolderBrowser = false;


                    ///REPORTING PROGRESS
                    ProcessCounter++;
                    ReportProgress(ProcessCounter / m_InnerRange.PointsCount, ProcessCounter % m_InnerRange.PointsCount);
                    //ReportProgress(OuterProcessedPointsCounter,++InnerProcessedPointsCounter);

                    ///
                }

                

                //Thread.Sleep(200);
            }
            ///Event On MeasurementDone
            OnNoiseMeasurementDone();
            ///
            ReportProgress(0, 0);
            System.Diagnostics.Debug.WriteLine("Mea stop!");
        }
        
        /// <summary>
        /// Set Initial state for progress bars.
        /// </summary>
        private void PrepareProgressBars()
        {
            OuterProgressBar.Maximum = m_OuterRange.PointsCount;
            OuterProgressBar.Minimum = 0;
            OuterProgressBar.Value = 0;
            InnerProgressBar.Maximum = m_InnerRange.PointsCount;
            InnerProgressBar.Minimum = 0;
            InnerProgressBar.Value = 0;
        }
        /// <summary>
        /// Reports main measurement cycle progress.
        /// </summary>
        /// <param name="OuterProcessedPointsCounter">Current outer cycle measurement point number. Value within 0 and OuterRange.PointsCount.  </param>
        /// <param name="InnerProcessedPointsCounter">Current inner cycle measurement point number. Value within 0 and InnerRange.PointsCount</param>
        private void ReportProgress(int OuterProcessedPointsCounter, int InnerProcessedPointsCounter)
        {
            var func = new Action<ProgressBar, int>((pb, val) =>
            {
                if (val < pb.Maximum)
                    pb.Value = val;
                else
                    pb.Value = pb.Maximum;
            });

            if (OuterProgressBar.InvokeRequired)
                OuterProgressBar.Invoke(func, OuterProgressBar, OuterProcessedPointsCounter);
            else
                func(OuterProgressBar, OuterProcessedPointsCounter);

            if (InnerProgressBar.InvokeRequired)
                InnerProgressBar.Invoke(func, InnerProgressBar, InnerProcessedPointsCounter);
            else
                func(InnerProgressBar, InnerProcessedPointsCounter);
        }

        

        
        /// <summary>
        /// Changes MeasurementPrinciple.
        /// </summary>
        /// <param name="mp">Desired principle</param>
        private void ChangeMeasurementPrinciple(MeasurementPrinciple mp)
        {
            if (m_measurementPrinciple == mp)
                return;
            m_measurementPrinciple = mp;

            switch (m_measurementPrinciple)
            {
                case MeasurementPrinciple.ScanSample:
                    {
                        MeasurementInputControl_1.MeasuringValueName = "Gate Voltage";
                        MeasurementInputControl_2.MeasuringValueName = "Sample Voltage";
                        var range = MeasurementInputControl_1.Range;
                        MeasurementInputControl_1.Range = MeasurementInputControl_2.Range;
                        MeasurementInputControl_2.Range = range;

                    } break;
                case MeasurementPrinciple.ScanGate:
                    {
                        MeasurementInputControl_1.MeasuringValueName = "Sample Voltage";
                        MeasurementInputControl_2.MeasuringValueName = "Gate Voltage";
                        var range = MeasurementInputControl_1.Range;
                        MeasurementInputControl_1.Range = MeasurementInputControl_2.Range;
                        MeasurementInputControl_2.Range = range;
                    } break;
                    
            }
            RefreshContent();
        }
        /// <summary>
        /// Refresh content in MeasurementInputControls.
        /// </summary>
        private void RefreshContent()
        {
            MeasurementInputControl_1.RefreshContent();
            MeasurementInputControl_2.RefreshContent();
        }
        /// <summary>
        /// On ScanSourceMeasurementRadioButton changed check status.
        /// </summary>
        private void ScanSourceMeasurementRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
                ChangeMeasurementPrinciple(MeasurementPrinciple.ScanSample);

        }
        /// <summary>
        /// On ScanGateMeasurementRadioButton changed check status.
        /// </summary>
        private void ScanGateVoltageMeasurementRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
                ChangeMeasurementPrinciple(MeasurementPrinciple.ScanGate);
        }
        /// <summary>
        /// Sets channels for Gate and Sample voltage appliers.
        /// </summary>
        private void SetChannels()
        {
            m_SampleVoltageApplier.SetChannels(FeedbackChannel1.SelectedIndex + 1, MotorChannel1.SelectedIndex + 1, RelayChannel1.SelectedIndex + 1);
            m_GateVoltageApplier.SetChannels(FeedbackChannel2.SelectedIndex + 1, MotorChannel2.SelectedIndex + 1, RelayChannel2.SelectedIndex + 1);
        }

       

        


    }
}

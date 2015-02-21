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
    public partial class AutomatedApplyVoltage : Form
    {
        private bool SettingInProgress;
        private VoltageMeasurement _VoltageMeasurementController;
        private ApplyingVoltage _SampleVoltage, _GateVoltage;
        public AutomatedApplyVoltage()
        {
            InitializeComponent();
            _VoltageMeasurementController = new VoltageMeasurement();
            FeedbackChannel1.SelectedIndex = 0;
            FeedbackChannel2.SelectedIndex = 3;
            MotorChannel1.SelectedIndex = 0;
            MotorChannel2.SelectedIndex = 2;
            RelayChannel1.SelectedIndex = 1;
            RelayChannel2.SelectedIndex = 3;
            _SampleVoltage = new ApplyingVoltage(FeedbackChannel1.SelectedIndex + 1, MotorChannel1.SelectedIndex + 1, RelayChannel1.SelectedIndex + 1,Double.Parse(Tolerance1.Text,ImportantConstants.NumberFormat()));
            _GateVoltage = new ApplyingVoltage(FeedbackChannel2.SelectedIndex + 1, MotorChannel2.SelectedIndex + 1, RelayChannel2.SelectedIndex + 1,Double.Parse(Tolerance2.Text,ImportantConstants.NumberFormat()));
        }
        private void CollectValuesFromForm()
        {
            _SampleVoltage.setChannels(FeedbackChannel1.SelectedIndex + 1, MotorChannel1.SelectedIndex + 1, RelayChannel1.SelectedIndex + 1);
            _GateVoltage.setChannels(FeedbackChannel2.SelectedIndex + 1, MotorChannel2.SelectedIndex + 1, RelayChannel2.SelectedIndex + 1);
            double Tolerance;
            try { Tolerance = Double.Parse(Tolerance1.Text, ImportantConstants.NumberFormat()); }
            catch (Exception e) { Tolerance = 0.005; MessageBox.Show(e.Message); }
            _SampleVoltage.setTolerance(Tolerance);

            try { Tolerance = Double.Parse(Tolerance2.Text, ImportantConstants.NumberFormat()); }
            catch (Exception e) { Tolerance = 0.005; MessageBox.Show(e.Message); }
            _GateVoltage.setTolerance(Tolerance);

        }
        //making form movable
        #region MovableForm

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        //--------------------------
        #endregion
        //--------------------------makingThreadSafeCallsForControls
        #region Thread Safe Calls To Form Controls
        delegate void SetTextCallback(TextBox a, string text);
        private void SetText(TextBox a, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (a.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.BeginInvoke(d, new object[] { a, text });
            }
            else
            {
                a.Text = text;
            }
        }


        #endregion

        private void formClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;

        }

        private void TimerTickMeasureVoltage(object sender, EventArgs e)
        {
            _VoltageMeasurementController.MeasureVoltageNormallyInThread();
        }
        private int FeedbackChannel1_SelectedIndex;
        private int FeedbackChannel2_SelectedIndex;
        private void VoltagesArrived(object sender, MeasuredVoltages_DataArrivedEventArgs data)
        {
            SetText(ActualSampleVoltage, data.Voltages[FeedbackChannel1_SelectedIndex].ToString("G6"));
            SetText(GateActualVoltage, data.Voltages[FeedbackChannel2_SelectedIndex].ToString("G6"));
            
        }


        private void FeedbackChannel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedbackChannel2_SelectedIndex = FeedbackChannel2.SelectedIndex;
        }

        private void FeedbackChannel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedbackChannel1_SelectedIndex = FeedbackChannel1.SelectedIndex;
        }


        private void visibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                AllCustomEvents.Instance.VoltagesMeasurementDone += VoltagesArrived;
                timer1.Start();
                
            }
            else
            {
                AllCustomEvents.Instance.VoltagesMeasurementDone -= VoltagesArrived;
                timer1.Stop();
                
            }
        }

        private void StopGoing1_Click(object sender, EventArgs e)
        {
            if (SettingInProgress)
            {
                MeasurementThread.Instance.StopThread();
                SettingInProgress = false;
            
            }
        }

        private void SetSampleVoltage_Click(object sender, EventArgs e)
        {
            
            SettingInProgress = true;
            double Target = 0;
         
            try { Target = Double.Parse(TargetSampleVoltage.Text, ImportantConstants.NumberFormat()); }
            catch (Exception es) { MessageBox.Show(es.Message); return; }
            this.CollectValuesFromForm();
            _SampleVoltage.ApplyVoltageInThread(Target);
        }

        private void SetGateVoltage_Click(object sender, EventArgs e)
        {
         
            SettingInProgress = true;
            double Target = 0;
            try { Target = Double.Parse(GateTargetVoltage.Text, ImportantConstants.NumberFormat()); }
            catch (Exception es) { MessageBox.Show(es.Message); return; }
            this.CollectValuesFromForm();
            _GateVoltage.ApplyVoltageInThread(Target);
        }

        private void SwitchSampleVoltage_Click(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += SwitchSampleVoltage_Click; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= SwitchSampleVoltage_Click;
            double Actual = 0;
            try { Actual = Double.Parse(ActualSampleVoltage.Text, ImportantConstants.NumberFormat()); }
            catch (Exception es) { MessageBox.Show(es.Message); return; }
            int sign = Math.Sign(Actual);
            _SampleVoltage.SwitchVoltageDirectionInThread(-sign);
        }

        private void SwitchGateVoltage_Click(object sender, EventArgs e)
        {
            if (MeasurementThread.MeasurementInProgress) { AllCustomEvents.Instance.MeasurementFinished += SwitchGateVoltage_Click; return; }
            else AllCustomEvents.Instance.MeasurementFinished -= SwitchGateVoltage_Click;

            int sign = Sign(GateActualVoltage.Text);
            if (sign == 0) return;
            _GateVoltage.SwitchVoltageDirectionInThread(-sign);
        }

        private int Sign(string text)
        {
            double Actual = 0;
            try { Actual = Double.Parse(text, ImportantConstants.NumberFormat()); }
            catch (Exception es) { MessageBox.Show(es.Message);  return 0; }
            return Math.Sign(Actual);

        }
        private bool _VoltageChanging;
        private MouseEventArgs _e;
        private string What_to_call;
        private void WaitForMeasurementIsFinished(object sender, EventArgs e)
        {
            switch (What_to_call)
            {
                case "SampleForward": ForwardMouseDown(this, _e); break;
                case "SampleFastForward": SampleFastForwardMouseDown(this, _e); break;
                case "SampleBackward": SampleBackwardMouseDown(this, _e); break;
                case "SampleFastBackward": SampleFastBackwardMouseDown(this, _e); break;
                case "GateForward": GateForwardMouseDown(this, _e); break;
                case "GateFastForward": GateFastForwardMouseDown(this, _e); break;
                case "GateBackward": GateBackwardMouseDown(this, _e); break;
                case "GateFastBackward": GateFastBackwardMouseDown(this, _e); break;
            }
        }
        private void ForwardMouseDown(object sender, MouseEventArgs e)
        {
            
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "SampleForward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;
            if (Sign(ActualSampleVoltage.Text) > 0)
                _SampleVoltage.IncreaseVoltageAbsoluteValue();
            else
                _SampleVoltage.DecreaseVoltageAbsoluteValue();
            
        }

        private void ForwardBackwardSampleMouseUp(object sender, MouseEventArgs e)
        {
            
            if (_VoltageChanging)
              {
                MeasurementThread.Instance.StopThread();
                _SampleVoltage.StopChangingVoltageAbsoluteValue();
              }
                _VoltageChanging = false;    
        }

        private void SampleFastForwardMouseDown(object sender, MouseEventArgs e)
        {
            
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "SampleFastForward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;
            
            if (Sign(ActualSampleVoltage.Text) > 0)
                _SampleVoltage.IncreaseVoltageAbsoluteValueFast();
            else
                _SampleVoltage.DecreaseVoltageAbsoluteValueFast();
        }

        private void SampleFastBackwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "SampleFastBackward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(ActualSampleVoltage.Text) > 0)
                _SampleVoltage.DecreaseVoltageAbsoluteValueFast();
            else
                _SampleVoltage.IncreaseVoltageAbsoluteValueFast();
        }

        private void SampleBackwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "SampleBackward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(ActualSampleVoltage.Text) > 0)
                _SampleVoltage.DecreaseVoltageAbsoluteValue();
            else
                _SampleVoltage.IncreaseVoltageAbsoluteValue();
        }

        private void GateFastForwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "GateFastForward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(GateActualVoltage.Text) > 0)
                _GateVoltage.IncreaseVoltageAbsoluteValueFast();
            else
                _GateVoltage.DecreaseVoltageAbsoluteValueFast();
        }

        private void GateForwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "GateForward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(GateActualVoltage.Text) > 0)
                _GateVoltage.IncreaseVoltageAbsoluteValue();
            else
                _GateVoltage.DecreaseVoltageAbsoluteValue();
        }

        private void GateBackwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "GateBackward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(GateActualVoltage.Text) > 0)
                _GateVoltage.DecreaseVoltageAbsoluteValue();
            else
                _GateVoltage.IncreaseVoltageAbsoluteValue();
        }

        private void GateFastBackwardMouseDown(object sender, MouseEventArgs e)
        {
            CollectValuesFromForm();
            if (MeasurementThread.MeasurementInProgress)
            {
                AllCustomEvents.Instance.MeasurementFinished += WaitForMeasurementIsFinished; _e = e; What_to_call = "GateFastBackward";
                return;
            }
            else
            {
                AllCustomEvents.Instance.MeasurementFinished -= WaitForMeasurementIsFinished;
            }
            _VoltageChanging = true;

            if (Sign(GateActualVoltage.Text) > 0)
                _GateVoltage.DecreaseVoltageAbsoluteValueFast();
            else
                _GateVoltage.IncreaseVoltageAbsoluteValueFast();
        }

        private void GateFowardBackwardMouseUp(object sender, MouseEventArgs e)
        {
            if (_VoltageChanging)
            {
                MeasurementThread.Instance.StopThread();
                _GateVoltage.StopChangingVoltageAbsoluteValue();
            }
            _VoltageChanging = false;    
        }

        
       

        

    }
}

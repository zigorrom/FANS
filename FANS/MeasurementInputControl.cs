using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FANS.classes;
using System.Globalization;


namespace FANS
{

    public partial class MeasurementInputControl : UserControl
    {
        private DoubleRangeBase m_range;
       
        public string MeasuringValueName 
        { 
            get { return MeasurementInputGroup.Text; }
            set { MeasurementInputGroup.Text = value; }
        }

        
        
        private Dictionary<TextBox, string> m_ErrorDictionary;
        //private 


        public MeasurementInputControl()
        {    
            InitializeComponent();
            CanFireTextChangedEvent = true;
            m_range = new DoubleRangeBase(0, 0, 0);
            m_ErrorDictionary = new Dictionary<TextBox, string>();
            RefreshContent();
        }

        private bool CheckCorrectNextInputCharOnKeyPress(object sender, KeyPressEventArgs e, bool IncludeNegativeValues, bool IncludeRealNumbers)
        {
            var tb = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
                return false;
            }

            if ((e.KeyChar == '.') && ((tb.Text.IndexOf('.') > -1)||!IncludeRealNumbers))
            {
                e.Handled = true;
                return false;
            }

            int IndexOfMinus = tb.Text.IndexOf('-');

            if((e.KeyChar == '-') && ((IndexOfMinus > -1)||(tb.SelectionStart!=0)||!IncludeNegativeValues))
            {
                e.Handled = true;
                return false;
            }

            if ((IndexOfMinus > -1) && (tb.SelectionStart + tb.SelectionLength <= IndexOfMinus))
            {
                e.Handled = true;
                return false;
            }
            return true;

        }

        private bool SetValue(TextBox tb, out int value, bool ErrorNotification)
        {
            var style = NumberStyles.Number | NumberStyles.AllowLeadingSign;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            if (!int.TryParse(tb.Text,style,culture, out value))
            {
                if (ErrorNotification)
                    MessageBox.Show("Incorrect format: " + tb.Text);

                m_ErrorDictionary[tb] ="IncorrectFormat";
                return false;
            }
            m_ErrorDictionary.Remove(tb);
            return true;
        }

        private bool SetValue(TextBox tb, out double value, bool ErrorNotification)
        {
            var style = NumberStyles.Number | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign ;
            var culture = CultureInfo.CreateSpecificCulture("en-US");
            if (!double.TryParse(tb.Text, style,culture,out value))
            {
                if (ErrorNotification)
                    MessageBox.Show("Incorrect format: " + tb.Text);
                m_ErrorDictionary[tb] = "IncorrectFormat";
                return false;
            }
            m_ErrorDictionary.Remove(tb);
            return true;
        }

        public void RefreshContent()
        {
            CanFireTextChangedEvent = false;
            MeasureFromTextBox.Text = m_range.Start.ToString();
            MeasureToTextBox.Text = m_range.End.ToString();
            MeasurementStepTextBox.Text = m_range.Step.ToString();
            MeasurementsNumberTextBox.Text = m_range.PointsCount.ToString();
            CanFireTextChangedEvent = true;

            
        }

        /// <summary>
        /// Gets the range for measurement. In the case of invalid form input throws ArgumentException.
        /// </summary>
        public DoubleRangeBase Range
        {
            set
            {
                if (null == value)
                    throw new ArgumentException();
                m_range = value;
            }
            get
            {
                if (m_ErrorDictionary.Count > 0)
                    throw new ArgumentException(string.Join(";",m_ErrorDictionary.Select(x=>String.Format("{0}-{1}",x.Key.Name,x.Value))));
                return m_range;
            } 
        }
        //
        //  Events
        //
        private void MeasureFromTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckCorrectNextInputCharOnKeyPress(sender, e,true,true);
        }

        private void MeasureToTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckCorrectNextInputCharOnKeyPress(sender, e,true,true);
        }

        private void MeasurementStepTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckCorrectNextInputCharOnKeyPress(sender, e,false,true);
        }

        private void MeasurementsNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckCorrectNextInputCharOnKeyPress(sender, e,false,false);
        }

        private bool CanFireTextChangedEvent;

        private void MeasureFromTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CanFireTextChangedEvent)
                return;

            var tb = (TextBox)sender;
            double val;
            if (!SetValue(tb, out val, false))
                return;
            Range.Start = val;
            //RefreshContent();
        }

        private void MeasureToTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CanFireTextChangedEvent)
                return;

            var tb = (TextBox)sender;
            double val;
            if (!SetValue(tb, out val, false))
                return;
            Range.End = val;
            //RefreshContent();
        }

        private void MeasurementStepTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CanFireTextChangedEvent)
                return;

            var tb = (TextBox)sender;
            double val;
            if (!SetValue(tb, out val, false))
                return;
            //if (double.TryParse(text, out val))
            Range.Step = val;

            CanFireTextChangedEvent = false;
            MeasurementsNumberTextBox.Text = Range.PointsCount.ToString();
            CanFireTextChangedEvent = true;
        }

        private void MeasurementsNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!CanFireTextChangedEvent)
                return;

            var tb = (TextBox)sender;
            int val;
            if (!SetValue(tb, out val, false))
                return;
            Range.PointsCount = val;
            CanFireTextChangedEvent = false;
            MeasurementStepTextBox.Text = Range.Step.ToString();
            CanFireTextChangedEvent = true;
        }

        private void MeasureFromTextBox_Leave(object sender, EventArgs e)
        {
            RefreshContent();
        }

        private void MeasureToTextBox_Leave(object sender, EventArgs e)
        {
            RefreshContent();
        }

        private void MeasurementStepTextBox_Leave(object sender, EventArgs e)
        {
            RefreshContent();
        }

        private void MeasurementsNumberTextBox_Leave(object sender, EventArgs e)
        {
            RefreshContent();
        }

        

        



        
    }

    
}

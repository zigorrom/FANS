using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace FANS.classes
{
    
    class Agilent_AnalogInput_LowLevel
    {
        
      

        public Agilent_AnalogInput_LowLevel()
        {
            if (!Agilent_USB_DAQ.Instance.isAlive())
                Agilent_USB_DAQ.Instance.Open();

            if (!Agilent_USB_DAQ.Instance.isAlive()) throw new Exception("Device Not Connected"); 
                                    
        }

        public bool CheckAcquisitionStatus()
        {
            string status = Agilent_USB_DAQ.Instance.QueryString("WAV:STAT?");
            if (status == "OVER\n") throw new Exception("Device buffer overload");
            if (status == "DATA\n") return true;
            return false;
        }
        public bool CheckSingleShotAcquisitionStatus()
        {

            string status = Agilent_USB_DAQ.Instance.QueryString("WAV:COMP?");
            if (status == "NO\n") return false;
            if (status == "YES\n") return true;
            return false;


        }


        public void tryToWriteString(string WhatToWrite)
        {
            try { Agilent_USB_DAQ.Instance.WriteString(WhatToWrite); }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }
        public string tryToQueryString(string WhatToWrite)
        {
            try
            {
                string result = Agilent_USB_DAQ.Instance.QueryString(WhatToWrite);
            return result.Substring(0, result.Length - 1);
            }
            catch (Exception e) { MessageBox.Show(e.Message); return null; }
        }

        public string AcquireRawADC_Data()
        {
            return Agilent_USB_DAQ.Instance.QueryString("WAV:DATA?");
        }
        

    }
}

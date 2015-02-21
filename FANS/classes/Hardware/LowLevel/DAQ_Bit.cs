using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class DAQ_Bit
    {
        private int _byteNumber, _bitNumber,_value;
        private Agilent_DigitalOutput_LowLevel _DIO;
        public DAQ_Bit(int byteNumber, byte bitNumber)
        {
            if ((byteNumber < 505) && (byteNumber > 500)) _byteNumber = byteNumber;
            else throw new Exception("Wrong byte number" + byteNumber);

            if ((bitNumber < 8)) _bitNumber = bitNumber;
            else throw new Exception("Wrong byte number" + bitNumber);

            _DIO = Agilent_DigitalOutput_LowLevel.Instance;
        }

        public int value
        {
            set 
             {
                 if (value == 1) _DIO.setToOne(_byteNumber, (byte)_bitNumber);
                 if (value == 0) _DIO.setToZero(_byteNumber, (byte)_bitNumber);
                 _value = value;
             }
            get
            {
                _value = _DIO.getValue(_byteNumber, (byte)_bitNumber);

                return _value;
            }
        }

        public void Pulse()
        {
            _DIO.BitPulse(_byteNumber, (byte)_bitNumber);
        }
        public void longPulse()
        {
            _DIO.BitRelayPulse(_byteNumber, (byte)_bitNumber);
        }
        

    }
}

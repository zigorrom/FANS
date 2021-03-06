﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using FANS.interfaces;
namespace FANS.classes
{
    class RawADCDataString :DataString
    {
        public double Time;
        public double Channel_1_Voltage;
        public double Channel_2_Voltage;
        public double Channel_3_Voltage;
        public double Channel_4_Voltage;

        public RawADCDataString()
        {
            Time = 0;
            Channel_1_Voltage = 0;
            Channel_2_Voltage = 0;
            Channel_3_Voltage = 0;
            Channel_4_Voltage = 0;
        }

        public RawADCDataString(double time, double channel_1_voltage, double channel_2_voltage, double channel_3_voltage, double channel_4_voltage)
        {
            Time = time;
            Channel_1_Voltage = channel_1_voltage;
            Channel_2_Voltage = channel_2_voltage;
            Channel_3_Voltage = channel_3_voltage;
            Channel_4_Voltage = channel_4_voltage;
        }

        public RawADCDataString blankCopy(double time, double channel_1_voltage, double channel_2_voltage, double channel_3_voltage, double channel_4_voltage)
        {
            return new RawADCDataString(time,channel_1_voltage,channel_2_voltage,channel_3_voltage,channel_4_voltage);
        }
        public override MeasurDataInterface clone()
        {
            return new RawADCDataString(this.Time, this.Channel_1_Voltage, this.Channel_2_Voltage, this.Channel_3_Voltage, this.Channel_4_Voltage);
        }
    }
}

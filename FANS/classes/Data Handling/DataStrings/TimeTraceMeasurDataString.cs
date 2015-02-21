﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{   
    class TimeTraceMeasurDataString : DataString
    {
        public double SampleVoltage=0;
        public double SampleCurrent=0;
        public double EquivalentResistance=0;
        public string FileName="";
        public double Rload=0;
        public double Uwhole=0;
        public double URload = 0;
        public double Vg = 0;
        public double U0sample=0;
        public double U0whole=0;
        public double U0Rload = 0;
        public double U0Gate = 0;
        public double R0sample=0;
        public double REsample=0;
        public double Temperature0=0;
        public double TemperatureE=0;
        public double kAmpl=0;
        public double Length=0;
        public double SamplingRate = 0;
        public TimeTraceMeasurDataString()
        {

        }

        public TimeTraceMeasurDataString(MeasurDataString data)
        {
            this.FromMeasurDataString(data);
        }
        public TimeTraceMeasurDataString(TimeTraceMeasurDataString data)
        {
            this.FromTimeTraceMeasurDataString(data);
        }
        public void FromMeasurDataString(MeasurDataString data)
        {
            this.SampleCurrent = data.SampleCurrent;
            this.SampleVoltage = data.SampleVoltage;
            this.EquivalentResistance = data.EquivalentResistance;
            this.SamplingRate = 0;
            this.FileName = data.FileName;
            this.Rload = data.Rload;
            this.Uwhole = data.Uwhole;
            this.U0sample = data.U0sample;
            this.U0whole = data.U0whole;
            this.R0sample = data.R0sample;
            this.REsample = data.REsample;
            this.Temperature0 = data.Temperature0;
            this.TemperatureE = data.TemperatureE;
            this.kAmpl = data.kAmpl;
            this.Vg = data.Vg;
        }

        public void FromTimeTraceMeasurDataString(TimeTraceMeasurDataString data)
        {
            this.SampleCurrent = data.SampleCurrent;
            this.SampleVoltage = data.SampleVoltage;
            this.EquivalentResistance = data.EquivalentResistance;
            this.SamplingRate = 0;
            this.FileName = data.FileName;
            this.Rload = data.Rload;
            this.Uwhole = data.Uwhole;
            this.U0sample = data.U0sample;
            this.U0whole = data.U0whole;
            this.R0sample = data.R0sample;
            this.REsample = data.REsample;
            this.Temperature0 = data.Temperature0;
            this.TemperatureE = data.TemperatureE;
            this.kAmpl = data.kAmpl;
            this.Vg = data.Vg;
            this.Length = data.Length;
            this.SamplingRate = data.SamplingRate;
        }
        public override interfaces.MeasurDataInterface clone()
        {
            return new TimeTraceMeasurDataString(this);
        }
    }
}

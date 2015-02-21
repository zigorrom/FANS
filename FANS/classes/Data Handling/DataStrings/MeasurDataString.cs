﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FANS.interfaces;
using System.Reflection;

namespace FANS.classes
{
     class MeasurDataString : DataString
    {
        public double SampleVoltage=0;
        public double SampleCurrent=0;
        public double EquivalentResistance=0;
        public string FileName="";
        public double Rload=0;
        public double Uwhole = 0;
        public double URload = 0;
        public double U0sample=0;
        public double U0whole=0;
        public double U0Rload = 0;
        public double U0Gate = 0;
        public double R0sample=0;
        public double REsample=0;
        public double Temperature0=0;
        public double TemperatureE=0;
        public double kAmpl=0;
        public double NAver=0;
        public double Vg=0;
        
        public MeasurDataString()
        {

        }
        public MeasurDataString(MeasurDataString dataToCopy)
        {
            this.fromMeasurDataString(dataToCopy);
        }
        public void fromMeasurDataString(MeasurDataString MainData)
        {
            FieldInfo[] info = MainData.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < info.Length; i++)
            {
                info[i].SetValue(this, info[i].GetValue(MainData));
            }
        }
        public override MeasurDataInterface clone()
        {
            return new MeasurDataString(this);
        }
    }

}


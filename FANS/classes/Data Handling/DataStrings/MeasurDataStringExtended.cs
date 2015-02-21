using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FANS.interfaces;
using System.Reflection;
using ZedGraph;
namespace FANS.classes
{
    class MeasurDataStringExtended : MeasurDataString
    {
        public double f_Sv_flicker=0;
        public double AlphaFlicker=0;
        public double f_S_I_Flicker=0;
        public double f_S_I_Flicker_I2=0;
        public double GR1_S_I_0=0;
        public double GR1_f_0=0;
        public double GR2_S_I_0=0;
        public double GR2_f_0=0;
        public double GR3_S_I_0=0;
        public double GR3_f_0=0;
        public double GR4_S_I_0=0;
        public double GR4_f_0=0;
        public double GR5_S_I_0=0;
        public double GR5_f_0=0;

        public MeasurDataStringExtended()
        {
        }
        public MeasurDataStringExtended FromMeasurDataString(MeasurDataString MainData)
        {
            FieldInfo[] info = MainData.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < info.Length; i++)
            {
                info[i].SetValue(this, info[i].GetValue(MainData));
            }
            info = this.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < info.Length; i++)
            {

                if (info[i].FieldType == typeof(string))
                    info[i].SetValue(this, "");
                if (info[i].FieldType == typeof(double))
                    info[i].SetValue(this, 0);
            }
            return this;

        }
        public MeasurDataStringExtended FromMeasureDataStringExtended(MeasurDataStringExtended MainData)
        {
            FieldInfo[] info = MainData.GetType().GetFields(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < info.Length; i++)
            {
                info[i].SetValue(this, info[i].GetValue(MainData));
            }
            return this;
        }
        public MeasurDataStringExtended(MeasurDataStringExtended data):base()
        {
            this.FromMeasureDataStringExtended(data);
        }
        public MeasurDataStringExtended(MeasurDataString data)
            : base()
        {
            this.FromMeasurDataString(data);
        }
        public override MeasurDataInterface clone()
        {
            return new MeasurDataStringExtended(this);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace FANS.classes
{
    class ListOfNoiseDataString:ListDataString
    {
        public ListOfNoiseDataString()
        {
            this.FileHeader = "Frequency\tSv\t";
            this.FileSubheader = "Hz\tV^2";
            this.DataString = new NoiseSpectraDataString();
            ListOfData = new List<interfaces.MeasurDataInterface>();
        }
        public ListOfNoiseDataString(PointPairList data):this()
        {
            this.ParseFromPointPairList(data);
        }
        public void ParseFromPointPairList(PointPairList data)
        {
            ListOfData.Clear();
            foreach (PointPair dataPoint in data)
            {
                ListOfData.Add(new NoiseSpectraDataString(dataPoint));
            }
        }
    }
}

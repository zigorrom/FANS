using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FANS.interfaces;
namespace FANS.classes
{
    class ListOfTimeTraceMeasurDataString:ListDataString
    {
        public ListOfTimeTraceMeasurDataString()
        {
            this.FileHeader = "U\\-(sample)\tCurrent\tR\\-(Eq)\tFilename\tR\\-(load)\tU\\-(Whole)\tU\\-(Rload)\tV\\-(g)\tU\\-(0sample)\tU\\-(0Whole)\tU\\-(0Rload)\tV\\-(0g)\tR\\-(0sample)\tR\\-(sample)\tTemperature\\-(0)\tTemperature\\-(E)\tk\\-(ampl)\tLength\tSampling Rate";
            this.FileSubheader="V\tA\t\\g(W)\t\t\\g(W)\tV\tV\tV\tV\tV\tV\tV\t\\g(W)\t\\g(W)\tK\tK\t\ts\tHz";
            this.DataString=new TimeTraceMeasurDataString();
            ListOfData = new List<MeasurDataInterface>();
        }

        public void RefreshTimeTraceMeasurDataString(TimeTraceMeasurDataString data)
        {
            int Position = _NumberByFileName(data.FileName);
            ListOfData[Position] = new TimeTraceMeasurDataString(data);
        }
        private int _NumberByFileName(string filename)
        {
            List<TimeTraceMeasurDataString> dataList = ListOfData.ConvertAll(o => (TimeTraceMeasurDataString)o);
            int result=0;
            for(result=dataList.Count-1;result>=0;result--)
            {
                if (dataList[result].FileName == filename) break;
            }
            return result;
        }
    }
}

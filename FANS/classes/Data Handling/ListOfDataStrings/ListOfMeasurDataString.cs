using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FANS.interfaces;
using System.IO;
namespace FANS.classes
{
    class ListOfMeasurDataString : ListDataString
    {

                
        public ListOfMeasurDataString()
        {
            this.DataString = new MeasurDataString();
            this.ListOfData = new List<MeasurDataInterface>();
            //this.readFromFile();
            FileHeader = "U\\-(sample)\tCurrent\tR\\-(Eq)\tFilename\tR\\-(load)\tU\\-(Whole)\tU\\-(Rload)\tU\\-(0sample)\tU\\-(0Whole)\tU\\-(0Rload)\tU\\-(0Gate)\tR\\-(0sample)\tR\\-(Esample)\tTemperature\\-(0)\tTemperature\\-(E)\tk\\-(ampl)\tN\\-(aver)\tV\\-(g)";
            FileSubheader = "V\tA\t\\g(W)\t\t\\g(W)\tV\tV\tV\t\\g(W)\t\\g(W)\tK\tK\t\t\tV";
            FileName = "MeasurData.dat";
            
        }
        public void Add(MeasurDataString A)
        {
            this.ListOfData.Add(A);
        }

        
    }
}

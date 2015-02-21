using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.classes
{
    class ListOfMeasurDataStringExtended : ListDataString
    {
        
        protected new string FileHeader = "U\\-(sample)\tCurrent\tR\\-(Eq)\tFilename\tR\\-(load)\tU\\-(Whole)\tU\\-(0sample)\tU\\-(0Whole)\tR\\-(0sample)\tR\\-(Esample)\tTemperature\\-(0)\tTemperature\\-(E)\tk\\-(ampl)\tN\\-(aver)\tV\\-(g)\tA\\-(flicker)\tAlphaFlicker\tfS\\=(I,Flicker)\tfS\\=(I,Flicker)/I\\+(2)\tGR1 S\\-(I)(0)\tGR1 f\\-(0)\tGR2 S\\-(I)(0)\tGR2 f\\-(0)\tGR3 S\\-(I)(0)\tGR3 f\\-(0)\tGR4 S\\-(I)(0)\tGR4 f\\-(0)\tGR5 S\\-(I)(0)\tGR5 f\\-(0)\t";
        protected new string FileSubheader = "V\tA\t\\g(W)\t\t\\g(W)\tV\tV\tV\t\\g(W)\t\\g(W)\tK\tK\t\t\tV\tV\\+(2)\t\tA\\+(2)\t\tA\\+(2)/Hz\tHz\tA\\+(2)/Hz\tHz\tA\\+(2)/Hz\tHz\tA\\+(2)/Hz\tHz\tA\\+(2)/Hz\tHz";
        protected new string FileName = "MeasurDataExtended.dat";
        public ListOfMeasurDataStringExtended()
        {
            this.DataString = new MeasurDataStringExtended();
            this.readFromFile();

        }
        public void Add(MeasurDataStringExtended A)
        {
            this.ListOfData.Add(A);
        }

    }
}

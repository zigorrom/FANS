﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.interfaces
{
    interface MeasurDataInterface {
         string toString();
         void parseFromString(string readString);
         MeasurDataInterface clone();
    }
}

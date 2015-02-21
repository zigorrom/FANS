using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FANS.interfaces
{
    interface SCPI_Device
    {
         bool Open();
         bool WriteString(string WhatToWrite);
         string ReadString();
         void Close();
    }
}

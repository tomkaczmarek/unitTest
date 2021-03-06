﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn
{
    public class FileExtensionManager : IExtensionManager
    {

        public bool IsValid(string fileName)
        {

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("No file name");
            }

            if (!fileName.EndsWith("SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }
    }
}

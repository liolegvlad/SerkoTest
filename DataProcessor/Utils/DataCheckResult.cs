using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Utils
{
    public enum DataCheckResult
    {
        Undefined,
        NoDataToProcessFound,
        DataAreNotWellFormed,
        DataAreWellFormed,
        MandatoryDataAreMissing
    }
}

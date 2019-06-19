using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor.Interfaces
{
    public interface IDataChecker
    {
        DataCheckResult CheckData(string inputData);
    }
}

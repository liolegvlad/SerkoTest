using DataProcessor.Interfaces;
using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace DataProcessor.Processors
{
    public class XmlDataChecker : IDataChecker
    {
        public DataCheckResult CheckData(string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return DataCheckResult.NoDataToProcessFound;

            //Trying to search xml tags in iput data
            MatchCollection matches = Regex.Matches(inputData, @"<[^.@>]+>");
            StringBuilder sbXml = new StringBuilder();
            foreach (Match match in matches)
                sbXml.Append(match.Value);

            if (string.IsNullOrEmpty(sbXml.ToString()))
                return DataCheckResult.NoDataToProcessFound;

            //Trying to validate whether string is well-formed xml-string
            //(including validation for having corresponding closing tag (as part of test requirement))
            string xmlToValidate = string.Format("<{0}>{1}</{0}>", "dataContent", sbXml.ToString());
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(xmlToValidate);
                return DataCheckResult.DataAreWellFormed;
            }
            catch
            {
                return DataCheckResult.DataAreNotWellFormed;
            }
        }
    }
}

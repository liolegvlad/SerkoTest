using DataProcessor.Interfaces;
using DataProcessor.Models;
using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataProcessor.Processors
{
    public class ExpenseClaimParser : IDataParser
    {
        public ProcessResult<TData> Parse<TData>(string inputData) where TData : class
        {
            ProcessResult<TData> processResult = new ProcessResult<TData>()
            {
                Success = false,
                CheckResult = DataCheckResult.Undefined
            };

            //Getting xml content from input data
            string regExpPatternTemplate = @"<{0}>[\s\S]*?<\/{0}>";
            string[] xmlTagNames = new string[] { "expense", "vendor", "description", "date" };
            StringBuilder sbXml = new StringBuilder();
            foreach (string tagName in xmlTagNames)
            {
                MatchCollection matches = Regex.Matches(inputData, string.Format(regExpPatternTemplate, tagName));
                foreach (Match match in matches)
                    sbXml.Append(match.Value);
            }

            //Deserializing xml content into ExpenseClaim object
            string xml = string.Format("<{0}>{1}</{0}>", "ExpenseClaim", sbXml.ToString());
            ExpenseClaim expenseClaim = xml.XmlDeserializeFromString<ExpenseClaim>();

            processResult.Data = (TData)Convert.ChangeType(expenseClaim, typeof(TData));

            if (expenseClaim.Expense.Total == 0)
            {
                processResult.CheckResult = DataCheckResult.MandatoryDataAreMissing;
                return processResult;
            }

            expenseClaim.Expense.CostCentre = expenseClaim.Expense.CostCentre ?? "UNKNOWN";

            processResult.Success = true;
            processResult.CheckResult = DataCheckResult.DataAreWellFormed;

            return processResult;
        }
    }
}

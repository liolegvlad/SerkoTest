using DataProcessor.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataProcessor.Models
{
    public class ExpenseClaim
    {
        [XmlElement("expense")]
        public Expense Expense { get; set; }

        [XmlElement("vendor")]
        public string Vendor { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }
    }

    public class Expense
    {
        [XmlElement("cost_centre")]
        public string CostCentre { get; set; }

        [XmlElement("total")]
        public decimal Total
        {
            get; set;
        }

        [XmlElement("payment_method")]
        public string PaymentMethod { get; set; }

        public decimal Gst
        {
            get { return Utilities.ExtractGst(Total); }
        }

        public decimal TotalExcludingGst
        {
            get { return (Total - Gst); }
        }
    }
}

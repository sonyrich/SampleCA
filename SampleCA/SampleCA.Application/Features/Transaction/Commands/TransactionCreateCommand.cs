using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Features.Transaction.Commands
{
    public class TransactionCreateCommand : IRequest<bool>
    {
        public int TransID { get; set; }
        public int TransTypeID { get; set; }
        public string TransType { get; set; }
        public string PropertyType { get; set; }
        public int? PropertyCategoryID { get; set; }
        public string PropertyCategory { get; set; }
        public string PropertyModel { get; set; }
        public DateTime KeyinDate { get; set; }
        public DateTime SubDate { get; set; }
        public string SalesType { get; set; }
        public string ClosingAgtCEANo { get; set; }
        public string ClosingAgtBizName { get; set; }
        public DateTime OptionDate { get; set; }
        public string HseNo { get; set; }
        public string StreetName { get; set; }
        public string ProjectName { get; set; }
        public double TransactedPrice { get; set; }
        public double TransactionComm { get; set; }
        public string CurrencyType { get; set; }
        public string CultureCode { get; set; }
        public string LastUpdater { get; set; }
    }
}

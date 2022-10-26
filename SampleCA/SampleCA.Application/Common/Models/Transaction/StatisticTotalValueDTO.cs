using CMSAPI.SampleCA.Application.Common.Mappings;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Common.Models.Transaction
{
    public class StatisticTotalValueDTO : IMapFrom<TransactionDatas>
    {
        public int TransID { get; set; }
        public string TransType { get; set; }
        public string HseNo { get; set; }
        public string ClosingAgtCEANo { get; set; }
        public string ClosingAgtBizName { get; set; }
        public string StreetName { get; set; }
        public string ProjectName { get; set; }
        public double TotalGrossValue { get; set; }
        public double TotalNetValue { get; set; }
    }
}

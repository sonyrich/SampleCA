﻿using CMSAPI.SampleCA.Application.Common.Mappings;
using SampleCA.Domain.Entities.AESTraining.Entities.AESTraining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCA.Application.Common.Models.Transaction
{
    public class TransactionGCRDatasDTO : IMapFrom<TransactionGCRDatas>
    {
        public string TransSource { get; set; }
        public DateTime RcvDate { get; set; }
        public string RoleDisplay { get; set; }
        public string CategoryDisplay { get; set; }
        public string AgtCEANo { get; set; }
        public string AgtBizName { get; set; }
        public double GrossValue { get; set; }
        public double NetValue { get; set; }
        public TransactionDatasDTO TransactionDatas { get; set; }
    }
}

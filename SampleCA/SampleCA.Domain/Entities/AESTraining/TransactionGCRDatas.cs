// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SampleCA.Domain.Entities.AESTraining.Entities.AESTraining
{
    public partial class TransactionGCRDatas
    {
        public long ID { get; set; }
        public int TransID { get; set; }
        public string TransSource { get; set; }
        public DateTime RcvDate { get; set; }
        public int TypeID { get; set; }
        public string RoleDisplay { get; set; }
        public int CategoryID { get; set; }
        public string CategoryDisplay { get; set; }
        public string AgtCEANo { get; set; }
        public string AgtBizName { get; set; }
        public double GrossValue { get; set; }
        public double NetValue { get; set; }
        public virtual TransactionDatas TransactionData { get; set; }

    }
}
using System;
using Catamaran_Models.Enums;
using Catamaran_Models.Interfaces;

namespace Catamaran_Models.Models
{
    public class TransactionModel:ITransactionModel
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Vendor { get; set; }
        public string Product { get; set; }
        public PaymentModes PaymentMethod { get; set; }

    }
}

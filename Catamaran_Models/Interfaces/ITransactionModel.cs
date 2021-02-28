using Catamaran_Models.Enums;
using System;

namespace Catamaran_Models.Interfaces
{
    public interface ITransactionModel
    {
        public Guid TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string Vendor { get; set; }
        public string Product { get; set; }
        public PaymentModes PaymentMethod { get; set; }
    }
}

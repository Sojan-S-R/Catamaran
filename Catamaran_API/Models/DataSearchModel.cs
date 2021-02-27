using Catamaran_Models.Enums;
using System;

namespace Catamaran_API.Models
{
    public class DataSearchModel
    {
        public Guid? TransactionId { get; set; }
        public Months Month { get; set; } = Months.NotSet;
        public int? Year { get; set; }
    }
}

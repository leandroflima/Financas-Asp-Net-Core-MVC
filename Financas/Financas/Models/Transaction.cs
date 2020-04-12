using Financas.Models.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financas.Models
{
    public class Transaction : ModelBase
    {
        public DateTime CreateOn { get; set; }

        public DateTime PaymentOn { get; set; }

        public string AccountId { get; set; }

        public string SubGroupId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        public TransactionType Type { get; set; }

        public TransactionStatus Status { get; set; }
    }
}

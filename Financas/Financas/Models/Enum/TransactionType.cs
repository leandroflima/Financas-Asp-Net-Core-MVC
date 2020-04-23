using System.ComponentModel.DataAnnotations;

namespace Financas.Models.Enum
{
    public enum TransactionType
    {
        [Display(Name = "Crédito")]
        Credit = 1,
        [Display(Name = "Débito")]
        Debit = 2
    }
}

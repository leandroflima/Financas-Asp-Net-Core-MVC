using System.ComponentModel.DataAnnotations;

namespace Financas.Models.Enum
{
    public enum TransactionStatus
    {
        [Display(Name = "Pendente")]
        Pending = 1,
        [Display(Name = "Quitado")]
        Paid = 2
    }
}

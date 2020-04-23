using System.ComponentModel.DataAnnotations;

namespace Financas.Models.Enum
{
    public enum AccountType
    {
        [Display(Name = "Bancária")]
        Bank = 1,
        [Display(Name = "Investimento")]
        Investment = 2
    }
}

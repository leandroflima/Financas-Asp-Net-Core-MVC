using System.ComponentModel.DataAnnotations;

namespace Financas.Models.Enum
{
    public enum AccountStatus
    {
        [Display(Name = "Ativo")]
        Active = 1,
        [Display(Name = "Inativo")]
        Inactive = 2
    }
}
